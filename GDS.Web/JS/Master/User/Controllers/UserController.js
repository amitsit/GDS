app.controller('UserController', function ($scope, $translate, localStorageService, $stateParams, $rootScope, $location, UserService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    function bindUserList() {

        if ($.fn.DataTable.isDataTable("#tblUser")) {
            $('#tblUser').DataTable().destroy();
        }

        var table = $('#tblUser').DataTable({
            data: $scope.UserList,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": false,
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
            "stateSave": true,
            "columns": [

                  //{

                  //    "className": "dt-center",
                  //    "data": "Email", "bSortable": false,
                  //    'render': function (data, type, full, meta) {
                  //        return '<input type="checkbox" class="individualCheckbox" ng-click="SelectIndividual()" name="id[]"  value="'
                  //           + data + '">';
                  //    }
                  //},

                {
                    "title": ($filter("translate")("Admin_FirstName")),
                    "className": "dt-left",
                    "data": "FirstName"
                },
    {
        "title": ($filter("translate")("Admin_LastName")),
        "className": "dt-left",
        "data": "LastName"
    },
     {
         "title": ($filter("translate")("Admin_NetworkUserId")),
         "className": "dt-left",
         "data": "NetworkUserId"
     },
    {
        "title": "Email",
        "className": "dt-left",
        "data": "Email",
        'render': function (data) {
            return '<a href="mailto:' + $.trim(data) + '">' + data + '</a>';
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
      }
, {
    "title": ($filter("translate")("Admin_Action")),
    "data": null,
    "sClass": "action dt-center",
    "sorting": "false",
    "render": function (data, type, row) {
        var strAction = "<a><i ui-sref='EditUser({UserId:" + row.UserId + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
        return strAction;
    }
}
            ],
            "initComplete": function () {
                var dataTable = $('#tblUser').DataTable();
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

    $scope.SelectAll = function () {
        var table = $('#tblUser').DataTable();
        // Handle click on "Select all" control

        // Check/uncheck all checkboxes in the table
        var rows = table.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', $('#example-select-all').prop('checked'));
        $scope.getAllSelected();
    }

    $scope.SelectIndividual = function () {
        // Handle click on checkbox to set state of "Select all" control
        $('#tblUser tbody').on('change', 'input[type="checkbox"]', function () {
            // If checkbox is not checked
            if (!this.checked) {
                var el = $('#example-select-all').get(0);
                // If "Select all" control is checked and has 'indeterminate' property
                if (el && el.checked && ('indeterminate' in el)) {
                    // Set visual state of "Select all" control 
                    // as 'indeterminate'
                    el.indeterminate = true;
                }
            }
        });
        $scope.getAllSelected();
    }
    //$scope.EmailList = 'mailto:amit.p@shaligraminfotech.com;brijesh@aa.com';
    $scope.getAllSelected = function () {
        $scope.EmailList = '';
        $scope.ShowEmailButton = 0;
        var table = $('#tblUser').DataTable();
        var rows = table.rows({ 'search': 'applied' }).nodes();
        for (var i = 0; i < rows.length; i++) {
            var ele = rows[i];
           
            if (ele.cells[0].firstElementChild.checked) {
                $scope.ShowEmailButton = 1;
                $scope.EmailList += ele.cells[0].firstElementChild.getAttribute('value') + ";";
            }
        }
        
    }

    function getUserData() {
        var promise = UserService.GetUserDetail(0);
        promise.success(function (response) {
            $scope.UserList = response.Data;
            bindUserList();
        });
        promise.error(function (data, statusCode) {
        });
    }

    function init() {
        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "User Quick Links", "View User");
        //
        getUserData();
    }

    init();
});

app.controller('UpdateUserController', function ($scope, localStorageService, $stateParams, $rootScope, RoleService, $state, $location, UserService,notificationFactory, configurationService, $compile, $filter) {

    decodeParams($stateParams);
    BindToolTip();

    $scope.UserID = parseInt($stateParams.UserId);
    $scope.LoggedInUserId = $rootScope.LoginUserDetail.UserId;

    function init() {
        //GetPlantList();

        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Admin", "User Quick Links", "View User");
        //

        $scope.EnumSection = {
            Region: 1,
            Plant: 2,
        };



        GetRoleList();
        if ($scope.UserID > 0) {
            $scope.PageTitle = ($filter("translate")("Admin_EditUser"));
            $scope.GetUserDetail();
        } else {
            $scope.PageTitle = ($filter("translate")("Admin_AddUser"));
            $scope.UserID = 0;
            $scope.UserObj = new Object();
            //$scope.UserObj.SelectedPlant = [];
            $scope.UserObj.IsActive = true;
            $scope.UserObj.RegionIdCsv = "";
            $scope.UserObj.PlantIdCsv = "";

            GetRegionsByUserId();
        }

    }



    function GetRoleList() {
        var promiseGetRoleList = RoleService.GetRoleList($scope.UserID, 0);
        promiseGetRoleList.success(function (response) {
            $scope.RoleList = [];
            $scope.RoleListData = response.Data;

            angular.forEach($scope.RoleListData, function (role, i) {
                if (role.IsActive) {
                    var roleObj = new Object();
                    roleObj.name = role.RoleName;
                    roleObj.id = role.RoleId;
                    $scope.RoleList.push(roleObj);
                }
            });

        });
        promiseGetRoleList.error(function (data, statusCode) {
        });
    }

    //$scope.SelectedPlant = function () {
    //    $scope.PlantNames = '';
    //    for (var i = 0; i < $scope.UserObj.SelectedPlant.length; i++) {
    //        var selectedPlant = $filter('filter')($scope.PlantList, { id: parseInt($scope.UserObj.SelectedPlant[i]) }, true);
    //        if (!isNullOrUndefinedOrEmpty(selectedPlant)) {
    //              $scope.PlantNames = $scope.PlantNames + ($scope.PlantNames == '' ? '' : ',') + selectedPlant[0].name;
    //        }

    //    }
    //}

    $scope.SelectedRoles = function () {
        $scope.RoleNames = '';
        if (!isNullOrUndefinedOrEmpty($scope.UserObj.SelectedRoles) && !isNullOrUndefinedOrEmpty($scope.RoleList)) {
            for (var i = 0; i < $scope.UserObj.SelectedRoles.length; i++) {
                var roleobj = $filter('filter')($scope.RoleList, { id: parseInt($scope.UserObj.SelectedRoles[i]) }, true)[0];
                if (!isNullOrUndefinedOrEmpty(roleobj)) {
                    $scope.RoleNames = $scope.RoleNames + roleobj.name + " , ";
                }

            }
        }

    }

    $scope.GetUserDetail = function () {
        var promiseGetUserData = UserService.GetUserDetail($scope.UserID);
        promiseGetUserData.success(function (response) {
            if (response.Success) {

                $scope.UserObj = response.Data[0];

                if (isNullOrUndefinedOrEmpty($scope.UserObj.RegionIdCsv)) {
                    $scope.IsAllRegionSelected = true;
                    $scope.UserObj.RegionIdCsv = "";
                }
                if (isNullOrUndefinedOrEmpty($scope.UserObj.PlantIdCsv)) {
                    $scope.IsAllPlantSelected = true;
                    $scope.UserObj.PlantIdCsv = "";
                }

                if (!isNullOrUndefinedOrEmpty(response.Data[0].SelectedRoles)) {
                    $scope.UserObj.SelectedRoles = response.Data[0].SelectedRoles.split(',');
                    $scope.SelectedRoles();
                }

                GetRegionsByUserId();
            }

        });
        promiseGetUserData.error(function (data, statusCode) {
        });
    }

    $scope.ValidateReigion = function () {
        var result = true;
        if ((!isNullOrUndefinedOrEmpty($scope.selectedRegions) && $scope.selectedRegions.length > 0) || $scope.IsAllRegionSelected == true) {
            result = false;
        }
        return result;
    }


    $scope.ValidatePlant = function () {
        var result = true;
        if ((!isNullOrUndefinedOrEmpty($scope.selectedRegions) && $scope.selectedPlants.length > 0) || $scope.IsAllPlantSelected == true) {
            result = false;
        }
        return result;
    }


    $scope.SaveUserDetail = function (form) {
        form.$submitted = true;
        if (form.$valid && !$scope.ValidateReigion() && !$scope.ValidatePlant()) {
            $scope.UserObj.LoggedInUserId = $scope.LoggedInUserId;

            //$scope.UserObj.SelectedPlant = $scope.UserObj.SelectedPlant.toString();

            if ($scope.IsAllRegionSelected == true) {
                $scope.UserObj.RegionIdCsv = null;
            } else {
                $scope.UserObj.RegionIdCsv = GetCSVFromJsonArray($scope.selectedRegions, "RegionID");
            }

            if ($scope.IsAllPlantSelected == true) {
                $scope.UserObj.PlantIdCsv = null;
            } else {
                $scope.UserObj.PlantIdCsv = GetCSVFromJsonArray($scope.selectedPlants, "PlantID");
            }

            if (!isNullOrUndefinedOrEmpty($scope.UserObj.SelectedRoles)) {
                $scope.UserObj.SelectedRoles = $scope.UserObj.SelectedRoles.toString();
            } else {
                $scope.UserObj.SelectedRoles = "";
            }


            var saveUser = UserService.SaveUserDetail($scope.UserObj);
            saveUser.success(function (response) {
                if (response.Success) {
                    if ($scope.UserID > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('User');
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });
            saveUser.error(function (error, statusCode) {
            });
        }
    };

    //function GetPlantList() {
    //    var promiseGetPlantData = ProgramService.GetPlantList();
    //    promiseGetPlantData.success(function (response) {
    //        $scope.PlantList = [];
    //        if (response != null && response.Data != null && response.Data.length > 0) {
    //            var plantList = $filter('orderBy')(response.Data, ['PlantName']);
    //            angular.forEach(plantList, function (plant, i) {
    //                var plantObj = new Object();
    //                plantObj.name = plant.PlantName;
    //                plantObj.id = plant.PlantID;
    //                $scope.PlantList.push(plantObj);
    //            });
    //        }      
    //    });
    //    promiseGetPlantData.error(function (data, statusCode) {
    //    });
    //}

    function GetRegionsByUserId() {
        $scope.selectedRegions = [];
        $scope.availableRegions = [];
        $scope.selectedPlants = [];
        $scope.availablePlants = [];
        $scope.UserObj.RegionIdCsv = "";
        $scope.UserObj.PlantIdCsv = "";

        var promiseGetRegionsList = UserService.GetRegionsByUserId($scope.UserID, $scope.LoggedInUserId);
        promiseGetRegionsList.success(function (response) {
            if (response.Success) {
                $scope.AllRegion = response.Data;
                $scope.selectedRegions = $filter('filter')(response.Data, { IsSelected: true }, true);
                $scope.availableRegions = $filter('filter')(response.Data, { IsSelected: false }, true);
                $scope.UserObj.RegionIdCsv = GetCSVFromJsonArray($scope.selectedRegions, "RegionID");
                GetPlantByRegionList();
            }
        });
        promiseGetRegionsList.error(function (data, statusCode) {
        });
    }

    function GetPlantByRegionList() {
        if ($scope.IsAllRegionSelected) {
            $scope.UserObj.RegionIdCsv = GetCSVFromJsonArray($scope.AllRegion, "RegionID");
        }
        else {
            $scope.UserObj.RegionIdCsv = GetCSVFromJsonArray($scope.selectedRegions, "RegionID");
        }

        var promiseGetPlantByRegionList = UserService.GetPlantByRegionList($scope.UserObj.RegionIdCsv, $scope.UserID, $scope.LoggedInUserId);
        promiseGetPlantByRegionList.success(function (response) {
    
            if (response.Success) {
                $scope.selectedPlants = $filter('filter')(response.Data, { IsSelected: true }, true);
                $scope.availablePlants = $filter('filter')(response.Data, { IsSelected: false }, true);
                $scope.UserObj.PlantIdCsv = GetCSVFromJsonArray($scope.selectedPlants, "PlantID");
                if ($scope.IsAllRegionSelected != true && !$scope.selectedRegions.length > 0) {
                    $scope.IsAllPlantSelected = false;
                }

            }
        });
        promiseGetPlantByRegionList.error(function (data, statusCode) {
        });
    }

    $scope.DropDownMoveItem = function (item, from, to, section) {
        for (var i = 0; i < item.length; i++) {
            var idx = from.indexOf(item[i]);
            if (idx != -1) {
                from.splice(idx, 1);
                to.push(item[i]);
            }
        }

        if (section == $scope.EnumSection.Region) {
            GetPlantByRegionList();
        }
    };
    $scope.DropDownMoveItemAll = function (from, to, section) {
        angular.forEach(from, function (item) {
            to.push(item);
        });
        from.length = 0;

        if (section == $scope.EnumSection.Region) {
            GetPlantByRegionList();
        }
    };

    $scope.ChkSectionSelect = function (ChkValue, Section) {
        if (ChkValue == true) {
            switch (Section) {
                case $scope.EnumSection.Region:
                    $scope.UserObj.RegionIdCsv = null;
                    $scope.DropDownMoveItemAll($scope.availableRegions, $scope.selectedRegions, $scope.EnumSection.Region);
                    break;
                case $scope.EnumSection.Plant:
                    $scope.UserObj.PlantIdCsv = null;
                    $scope.DropDownMoveItemAll($scope.availablePlants, $scope.selectedPlants, $scope.EnumSection.Plant);
                    break;
            }
        }
    }


    //#endregion 


    init();

});