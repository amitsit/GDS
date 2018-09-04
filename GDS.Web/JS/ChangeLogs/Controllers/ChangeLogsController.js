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
       
        promiseGetChangeLogs.success(function (response) {

            $scope.ChangeLogsData = response.Data;
        
        });
        promiseGetChangeLogs.error(function (data, statusCode) {
        });
    }

    $scope.GoToEditChangeLog = function (ChangeLog, Mode) {   
        $state.go('EditChangeLog', ({ 'MenuId': $scope.MenuId, 'GUID': ChangeLog.GUID, 'UserId': ChangeLog.UserId }));

    }

    $scope.DeleteChangeLog = function (ChangeLogObj) {
    
        //var table = $('#tblContact').DataTable();
        //var row = table.row($($event.target).parents('tr')).data();
      
        bootbox.dialog({
            message: "Do you want to delete a change Log ?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                        
                            var deleteChangeLog = ChangeLogsServices.DeleteChangeLog(ChangeLogObj.GUID, $scope.UserId);
                           
                            deleteChangeLog.success(function (p) {
                               
                                notificationFactory.successDelete();
                                $scope.GetChangeLogs($scope.UserId);
                              
                            });
                            deleteChangeLog.error(function (pl, statusCode) {
                                exceptionService.ShowException(pl, statusCode);
                            });
                        }
                    },
                danger:
                    {
                        label: "No",
                        className: "btn btn-default",
                        callback: function () {
                            return true;
                        }
                    }
            }
        });
    }

    INIT();

  
});