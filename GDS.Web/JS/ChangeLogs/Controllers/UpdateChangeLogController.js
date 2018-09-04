app.controller('UpdateChangeLogController', function ($scope, $state, localStorageService, $stateParams, ContactUsService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    function INIT() {


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

            //$scope.GetProcesses($scope.MenuId, $scope.IsActive);
        }
       
   

        $scope.GetChangeLogsDetail($scope.GUID, $scope.UserId);
       



    }

   

    $scope.GetChangeLogsDetail = function (UserId) {

        var promiseGetChangeLogs = ChangeLogsServices.GetChangeLogsDetail($scope.GUID,$scope.UserId);

        promiseGetChangeLogs.success(function (response) {

            $scope.ChangeLogsData = response.Data[0];

        });
        promiseGetChangeLogs.error(function (data, statusCode) {
        });
    }
    

    $scope.SaveChangeLog = function (form) {
        form.$submitted = true;
        if (form.$valid) {
            $scope.ContactObj.LoggedInUserId = $scope.LoggedInUserId;

            var saveContact = ContactUsService.SaveChangeLog($scope.UserId);

            saveContact.success(function (response) {

                if (response.Success) {
                    if ($scope.ContactObj.ContactId > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('ContactUS', ({ 'MenuId': $scope.MenuId }));
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });

            saveProcess.error(function (error, statusCode) {
            });
        }
    };


    INIT();


});