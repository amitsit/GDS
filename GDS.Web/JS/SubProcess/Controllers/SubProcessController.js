/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/CountryService.js" />

app.controller('SubProcessController', function ($scope, $state, localStorageService, $stateParams, SubProcessService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
   
    
    function INIT() {
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;

        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.ProcessId = parseInt($stateParams.ProcessId);
        $scope.SubProcessId = parseInt($stateParams.SubProcessId);

        $scope.RegionId = parseInt($stateParams.RegionId);

        if (isNullOrUndefinedOrEmpty($scope.ProcessId)) {
            $scope.ProcessId = 0;
        }

        if (isNullOrUndefinedOrEmpty($scope.SubProcessId)) {
            $scope.SubProcessId = 0;
        }

        if (isNullOrUndefinedOrEmpty($scope.RegionId)) {
            $scope.RegionId = $rootScope.Enum.Region.Global;
        }

        $scope.UserId = $rootScope.LoginUserDetail.UserId;
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
            $scope.GetSubProcess($scope.ProcessId, $scope.SubProcessId, $scope.RegionId, $scope.UserId);
        }
    }

    $scope.GetSubProcess = function (ProcessId, SubProcessId, RegionId, UserId) {
        var promiseGetProcesses = SubProcessService.GetSubProcess(ProcessId, SubProcessId,RegionId ,UserId);
        promiseGetProcesses.success(function (response) {
            if (response.Data.length>0) {
                $scope.SubProcessObj = response.Data[0];
                $scope.GetProcessDocumentBySubProcessIdAndRegionId(SubProcessId, RegionId, UserId);
            }
          
        });
        promiseGetProcesses.error(function (data, statusCode) {
        });
    }

    $scope.GetProcessDocumentBySubProcessIdAndRegionId = function (SubProcessId,RegionId,UserId) {
        var promiseGetProcessDocumentBySubProcessIdAndRegionId = SubProcessService.GetProcessDocumentBySubProcessIdAndRegionId(SubProcessId, RegionId, UserId);
        promiseGetProcessDocumentBySubProcessIdAndRegionId.success(function (response) {
            $scope.ProcessDocuments = response.Data;
        });
        promiseGetProcessDocumentBySubProcessIdAndRegionId.error(function (data, statusCode) {
        });
    }

    $scope.IsEmptyHeader = function () {
        var neefTohide = false;
        if (!isNullOrUndefinedOrEmpty($scope.SubProcessObj))
        {
            if (isNullOrUndefinedOrEmpty($scope.SubProcessObj.SubProcessInput) && isNullOrUndefinedOrEmpty($scope.SubProcessObj.FundamentalOfProcess) && isNullOrUndefinedOrEmpty($scope.SubProcessObj.SubProcessOutput)) {
                var neefTohide = true;
            }
        }
        return neefTohide;
    }


    INIT();


});