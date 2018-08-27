app.controller('AddOrUpdateSubProcessController', function ($scope, $state, localStorageService, $stateParams, $rootScope, SubProcessService, $location, RegionService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    var RegionType = {
        Global: "-1",       
    };

 

    function INIT() {
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.ProcessId = parseInt($stateParams.ProcessId);
        $scope.ProcessName = String($stateParams.ProcessName);
        $scope.SubProcessId = parseInt($stateParams.SubProcessId);
        $scope.SubProcessName = String($stateParams.SubProcessName);
               
        if (isNullOrUndefinedOrEmpty($scope.ProcessName)) {
            $scope.ProcessName = "";
        }
        if (isNullOrUndefinedOrEmpty($scope.SubProcessName)) {
            $scope.SubProcessName = "";
        }

        $scope.MenuName = "";
        if ($scope.MenuId > 0) {
            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }
            $rootScope.SelectedMenuId = $scope.MenuId;
        }
        

        GetRegionList();



        GetSubProcessDetail($scope.SubProcessId,);

    }


    function GetSubProcessDetail() {
        var promiseGetSubProcessDetail = SubProcessService.GetSubProcessDetail();
        promiseGetSubProcessDetail.success(function (response) {
            $scope.SubProcessDetails = response.Data[0];

        });
        promiseGetSubProcessDetail.error(function (data, statusCode) {
        });
    }


    function GetRegionList() {
        var promiseGetRegionData = RegionService.GetRegionList();
        promiseGetRegionData.success(function (response) {
            $scope.RegionListData = response.Data;

        });
        promiseGetRegionData.error(function (data, statusCode) {
        });
    }


    $scope.SaveSubProcessDetail = function (form) {
        form.$submitted = true;
        if (form.$valid) {           
            var saveSubProcess = SubProcessService.SaveSubProcessDetail($scope.UserId, $scope.ProcessObj);

            saveSubProcess.success(function (response) {
                if (response.Success) {
                   
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });

            saveSubProcess.error(function (error, statusCode) {
            });
        }
    };



    INIT();
});