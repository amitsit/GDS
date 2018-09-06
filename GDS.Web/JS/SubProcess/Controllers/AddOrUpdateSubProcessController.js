app.controller('AddOrUpdateSubProcessController', function ($scope, $state, localStorageService, $stateParams, $rootScope, SubProcessService, $location, RegionService, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
    createDatePicker();

    function INIT() {

        //--Check is Page Accessible
        if ($rootScope.isSubModuleAccessibleToUser('Sub Process', 'Sub Process', 'Add / Update Sub Process') || $rootScope.isSubModuleAccessibleToUser('Sub Process', 'Document', 'Add / Update Document')) {

        } else {
            $rootScope.CheckIsPageAccessible("Sub Process", "Sub Process", "Add / Update Sub Process");
        }
       
        //

        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.ProcessId = parseInt($stateParams.ProcessId);
        $scope.ProcessName = String($stateParams.ProcessName);
        $scope.SubProcessId = parseInt($stateParams.SubProcessId);
        $scope.SubProcessName = String($stateParams.SubProcessName);

        $scope.RegionId = parseInt($stateParams.RegionId);

        if (isNullOrUndefinedOrEmpty($scope.RegionId) || isNaN($scope.RegionId)) {
            $scope.RegionId = $rootScope.Enum.Region.Global;
        }
               
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
        $scope.RegionList = []; //Assigned Region Array

        $scope.GetSubProcess($scope.ProcessId, $scope.SubProcessId, $scope.RegionId, $scope.UserId);
        $scope.IsActive = false;
    }


    $scope.GetSubProcess = function (ProcessId, SubProcessId, RegionId, UserId) {
        var promiseGetProcesses = SubProcessService.GetSubProcess(ProcessId, SubProcessId, RegionId, UserId);
        promiseGetProcesses.success(function (response) {   
            if (response.Data.length > 0) {
                $scope.SubProcessObj = response.Data[0];      
                if (!isNullOrUndefinedOrEmpty($scope.SubProcessObj.AssignedRegions)) {
                    var RegionsList = $scope.SubProcessObj.AssignedRegions.split(";");

                    for (var i = 0; i < RegionsList.length; i++) {
                        var RegionObj = new Object();
                        RegionObj.RegionId = parseInt(RegionsList[i].split(',')[0]);
                        RegionObj.RegionName = RegionsList[i].split(',')[1];
                        $scope.RegionList.push(RegionObj);
                    }

                } else {
                    $scope.RegionList = [];
                }
                $scope.GetProcessDocumentBySubProcessIdAndRegionId($scope.SubProcessObj.SubProcessId, $scope.SubProcessObj.RegionId, UserId);
            } else {
                $scope.SubProcessObj = new Object();
                $scope.SubProcessObj.ProcessId = $scope.ProcessId;
                $scope.SubProcessObj.RegionId = $scope.RegionId;
                $scope.SubProcessObj.IsActive = true;
            }

        });
        promiseGetProcesses.error(function (data, statusCode) {
        });
    }

    $scope.GetProcessDocumentBySubProcessIdAndRegionId = function (SubProcessId, RegionId, UserId) {
        var promiseGetProcessDocumentBySubProcessIdAndRegionId = SubProcessService.GetProcessDocumentBySubProcessIdAndRegionId(SubProcessId, RegionId, UserId,  $scope.IsActive);
        promiseGetProcessDocumentBySubProcessIdAndRegionId.success(function (response) {
            $scope.ProcessDocuments = response.Data;       
        });
        promiseGetProcessDocumentBySubProcessIdAndRegionId.error(function (data, statusCode) {
        });
    }

    $scope.ChangeRegion = function (regionId) {
        $scope.GetProcessDocumentBySubProcessIdAndRegionId($scope.SubProcessId, regionId,$scope.UserId);
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
            var saveSubProcess = SubProcessService.SaveSubProcessDetail($scope.UserId, $scope.SubProcessObj);
            saveSubProcess.success(function (response) {
                if (response.Success) {
                    if ($scope.SubProcessId > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));                       
                    }
                    $state.transitionTo('EditSubProcess', ({ 'MenuId': $scope.MenuId, 'ProcessId': $scope.ProcessId, 'ProcessName': $scope.ProcessName, 'SubProcessId': response.Data[0].SubProcessId, 'SubProcessName': response.Data[0].SubProcessName }));
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });

            saveSubProcess.error(function (error, statusCode) {
            });
        }
    };

    $scope.DeleteSubProcessFromRegion = function (region) {
     
        bootbox.dialog({
            message: "Do you want to delete all documents from " + ' - ' + region.RegionName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var PromiseDeleteSubProcessFromRegion = SubProcessService.DeleteSubProcessFromRegion($scope.SubProcessObj.SubProcessId, region.RegionId, $scope.UserId);
                            PromiseDeleteSubProcessFromRegion.success(function (p) {
                                notificationFactory.successDelete();                             
                                $state.reload();
                            });
                            PromiseDeleteSubProcessFromRegion.error(function (pl, statusCode) {
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

    $scope.OpenDocumentPopup = function (Document) { 
        $scope.DocumentObj = new Object();
        if (isNullOrUndefinedOrEmpty(Document)) {
            $scope.DocumentObj.DocumentId = 0;
            if (isNullOrUndefinedOrEmpty($scope.SubProcessObj.RegionId)) {
                $scope.DocumentObj.RegionId = $rootScope.Enum.Region.Global;
            } else {
                $scope.DocumentObj.RegionId = $scope.SubProcessObj.RegionId;
            }      
            $scope.date = new Date();
            $scope.DocumentObj.ReleaseDate = $filter('date')($scope.date, $rootScope.GlobalDateFormat);

            $scope.DocumentObj.ProcessId = $scope.ProcessId;
            $scope.DocumentObj.SubProcessId = $scope.SubProcessObj.SubProcessId;
            $scope.DocumentObj.IsActive = true;

        } else {
            $scope.DocumentObj.DocumentId = Document.DocumentId;            
            $scope.DocumentObj.ProcessId = $scope.ProcessId;
            $scope.DocumentObj.SubProcessId = $scope.SubProcessObj.SubProcessId;
            $scope.DocumentObj.RegionId = $scope.SubProcessObj.RegionId;
            $scope.DocumentObj.DocumentCode = Document.DocumentCode;
            $scope.DocumentObj.DocumentTitle = Document.DocumentTitle;
            $scope.DocumentObj.DocumentPath = Document.DocumentPath;
            $scope.DocumentObj.ReleaseDate = $filter('date')(Document.ReleaseDate, $rootScope.GlobalDateFormat);
            $scope.DocumentObj.IsActive = Document.IsActive;
            $scope.DocumentObj.DisplayOrder = Document.DisplayOrder;
        }

        angular.element("#DocumentModelPopup").modal('show');
        
    }

    $scope.SaveDocument = function (form) {
        form.$submitted = true;
        if (form.$valid) {
            var saveSubProcess = SubProcessService.SaveDocument($scope.UserId, $scope.DocumentObj);
            saveSubProcess.success(function (response) {
                if (response.Success) {
                    if ($scope.DocumentObj.DocumentId > 0) {
                        toastr.success($filter("translate")("NtfUpdated"));
                    }
                    else {
                        toastr.success($filter("translate")("NtfAdded"));
                    }

                    angular.element("#DocumentModelPopup").modal('hide');
                    $state.reload();
                    //$scope.GetProcessDocumentBySubProcessIdAndRegionId($scope.SubProcessId, $scope.DocumentObj.RegionId, $scope.UserId);
                    //$state.transitionTo('EditSubProcess', ({ 'MenuId': $scope.MenuId, 'ProcessId': $scope.ProcessId, 'ProcessName': $scope.ProcessName, 'SubProcessId': response.Data[0].SubProcessId, 'SubProcessName': response.Data[0].SubProcessName }));
                }
                else {
                    toastr.error(response.Message[0]);
                }
            });

            saveSubProcess.error(function (error, statusCode) {
            });
        }
    }





    $scope.DeleteDocument = function (document) {

        bootbox.dialog({
            message: "Do you want to delete a document  " + ' - ' + document.DocumentTitle + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var promiseDeleteDocument = SubProcessService.DeleteDocument($scope.UserId, document.SubProcessDocumentId);
                            promiseDeleteDocument.success(function (response) {
                                if (response.Success) {
                                    notificationFactory.successDelete();
                                    $scope.GetProcessDocumentBySubProcessIdAndRegionId($scope.SubProcessObj.SubProcessId, $scope.SubProcessObj.RegionId, $scope.UserId);
                                }
                            });
                            promiseDeleteDocument.error(function (data, statusCode) {
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