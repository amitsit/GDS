/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/StateService.js" />

app.controller('StateController', function ($scope, $state, localStorageService, $stateParams, $rootScope, $location, StateService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    INIT();

    //All initialization Should Be here
    function INIT() {
       //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View State");
        //
        GetStateList();
    }

    function GetStateList() {
        var promiseGetStateData = StateService.GetStateList();
        promiseGetStateData.success(function (response) {
            $scope.StateListData = response.Data;
            BindStateList($scope.StateListData);
        });
        promiseGetStateData.error(function (data, statusCode) {
        });
    }


    function BindStateList(StateListData) {
        if ($.fn.DataTable.isDataTable("#tblState")) {
            $('#tblState').DataTable().destroy();
        }

        $('#tblState').DataTable({
            data: $scope.StateListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
             "stateSave": true,
            "columns": [
                 {
                     "title": ($filter("translate")("Admin_Roles_Name")),
                     "data": "StateName",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         //return '<a href="" ui-sref="EditState({StateID:' + row.StateID + '})">' + data + '</a>';
                         return data;
                     }
                 },
            //{
            //    "title": "State Name", "data": "StateName"
            //},
            {
                "title": ($filter("translate")("Country_Name")),
                "data": "CountryName",
                 "className": "dt-left"
            },
             {
                 "title": ($filter("translate")("Admin_Roles_Active")),
                 "className": "dt-center",
                 "data": "IsActive",
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
                 "title": ($filter("translate")("Admin_CreatedDate")),
                 "className": "dt-center",
                 "data": "CreatedDate", "bSortable": true, "render": function (data, type, row) {
                     if (data) {
                         return $filter('date')(data, $rootScope.GlobalDateFormat)
                     }
                     else {
                         return data;
                     }
                 }
             },
            {
                "title": ($filter("translate")("Admin_Roles_Action")),
                "className": "dt-center",
                "data": null,
                "sClass": "action dt-center",
                "sorting": "false",
                "render": function (data, type, row) {
                    var strAction = '';
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Add / Update State')) {
                        strAction = "<a><i ui-sref='EditState({StateID:" + row.StateID + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
                    }
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Delete State')) {
                        strAction = strAction + "<a><i ng-click='DeleteState($event)' class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
                    }
                    return strAction;                        
                }
            }
            ],
            "initComplete": function () {
                var dataTable = $('#tblState').DataTable();
           //     BindCustomerSearchBar($scope, $compile, dataTable);
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

    $scope.DeleteState = function ($event) {
        var table = $('#tblState').DataTable();
        var row = table.row($($event.target).parents('tr')).data();

        bootbox.dialog({
            message: "Do you want to delete " + '-' + row.StateName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteState = StateService.DeleteState(row.StateID);
                            deleteState.success(function (p) {
                                if (p.InsertedId == -3) {
                                    toastr.error($filter("translate")("State_CanNotDelete"));
                                }
                                else {
                                    notificationFactory.successDelete();
                                    GetStateList();
                                }
                            });
                            deleteState.error(function (pl, statusCode) {
                                exceptionService.ShowException(pl, statusCode);
                            });
                        }
                    },
                danger:
                    {
                        label: "No",
                        className: "btn btn-default",
                        callback: function () {
                            return true;
                        }
                    }
            }
        });
    }
});

app.controller('AddOrUpdateStateController', function ($scope, localStorageService, $state, $stateParams, $rootScope, $location, StateService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
  
    // this is temporary
    $scope.UserId = $rootScope.LoginUserDetail.UserId;
    $scope.StateID = parseInt($stateParams.StateID);
    $scope.StateObj = { IsActive: true };

    //All initialization Should Be here
    INIT();
    function INIT() {
       //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View State");
        //
        if ($scope.StateID > 0) {
            $scope.PageTitle =($filter("translate")( "State_Edit"));
        }
        else {
            $scope.PageTitle = ($filter("translate")("State_Add"));
        }
    }

    $scope.GetStateDetail = function () {
        var promiseGetStateData = StateService.GetStateDetail($scope.StateID);
        promiseGetStateData.success(function (response) {
            $scope.StateObj = response.Data[0];
            $scope.GetCountryList();
            if (!$scope.StateID > 0) {
                $scope.StateObj.StateID = 0;
            }
        });
        promiseGetStateData.error(function (data, statusCode) {
        });
    }

    $scope.GetCountryList = function () {
        var promiseGetCountryList = StateService.GetCountryList();
        promiseGetCountryList.success(function (response) {
            $scope.CountryList = response.Data;
        });
        promiseGetCountryList.error(function (data, statusCode) {
        });
    }


    $scope.SaveState = function (form) {
        if (form.$valid) {
            var SaveState = StateService.AddOrUpdateState($scope.UserId, $scope.StateObj);
            SaveState.success(function (response) {
                if (response.Success) {
                    if ($scope.StateID > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('State');
                }
                else {
                    if (response.InsertedId == -1) {
                        toastr.error($filter("translate")("State_Duplicateerror"));
                    }
                }


            });

            SaveState.error(function (error, statusCode) {
            });
        }
    };



    $scope.cancel = function () {
        $state.transitionTo('State');
    }

    $scope.GetCountryList();
    if ($scope.StateID > 0) {
        $scope.GetStateDetail();
    }
});