/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/CountryService.js" />

app.controller('CountryController', function ($scope, $state, localStorageService, $stateParams, $rootScope, $location, CountryService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    INIT();

    //All initialization Should Be here
    function INIT() {
        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View Countries");
        //
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        GetCountryList();
    }

    function GetCountryList() {
        var promiseGetCountryData = CountryService.GetCountyList();
        promiseGetCountryData.success(function (response) {
            $scope.CountryListData = response.Data;
            BindCountryList($scope.CountryListData);
        });
        promiseGetCountryData.error(function (data, statusCode) {
        });
    }


    function BindCountryList(CountryListData) {

        if ($.fn.DataTable.isDataTable("#tblCountry")) {
            $('#tblCountry').DataTable().destroy();
        }

        $('#tblCountry').DataTable({
            data: $scope.CountryListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
            "stateSave": true,
            "columns": [
                 {
                     "title": ($filter("translate")("Admin_Roles_Name")),
                     "data": "CountryName",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         //return '<a href="" ui-sref="EditCountry({CountryID:' + row.CountryID + '})">' + data + '</a>';
                         return data;
                     }
                 },
            //{ "title": "Name", "data": "CountryName" },
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
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Add / Update Country')) {
                        strAction = "<a><i ui-sref='EditCountry({CountryID:" + row.CountryID + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
                    }
                    if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Delete Country')) {
                        strAction = strAction + "<a><i ng-click='DeleteCountry($event)' class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
                    }
                    return strAction;
                }
            }
            ],
            "initComplete": function () {
                var dataTable = $('#tblCountry').DataTable();
               // BindCustomerSearchBar($scope, $compile, dataTable);
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

    $scope.DeleteCountry = function ($event) {
        var table = $('#tblCountry').DataTable();
        var row = table.row($($event.target).parents('tr')).data();
        bootbox.dialog({
            message: "Do you want to delete " + '-' + row.CountryName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteCountry = CountryService.DeleteCountry(row.CountryID);
                            deleteCountry.success(function (response) {
                                if (response.Success) {
                                    toastr.success($filter("translate")("Country_DeleteSuccess"));
                                    GetCountryList();
                                } else if (response.InsertedId == -3) {
                                    toastr.error($filter("translate")("NtfError"));
                                } else {
                                    toastr.error($filter("translate")("Country_DeleteError"));
                                }
                            });
                            deleteCountry.error(function (pl, statusCode) {
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

app.controller('AddOrUpdateCountryController', function ($scope, localStorageService, $state, $stateParams, $rootScope, $location, CountryService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
    // this is temporary
    $scope.UserId = $rootScope.LoginUserDetail.UserId;
    $scope.CountryID = parseInt($stateParams.CountryID);

    $scope.GetCountryDetail = function () {
        var promiseGetCountryData = CountryService.GetCountryDetail($scope.CountryID);
        promiseGetCountryData.success(function (response) {
            $scope.CountryObj = response.Data[0];
            if (response.Data[0].SelectedRegion != null) {
                if (response.Data[0].SelectedRegion.split(',') != "") {
                    $scope.CountryObj.SelectedRegion = response.Data[0].SelectedRegion.split(',');
                    $scope.SelectedRegion();
                }
            }
        });
        promiseGetCountryData.error(function (data, statusCode) {
        });
    }

    function GetRegionList() {
        var promiseGetRegionData = CountryService.GetRegionList();
        promiseGetRegionData.success(function (response) {
            $scope.RegionList = [];
            if (response != null && response.Data != null && response.Data.length > 0) {
                var regionList = $filter('orderBy')(response.Data, ['RegionName']);
                angular.forEach(regionList, function (region, i) {
                    var regionObj = new Object();
                    regionObj.name = region.RegionName;
                    regionObj.id = region.RegionID;
                    $scope.RegionList.push(regionObj);
                });

                if ($scope.CountryID > 0) {
                    $scope.GetCountryDetail();
                }
            }
        });
        promiseGetRegionData.error(function (data, statusCode) {
        });
    }

    $scope.SaveCountry = function (form) {
        if (form.$valid && $scope.CountryObj.SelectedRegion.length > 0) {
            $scope.CountryObj.SelectedRegion = $scope.CountryObj.SelectedRegion.toString();
            var SaveCountry = CountryService.AddOrUpdateCountry($scope.UserId, $scope.CountryObj);
            SaveCountry.success(function (response) {

                if (response.Success) {
                    if ($scope.CountryID > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));


                    }

                    $state.transitionTo('Country');
                }
                else {
                    if (response.InsertedId == -2) {
                        toastr.error($filter("translate")("Country_Errorduplicate"));
                    }
                }


            });

            SaveCountry.error(function (error, statusCode) {
            });
        }
    };

    $scope.cancel = function () {
        $state.transitionTo('Country');
    }

    $scope.SelectedRegion = function () {
        $scope.RegionNames = '';
        for (var i = 0; i < $scope.CountryObj.SelectedRegion.length; i++) {
            $scope.RegionNames = $scope.RegionNames + ($scope.RegionNames == '' ? '' : ',') + $filter('filter')($scope.RegionList, { id: parseInt($scope.CountryObj.SelectedRegion[i]) }, true)[0].name;
        }
    }

    function INIT() {
        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "Location Quick Links", "View Countries");
        //
        GetRegionList();
        if ($scope.CountryID > 0) {
            $scope.PageTitle = ($filter("translate")("Country_Edit"));
        }
        else {
            $scope.PageTitle = ($filter("translate")("Country_Add"));
            $scope.CountryObj = new Object();
            $scope.CountryObj.CountryID = 0;
            $scope.CountryObj.IsActive = true;
            $scope.CountryObj.SelectedRegion = [];
        }
    }

    //All initialization Should Be here
    INIT();
});