app.controller('SearchListController', function ($scope, $state, localStorageService, $stateParams,SearchService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();


    function INIT() {
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);

        if ($scope.MenuId > 0) {

            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }
            $rootScope.SelectedMenuId = $scope.MenuId;
        }
        $scope.PreviousSearchText = "";

    }

    $scope.SearchText = function (form) {
        form.$submitted = true;
        if (form.$valid) {
            var promiseSearchText = SearchService.SearchText($scope.MenuId,$scope.txtSearch, $scope.UserId);
            promiseSearchText.success(function (response) {
                $scope.PreviousSearchText = $scope.txtSearch;
                $scope.SearchListData = response.Data;
            });
            promiseSearchText.error(function (data, statusCode) {
            });
        }
    };

    INIT();

});