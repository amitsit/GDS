/// <reference path="../../appConfiguration.js" />
/// <reference path="../Services/CountryService.js" />

app.controller('SubProcessListController', function ($scope, $state, localStorageService, $stateParams, SubProcessService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();


    function INIT() {
        $scope.IsEditMode = false;
        
        //$scope.ProcessDisplayType = $rootScope.Enum.ProcessDisplayType.MultiTable;

        //--Check is Page Accessible
        $rootScope.CheckIsPageAccessible("Sub Process", "Sub Process", "View All Sub Process");
        //

        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.ProcessId = parseInt($stateParams.ProcessId);
       $scope.SubProcessId = parseInt($stateParams.SubProcessId);
       $scope.ProcessName = String($stateParams.ProcessName);
        $scope.RegionId = parseInt($stateParams.RegionId);

        if (isNullOrUndefinedOrEmpty($scope.ProcessId)) {
            $scope.ProcessId = 0;
        }
        if (isNullOrUndefinedOrEmpty($scope.SubProcessId)) {
            $scope.SubProcessId = 0;
        }

        if (isNullOrUndefinedOrEmpty($scope.RegionId) || isNaN($scope.RegionId)) {
            $scope.RegionId = $rootScope.Enum.Region.Global;
        }


        //$scope.RegionList = [];
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
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
            $scope.IsActive = false;
                
            $scope.GetSubProcessListByStatus($scope.ProcessId, $scope.RegionId, $scope.UserId, $scope.IsActive);
           
        }
    }

   
    $scope.GetSubProcessListByStatus = function (ProcessId, RegionId, UserId,IsActive)
    {
       
        var promiseGetSubProcessListByStatus = SubProcessService.GetSubProcessListByStatus(ProcessId, RegionId, UserId, IsActive);
        promiseGetSubProcessListByStatus.success(function (response) {
            $scope.SubProcessListData = response.Data;
            BindprocessList();
        });
        promiseGetSubProcessListByStatus.error(function (data, statusCode) {
        });
    }


    function BindprocessList() {
        if ($.fn.DataTable.isDataTable("#tblSubProcess")) {
            $('#tblSubProcess').DataTable().destroy();
        }
     
        $('#tblSubProcess').DataTable({
            data: $scope.SubProcessListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
            "stateSave": true,
            "columns": [
                 //{
                 //    "title": 'Process Name',
                 //    "data": "ProcessName",
                 //    "className": "dt-left",
                 //    "render": function (data, type, row) {
                 //        return data;
                 //    }
                 //},
                    {
                     "title": 'Sub Process Code',
                     "data": "SubProcessCode",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         return data;
                     }
                    },
                    {
                     "title": 'Sub Process Name',
                     "data": "SubProcessName",
                     "className": "dt-left",
                     "render": function (data, type, row) {
                         return data;
                     }
                 },
                                      
               {
                 "title": "Active",
                 "className": "dt-center",
                 "data": "IsActive",
                 "render": function (data, type, row) {
                     return (row.IsActive) ? "Yes" : "No";
                 }
             },

            {
                "title": "Action",
                "data": null,
                "sClass": "action dt-center",
                "sorting": "false",
                "render": function (data, type, row) {       
                    var strAction = '';
                    if ($rootScope.isSubModuleAccessibleToUser('Sub Process', 'Sub Process', 'Add / Update Sub Process')) {
                        strAction = "<a ng-click='EditSubProcess($event)' ><i class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
                    }
                    
                    if ($rootScope.isSubModuleAccessibleToUser('Sub Process', 'Sub Process', 'Delete Sub Process')) {
                    strAction = strAction + "<a ng-click='DeleteSubProcess($event)' ><i  class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
                    } 
                    return strAction;
                }
            }
            ],
            "initComplete": function () {
            },
            "fnDrawCallback": function () {
                BindToolTip();
            },
            "fnCreatedRow": function (nRow, aData, iDataIndex) {
                $compile(angular.element(nRow).contents())($scope);
            }
        });

    }

    $scope.EditSubProcess = function ($event) {
        var table = $('#tblSubProcess').DataTable();
        var row = table.row($($event.target).parents('tr')).data(); 
        $state.go("EditSubProcess", ({ "MenuId": $scope.MenuId, "ProcessId": row.ProcessId, "ProcessName": row.ProcessName, "SubProcessName": row.SubProcessName, "SubProcessId": row.SubProcessId }));
    }

    $scope.DeleteSubProcess = function ($event) {
      
        var table = $('#tblSubProcess').DataTable();
        var row = table.row($($event.target).parents('tr')).data();
        bootbox.dialog({
            message: "Do you want to delete a sub process from region" + ' - ' + row.SubProcessName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteProcess = SubProcessService.DeleteSubProcess(row.ProcessId,row.SubProcessId,$scope.UserId);
                            deleteProcess.success(function (p) {
                                notificationFactory.successDelete();
                                $scope.GetSubProcessListByStatus($scope.ProcessId,$scope.RegionId,$scope.UserId,$scope.IsActive);

                            });
                            deleteProcess.error(function (pl, statusCode) {
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