app.controller('ContactUsController', function ($scope, $state, localStorageService, $stateParams, ContactUsService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
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
           
    $scope.showEdit = function (IsAdd)
        {
            if (IsAdd) {
                $state.go('EditContactUS', ({ 'MenuId': $scope.MenuId, 'ContactId': 0 }));

            }
            if ($scope.IsEditMode) {
                $scope.IsEditMode = false;
            }
            else
            {
                $scope.IsEditMode = true;
            }
        }



    INIT();


});