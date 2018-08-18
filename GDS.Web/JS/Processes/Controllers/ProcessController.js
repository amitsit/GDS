/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/CountryService.js" />

app.controller('ProcessController', function ($scope, $state, localStorageService, $stateParams,ProcessService, $rootScope, $location,  notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    function INIT() {

        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;

        $scope.MenuId = parseInt($stateParams.MenuId);
        if ($scope.MenuId > 0) {

            $rootScope.SelectedMenuId = $scope.MenuId;

            if ($scope.MenuId == $rootScope.Enum.Process.Processes) {
                $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.List;
            }    
            $scope.GetProcesses($scope.MenuId);
        }

    }

    $scope.GetProcesses = function (MenuId) {
        var promiseGetProcesses = ProcessService.GetProcesses(MenuId);
        promiseGetProcesses.success(function (response) {   
            $scope.ProcessListData = response.Data;            
        });
        promiseGetProcesses.error(function (data, statusCode) {
        });
    }


    INIT();



});