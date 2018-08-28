app.controller('AddOrUpdateContactUsController', function ($scope, $state, localStorageService, $stateParams, ContactUsService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    function INIT() {
     
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;

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
              
            //$scope.GetProcesses($scope.MenuId, $scope.IsActive);
        }

        $scope.GetContacts(0, 1);
    }

    $scope.GetContacts = function (ContactId, UserId) {
        var promiseGetContacts = ContactUsService.GetContactUs(ContactId, UserId);
        promiseGetContacts.success(function (response) {
            $scope.ContactListData = response.Data;
        });
        promiseGetContacts.error(function (data, statusCode) {
        });
    }


  
    //$scope.showEdit = function () {
       
    //        if ($scope.IsEditMode) {
    //            $scope.IsEditMode = false;
    //        } else {
    //            $scope.IsEditMode = true;
    //        }
           
    //$scope.showEdit = function (IsAdd)
    //    {
    //        if (IsAdd) {
    //            $state.go('EditContactUS', ({ 'MenuId': $scope.MenuId, 'ContactId': 0 }));

    //        }
    //        if ($scope.IsEditMode) {
    //            $scope.IsEditMode = false;
    //        }
    //        else
    //        {
    //            $scope.IsEditMode = true;
    //        }
    //    }


    $scope.SaveContactDetail = function (form) {

        form.$submitted = true;
        if (form.$valid) {
            $scope.ProcessObj.LoggedInUserId = $scope.LoggedInUserId;

            //$scope.UserObj.SelectedPlant = $scope.UserObj.SelectedPlant.toString();

            if ($scope.ProcessObj.RegionType == RegionType.Global) {
                $scope.ProcessObj.SelectedRegion = RegionType.Global;
            } else {
                if (!isNullOrUndefinedOrEmpty($scope.ProcessObj.SelectedRegion)) {
                    $scope.ProcessObj.SelectedRegion = $scope.ProcessObj.SelectedRegion.toString();
                } else {
                    $scope.ProcessObj.SelectedRegion = "";
                }
            }


            var saveProcess = ProcessService.SaveProcessDetail($scope.UserId, $scope.ProcessObj);

            saveProcess.success(function (response) {
                if (response.Success) {
                    if ($scope.ProcessObj.ProcessId > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }
                    $state.transitionTo('Process', ({ 'MenuId': $scope.ProcessObj.MenuId }));
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