app.controller('AddOrUpdateContactUsController', function ($scope, $state, localStorageService, $stateParams, ContactUsService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    function INIT() {
      
        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Contact Us", "Contact Us", "Add / Update Contact Us");
        //
        $scope.IsEditMode = false;
        $scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
       
        $scope.MenuName = "";
        $scope.ContactId = parseInt($stateParams.ContactId);
      
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
        $scope.ContactObj = new Object();
        if ($scope.ContactId > 0) {

            $scope.GetContactUsDetail($scope.ContactId, $scope.UserId);
        } else {
            $scope.ContactObj.MenuId = $scope.MenuId;
            $scope.ContactObj.IsActive = true;
        }
      
   
      
    }

    $scope.GetContactUsDetail = function (ContactId, UserId) {
        var promiseGetContacts = ContactUsService.GetContactUsDetail(ContactId, UserId);
        promiseGetContacts.success(function (response) {
         
            $scope.ContactObj = response.Data[0];
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
            $scope.ContactObj.LoggedInUserId = $scope.LoggedInUserId;

            var saveContact = ContactUsService.SaveContactDetail($scope.UserId, $scope.ContactObj);

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