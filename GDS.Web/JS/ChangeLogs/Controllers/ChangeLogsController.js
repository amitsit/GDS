app.controller('ChangeLogsController', function ($scope, $state, localStorageService, $stateParams, ChangeLogsServices, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
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
              
           $scope.GetChangeLogs($scope.UserId);
        }
    }
    $scope.GetChangeLogs = function (UserId) {
      
        var promiseGetChangeLogs = ChangeLogsServices.GetChangeLogs($scope.MenuId);
        debugger;
        promiseGetChangeLogs.success(function (response) {

            $scope.ChangeLogsData = response.Data;
            debugger;
        });
        promiseGetChangeLogs.error(function (data, statusCode) {
        });
    }



    INIT();

  
});