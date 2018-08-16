app.controller('RoleConfigurationController', function ($scope, $state, localStorageService, $stateParams, RoleService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();



    INIT();
    //All initialization Should Be here
    function INIT() {
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.RoleId = 0;
        $scope.RoleName = "";
        //collecting changed roles in array
        $scope.collectChangedRoles = [];     
        $scope.RoleId = parseInt($stateParams.RoleId);
        $scope.RoleName = $stateParams.RoleName;
        GetRoleRights();
    }

    function GetRoleRights() {
        var promiseGetRoleDetail = RoleService.GetRoleRights($scope.RoleId,$scope.UserId);
        promiseGetRoleDetail.success(function (response) {   
            $scope.RoleRightsList = response.Data;
        });
        promiseGetRoleDetail.error(function (data, statusCode) {
        });
    }

    //call function when click on one module
    $scope.getSubModules = function (ModuleName) {
        $scope.SelectedModuleName = ModuleName;
    }

    //call function when click on submodule
    $scope.getAccessRights = function (SubmoduleName, ModuleName) {
        $scope.SelectedSubmoduleName = SubmoduleName;
        $scope.SelectedModuleName = ModuleName;
    }

    //click on checkbox pushing and splice element from changed array
    $scope.setSelectedFunctionsForRole = function (changedFunc) {     
        var alreadyAddedOrNotRole = $filter('filter')($scope.collectChangedRoles, { ModuleName: changedFunc.ModuleName, SubmoduleName: changedFunc.SubmoduleName, FunctionName: changedFunc.FunctionName }, true);
        if (alreadyAddedOrNotRole == null || alreadyAddedOrNotRole.length == 0) {
            $scope.collectChangedRoles.push(changedFunc);
        }
        else {
            for (var i = 0; i < $scope.collectChangedRoles.length; i++) {
                if ($scope.collectChangedRoles[i].ModuleName == changedFunc.ModuleName && $scope.collectChangedRoles[i].SubmoduleName == changedFunc.SubmoduleName && $scope.collectChangedRoles[i].FunctionName == changedFunc.FunctionName) {                  
                    $scope.collectChangedRoles[i] = changedFunc;
                }
            }
        }
    };

    $scope.AddOrUpdateRoleConfiguration = function (form) {
        if (form.$valid) {

            var PromiseSaveRoleConfiguration = RoleService.AddOrUpdateRoleConfiguration($scope.UserId, $scope.collectChangedRoles);
            PromiseSaveRoleConfiguration.success(function (response) {        
                if(response.Success)
                {
                    toastr.success($filter("translate")("NtfSaved"));
                    $state.reload();
                }
                else {
                    toastr.error("There is something wrong! Please try again later.");
                }

               
            });

            PromiseSaveRoleConfiguration.error(function (error, statusCode) {
            });
        }
    };

   
});