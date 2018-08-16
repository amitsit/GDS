/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/RegionService.js" />

app.controller('RegionController', function ($scope, $state, localStorageService, $stateParams, $rootScope, $location, RegionService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    INIT();

    //All initialization Should Be here
    function INIT() {

        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View Region");
        //
        GetRegionList();
    }

    function GetRegionList() {
        var promiseGetRegionData = RegionService.GetRegionList();
        promiseGetRegionData.success(function (response) {
            $scope.RegionListData = response.Data;
            BindRegionList($scope.RegionListData);
        });
        promiseGetRegionData.error(function (data, statusCode) {
        });
    }


    function BindRegionList(RegionListData) {

        if ($.fn.DataTable.isDataTable("#tblRegion")) {
            $('#tblRegion').DataTable().destroy();
        }
        
        $('#tblRegion').DataTable({
            data: $scope.RegionListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
              "stateSave": true,
            "columns": [
                 {
                     "title": ($filter("translate")("Admin_Roles_Name")),
                     "data": "RegionName",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         //return '<a ui-sref="EditRegion({RegionID:' + row.RegionID + '})" >' + data + '</a>';
                         return data;
                     }
                 },
             {
                 "title": ($filter("translate")("Admin_Roles_Active")),
                 "className": "dt-center",
                 "data": "IsActive",
                 "render": function (data, type, row) {
                     return (row.IsActive) ? "Yes" : "No";
                 }
             },
            {
                "title": ($filter("translate")("Admin_CreatedDate")),
                "className": "dt-center",
                "data": "CreatedDate", "bSortable": true, "render": function (data, type, row) {
                    if (data) {
                        return $filter('date')(data, $rootScope.GlobalDateFormat);
                    }
                    else {
                        return data;
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
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Add / Update Region')) {
                        strAction = "<a><i ui-sref='EditRegion({RegionID:" + row.RegionID + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
                    }
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Delete Region')) {
                        strAction=strAction+ "<a><i ng-click='DeleteRegion($event)' class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
                    }
                    return strAction;
                }
            }
            ],
            "initComplete": function () {
            },
            "fnDrawCallback": function () {
                BindToolTip();
                //setTimeout(function () { SetAnchorLinks(); }, 500);
            },
            "fnCreatedRow": function (nRow, aData, iDataIndex) {
                $compile(angular.element(nRow).contents())($scope);
            }
        });

    }

    $scope.DeleteRegion = function ($event) {
        var table = $('#tblRegion').DataTable();
        var row = table.row($($event.target).parents('tr')).data();
        bootbox.dialog({
            message: "Do you want to delete a region" + ' - ' + row.RegionName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteRegion = RegionService.DeleteRegion(row.RegionID);
                            deleteRegion.success(function (p) {
                                notificationFactory.successDelete();
                                GetRegionList();
                            });
                            deleteRegion.error(function (pl, statusCode) {
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

app.controller('AddOrUpdateRegionController', function ($scope, localStorageService, $state, $stateParams, $rootScope, $location, RegionService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    INIT();
    //--Check is Page Accessible
    $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View Region");
    //
    $scope.UserId = $rootScope.LoginUserDetail.UserId;
    $scope.RegionID = parseInt($stateParams.RegionID);
    $scope.RegionObj = { IsActive: true };

    //All initialization Should Be here
    INIT();
    function INIT() {

        if ($scope.RegionID > 0) {
            $scope.PageTitle = ($filter("translate")("Region_Edit"));
        }
        else {
            $scope.PageTitle = ($filter("translate")("Region_Add"));
        }
    }

    $scope.GetRegionDetail = function () {
        var promiseGetRegionData = RegionService.GetRegionDetail($scope.RegionID);
        promiseGetRegionData.success(function (response) {
            $scope.RegionObj = response.Data[0];
          //  $scope.GetRegionList();
            if (!$scope.RegionID > 0) {
                $scope.RegionObj.RegionID = 0;
            }
        });
        promiseGetRegionData.error(function (data, statusCode) {
        });
    }

    //$scope.GetRegionList = function () {
    //    var promiseGetRegionData = RegionService.GetRegionList();
    //    promiseGetRegionData.success(function (response) {
    //        $scope.RegionList = response.Data;
    //    });
    //    promiseGetRegionData.error(function (data, statusCode) {
    //    });
    //}


    $scope.SaveRegion = function (form) {
        if (form.$valid) {

            var SaveRegion = RegionService.AddOrUpdateRegion($scope.UserId, $scope.RegionObj);
            SaveRegion.success(function (response) {

                if (response.Success) {
                    if ($scope.RegionID > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('Region');
                }
                else {
                    if (response.InsertedId == -2) {
                        toastr.error($filter("translate")("Region_Error"));
                    }
                }


            });

            SaveRegion.error(function (error, statusCode) {
            });
        }
    };

    $scope.DeleteRegion = function ($event) {
        var table = $('#tblRegion').DataTable();
        var row = table.row($($event.target).parents('tr')).data();

        bootbox.dialog({
            message: "Do you want to delete a region" + '-' + row.RegionName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteRegion = RegionService.DeleteRegion();
                            deleteRegion.success(function (p) {

                                notificationFactory.successDelete();

                            });
                            deleteRegion.error(function (pl, statusCode) {
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

    $scope.cancel = function () {
        $state.transitionTo('Region');
    }
    if ($stateParams.RegionID > 0) {
        $scope.GetRegionDetail();
    } 
});