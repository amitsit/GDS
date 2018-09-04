app.controller('AddOrUpdateProcessController', function ($scope, $state, localStorageService, $stateParams, $rootScope,ProcessService, $location,RegionService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    var RegionType = {
        Global: "-1",
        Other: "1"
    };

    function INIT() {
        

        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Process", "Process", "Add / Update Process");
        //

        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.ProcessId = parseInt($stateParams.ProcessId);
        $scope.ProcessName = String($stateParams.ProcessName);
        if (isNullOrUndefinedOrEmpty($scope.ProcessName)) {
            $scope.ProcessName = "";
        }

        if ($scope.MenuId > 0) {

            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }
            $rootScope.SelectedMenuId = $scope.MenuId;
        }


        $scope.MasterMenuList = [
                          //{ id: 1, name: "Home" },
                          { id: 3, name: "Management Processes" },
                          { id: 2, name: "Core Processes" },                      
                          { id: 4, name: "Supporting Process" },
                          //{ id: 5, name: "Processes" }
                       
        ];
     
        $scope.ProcessObj = new Object();
        if ($scope.ProcessId > 0) {          
            $scope.GetProcessOrSubProcessListByProcessId($scope.MenuId, $scope.ProcessId, $scope.UserId);         
        } else {
            $scope.ProcessObj.MenuId = $scope.MenuId;
            $scope.ProcessObj.IsActive = true;
        }

        GetRegionList();
        
    }
   

    $scope.GetProcessOrSubProcessListByProcessId = function (MenuId, ProcessId, UserId) {
      
        var promiseGetProcessListById = ProcessService.GetProcessOrSubProcessListByProcessId(MenuId, ProcessId, UserId);
        promiseGetProcessListById.success(function (response) {      
            $scope.ProcessObj = response.Data[0];
            if ($scope.ProcessObj.SelectedRegion=="-1") {
                $scope.ProcessObj.RegionType = RegionType.Global;
                $scope.ProcessObj.SelectedRegion = [];
            } else {
                if (!isNullOrUndefinedOrEmpty(response.Data[0].SelectedRegion)) {
                    $scope.ProcessObj.SelectedRegion = response.Data[0].SelectedRegion.split(',');
                    if ($scope.ProcessObj.SelectedRegion.length>0) {
                        $scope.ProcessObj.RegionType = RegionType.Other;
                    }
                    $scope.SelectedRegion();
                } else {
                    $scope.ProcessObj.SelectedRegion = [];
                } 
            }
           

        });
        promiseGetProcessListById.error(function (data, statusCode) {
        });
    }


    function GetRegionList() {
        var promiseGetRegionData = RegionService.GetRegionList();
        promiseGetRegionData.success(function (response) {
            $scope.RegionListData = response.Data;
            $scope.RegionList = [];        
            angular.forEach($scope.RegionListData, function (Region, i) {
                if (Region.IsActive && Region.RegionID!=-1) {
                    var RegionObj = new Object();
                    RegionObj.name = Region.RegionName;
                    RegionObj.id = Region.RegionID;
                    $scope.RegionList.push(RegionObj);
                }
            });
        });
        promiseGetRegionData.error(function (data, statusCode) {
        });
    }

    $scope.SelectedRegion = function () {
        $scope.RegionNames = '';
        if (!isNullOrUndefinedOrEmpty($scope.ProcessObj.SelectedRegion) && !isNullOrUndefinedOrEmpty($scope.RegionList)) {
            for (var i = 0; i < $scope.ProcessObj.SelectedRegion.length; i++) {
             
                var RegionObj = $filter('filter')($scope.RegionList, { id: parseInt($scope.ProcessObj.SelectedRegion[i]) }, true)[0];
                if (!isNullOrUndefinedOrEmpty(RegionObj)) {
                    $scope.RegionNames = $scope.RegionNames + RegionObj.name + " , ";
                }

            }
        }

    }

    //$scope.AddSubprocess = function () {
    //    alert('Under maintenance');
        
    //}
 
    $scope.SaveProcessDetail = function (form) {
      
        form.$submitted = true;
        if (form.$valid) {
            $scope.ProcessObj.LoggedInUserId = $scope.LoggedInUserId;

            //$scope.UserObj.SelectedPlant = $scope.UserObj.SelectedPlant.toString();

            //if ($scope.ProcessObj.RegionType == RegionType.Global)
            //{
            //    $scope.ProcessObj.SelectedRegion = RegionType.Global;
            //} else {
            //    if (!isNullOrUndefinedOrEmpty($scope.ProcessObj.SelectedRegion)) {
            //        $scope.ProcessObj.SelectedRegion = $scope.ProcessObj.SelectedRegion.toString();
            //    } else {
            //        $scope.ProcessObj.SelectedRegion = "";
            //    }
            //}
           $scope.ProcessObj.SelectedRegion = RegionType.Global
        
            var saveProcess = ProcessService.SaveProcessDetail($scope.UserId, $scope.ProcessObj);
        
            saveProcess.success(function (response) {
                if (response.Success) {
                    if ($scope.ProcessObj.ProcessId> 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                          $state.transitionTo('Process',({'MenuId':$scope.ProcessObj.MenuId}));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                        $state.transitionTo('Process', ({ 'MenuId': $scope.ProcessObj.MenuId, 'ProcessId': response.InsertedId }));
                        
                    }
                  
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