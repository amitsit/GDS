app.controller('RoleController', function ($scope, $state, localStorageService, $stateParams,RoleService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
  
    INIT();

    function INIT() {
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.RoleId = 0; // Default 0 get All Roles
        //All initialization Should Be here
        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "User Quick Links", "View Roles and Rights");
        //
        GetRoleList();
    }

    function GetRoleList() {      
        var promiseGetRoleList = RoleService.GetRoleList($scope.UserId, $scope.RoleId);
        promiseGetRoleList.success(function (response) {
            $scope.RoleListData = response.Data;
            BindRoleList($scope.RoleListData);
        });
        promiseGetRoleList.error(function (data, statusCode) {
        });
    }


    function BindRoleList(RoleListData) {

        if ($.fn.DataTable.isDataTable("#tblRole")) {
            $('#tblRole').DataTable().destroy();
        }

        $('#tblRole').DataTable({
            data: RoleListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
            "columns": [
                 {
                     "title": ($filter("translate")("Admin_Roles_Name")),
                     "data": "RoleName",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         return '<a href="" ui-sref="EditRole({RoleId:' + row.RoleId + '})" >' + data + '</a>';
                     }
                 },   
             {
                 "title": ($filter("translate")("Admin_Roles_Active")),
                 "data": "IsActive",
                 "className": "dt-center",
                 "render": function (data, type, row) {
                     if (row.IsActive) {
                         return "<label >Yes</label>";
                     }
                     else {
                         return "<label >No</label>";
                     }

                 }
             },
           
            {
                "title": ($filter("translate")("Admin_Roles_Action")),
                "data": null,
                "sClass": "action dt-center",
                "sorting": "false",
                "render": function (data, type, row) {

                    var strAction = '';
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'User Quick Links', 'Configure Role Rights')) {
                        strAction = strAction + "<a><i class='glyphicon glyphicon-cog cursor-pointer' data-original-title='Configure Role' data-toggle='tooltip' data-toggle='tooltip' ng-click='configureRole($event)'></i></a>";
                    }
                    //if ($rootScope.isSubModuleAccessibleToUser('Admin', 'User Quick Links', 'Delete Roles')) {
                    //     strAction = strAction + "<a class='actionPadding'><i ng-click='DeleteRole($event)' class='glyphicon glyphicon-trash cursor-pointer'></i></a>";
                    //}
                    return strAction;       
                }
            }
            ],
            "initComplete": function () {
                var dataTable = $('#tblRole').DataTable();
                BindCustomerSearchBar($scope, $compile, dataTable);
            },
            "fnDrawCallback": function () {
                BindToolTip();
                setTimeout(function () { SetAnchorLinks(); }, 500);
            },
            "fnCreatedRow": function (nRow, aData, iDataIndex) {
                $compile(angular.element(nRow).contents())($scope);
            }
        });

    }

    $scope.DeleteRole = function ($event) {
        var table = $('#tblRole').DataTable();
        var row = table.row($($event.target).parents('tr')).data();

        bootbox.confirm({
            message: "Do you want to deactivate role: " + row.RoleName + " ?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {                  
                    var promiseRemoveRole = RoleService.RemoveRole($scope.UserId, row.RoleId);
                    promiseRemoveRole.success(function (response) {

                        if (response.Success) {
                            toastr.success($filter("translate")("State_Deactivate"));
                            GetRoleList();
                        }
                        else {
                            toastr.warning($filter("translate")("NtfError"));
                        }
                       
                    });
                    promiseRemoveRole.error(function (data, statusCode) {
                    });

                }
            }
        });
    }

    $scope.configureRole = function ($event) {
        var table = $('#tblRole').DataTable();
        var row = table.row($($event.target).parents('tr')).data();
        $state.transitionTo('RoleConfiguration', ({ RoleId: row.RoleId, RoleName: row.RoleName }));
    }

    

});

app.controller('AddOrUpdateRoleController', function ($scope, $state, localStorageService, $stateParams, RoleService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();



    INIT();

    function INIT() {

      //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "User Quick Links", "View Roles and Rights");
        //

        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.RoleId = 0; // Default 0 get All Roles
        //All initialization Should Be here

        $scope.RoleId = parseInt($stateParams.RoleId);
        if ($scope.RoleId > 0) {
            $scope.PageTitle = ($filter("translate")("Admin_EditRole"));
            GetRoleDetail();
        }
        else {
            $scope.PageTitle = ($filter("translate")("Admin_AddRole"));
            $scope.RoleObj=new Object();
            $scope.RoleObj.RoleId = 0;
            $scope.RoleObj.IsActive = true;
            $scope.RoleObj.RoleName='';

        }      
    }

    function GetRoleDetail() {
        var promiseGetRoleDetail = RoleService.GetRoleList($scope.UserId, $scope.RoleId);
        promiseGetRoleDetail.success(function (response) {
            $scope.RoleObj = response.Data[0];          
        });
        promiseGetRoleDetail.error(function (data, statusCode) {
        });
    }

    $scope.AddOrUpdateRole = function (form) {
        if (form.$valid) {

            var PromiseSaveRole = RoleService.AddOrUpdateRole($scope.UserId, $scope.RoleObj);
            PromiseSaveRole.success(function (response) {

                if (response.Success) {
                    if ($scope.RoleId > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }

                    $state.transitionTo('Roles');
                }
                else {
                    if (response.InsertedId == -2) {
                        toastr.error($filter("translate")("Admin_RolError"));
                    }
                }


            });

            PromiseSaveRole.error(function (error, statusCode) {
            });
        }
    };

    $scope.cancel = function () {
        $state.transitionTo('Roles');
    }
});