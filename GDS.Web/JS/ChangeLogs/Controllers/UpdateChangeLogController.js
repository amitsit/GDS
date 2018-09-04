app.controller('UpdateChangeLogController', function ($scope, $state, localStorageService, $stateParams, ChangeLogsServices, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
    createDatePicker();

    function INIT() {

        $rootScope.CheckIsPageAccessible("Change Logs", "Change Logs", "Update Change Logs");
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);

        $scope.MenuName = "";
        $scope.GUID = String($stateParams.GUID);

        if ($scope.MenuId > 0) {

            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }

            $rootScope.SelectedMenuId = $scope.MenuId;

            if ($scope.MenuId == $rootScope.Enum.Process.Processes) {
                $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.List;
            }

        }
         
        $scope.GetChangeLogsDetail($scope.GUID, $scope.UserId); 
    }

   

    $scope.GetChangeLogsDetail = function (UserId) {

        var promiseGetChangeLogs = ChangeLogsServices.GetChangeLogsDetail($scope.GUID,$scope.UserId);

        promiseGetChangeLogs.success(function (response) {

            $scope.ChangeLogsData = response.Data[0];
            $scope.date = new Date();
            $scope.ChangeLogsData.CreatedDate = $filter('date')($scope.ChangeLogsData.CreatedDate, $rootScope.GlobalDateFormat);
        });
        promiseGetChangeLogs.error(function (data, statusCode) {
        });
    }
    

    $scope.SaveChangeLog = function (form) {
        form.$submitted = true;
        if (form.$valid) {           
            var PromiseSaveChangeLog = ChangeLogsServices.SaveChangeLog($scope.UserId, $scope.ChangeLogsData);

            PromiseSaveChangeLog.success(function (response) {

                if (response.Success) {
                    if (!isNullOrUndefinedOrEmpty($scope.ChangeLogsData.GUID)) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('ChangeLog', ({ 'MenuId': $scope.MenuId }));
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });

            PromiseSaveChangeLog.error(function (error, statusCode) {
            });
        }
    };


    INIT();


});