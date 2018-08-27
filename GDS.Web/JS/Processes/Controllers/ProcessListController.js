app.controller('ProcessListController', function ($scope, $state, localStorageService, $stateParams, ProcessService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();
    
    function INIT(){      
        $scope.UserId = $rootScope.LoginUserDetail.UserId;
        $scope.MenuId = parseInt($stateParams.MenuId);
        $scope.MenuName = "";
       
        if ($scope.MenuId > 0) {

            var MenuObj = $filter('filter')($rootScope.MenuList, { id: parseInt($scope.MenuId) }, true)[0];
            if (!isNullOrUndefinedOrEmpty(MenuObj)) {
                $scope.MenuName = MenuObj.name;
            }
            $rootScope.SelectedMenuId = $scope.MenuId;

            $scope.IsActive = false;
           
            $scope.GetProcessesListByStatus($scope.MenuId, $scope.IsActive);
        }
       
    }
  
    $scope.GetProcessesListByStatus = function (MenuId, IsActive) {
  
        var promiseGetProcessesListByStatus = ProcessService.GetProcessesListByStatus(MenuId, IsActive);
        promiseGetProcessesListByStatus.success(function (response) {
            $scope.ProcessListData = response.Data;
            BindprocessList();
        });
        promiseGetProcessesListByStatus.error(function (data, statusCode) {
        });
    }

    function BindprocessList() {     
        if ($.fn.DataTable.isDataTable("#tblProcess")) {
            $('#tblProcess').DataTable().destroy();
        }

        $('#tblProcess').DataTable({
            data: $scope.ProcessListData,
            "bDestroy": true,
            "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
            "aaSorting": [1, "desc"],
            "aLengthMenu": [10, 20, 50, 100, 200],
            "pageLength": 10,
            "stateSave": true,
            "columns": [
                 {
                     "title": 'Process Name',
                     "data": "ProcessName",
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
                    strAction = "<a><i ui-sref='EditProcess({MenuId:" + $scope.MenuId + ",ProcessId:" + row.ProcessId + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
                    //if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Delete Region')) {
                    strAction = strAction + "<a ng-click='DeleteProcess($event)' ><i  class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
                    //} ng-click='DeleteRegion($event)'
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

    $scope.DeleteProcess = function ($event) {
        var table = $('#tblProcess').DataTable();
        var row = table.row($($event.target).parents('tr')).data();
        bootbox.dialog({
            message: "Do you want to delete a process" + ' - ' + row.ProcessName + "?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                            var deleteProcess = ProcessService.DeleteProcess(row.ProcessId, $scope.UserId);
                            deleteProcess.success(function (p) {
                                notificationFactory.successDelete();
                                $scope.GetProcessesListByStatus($scope.MenuId, $scope.IsActive);
                              
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