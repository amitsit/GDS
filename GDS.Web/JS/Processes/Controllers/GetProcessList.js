app.controller('GetProcessListController', function ($scope, $state, localStorageService, $stateParams, ProcessService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();


    function INIT() {
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;

        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.IsActive = false;



    }

    $scope.GetProcessesListByStatus = function (MenuId, IsActive) {
        var promiseGetProcesses = ProcessService.GetProcesses(MenuId, IsActive);
        promiseGetProcesses.success(function (response) {
            $scope.ProcessListData = response.Data;
        });
        promiseGetProcesses.error(function (data, statusCode) {
        });
    }





});