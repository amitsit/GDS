/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/CountryService.js" />

app.controller('ProcessController', function ($scope, $state, localStorageService, $stateParams,ProcessService, $rootScope, $location,  notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

   
    
    function INIT() {
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.IsActive = true;
        $scope.MenuName = "";
        if ($scope.MenuId > 0) { 

            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }

          
            $rootScope.SelectedMenuId = $scope.MenuId;

            if ($scope.MenuId == $rootScope.Enum.Process.Processes) {
                $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.List;
            }    
            $scope.GetProcesses($scope.MenuId, $scope.IsActive);
        }
    }

    $scope.GetProcesses = function (MenuId, IsActive) {
        var promiseGetProcesses = ProcessService.GetProcesses(MenuId, IsActive);
        promiseGetProcesses.success(function (response) {          
            $scope.ProcessListData = response.Data;            
        });
        promiseGetProcesses.error(function (data, statusCode) {
        });
    }

    $scope.showEdit = function (IsAdd) {
        if (IsAdd) {
            $state.go('EditProcess', ({ 'MenuId': $scope.MenuId, 'ProcessId': 0 }));

        } else {
            if ($scope.IsEditMode) {
                $scope.IsEditMode = false;
            } else {
                $scope.IsEditMode = true;
            }
           
        }
       
    }
    $scope.GotoProcessDetail = function (SubProcessObj, Mode) {
       
      
        $state.go('SubProcessDetail', ({ 'MenuId': SubProcessObj.MenuId, 'ProcessId': SubProcessObj.ProcessId, 'SubProcessId': SubProcessObj.SubProcessId, 'RegionId': $rootScope.Enum.Region.Global}));

    }

    $scope.GoToEditProcess = function (Processobj,Mode){

        $state.go('EditProcess', ({ 'MenuId': Processobj.MenuId, 'ProcessId': Processobj.ProcessId, 'ProcessName': Processobj.ProcessName}));

    }

    //$scope.GoToSubProcessList = function (SubProcessListobj, Mode) {

    //    $state.go('SubProcessList', ({ 'MenuId': SubProcessListobj.MenuId, 'ProcessId': SubProcessListobj.ProcessId, 'ProcessName': SubProcessListobj.ProcessName, 'RegionId': SubProcessListobj.RegionId }));

    //}



    //$scope.redirectTo = function () {

    //  $location.path='1312412';
        
    //}

    INIT();


});