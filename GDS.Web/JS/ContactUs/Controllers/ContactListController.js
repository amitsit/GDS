app.controller('ContactListController', function ($scope, $state, localStorageService, $stateParams, ContactUsService, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
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
           
            $scope.GetContactListByStatus($scope.MenuId, $scope.UserId, $scope.IsActive);
          
        }
      
    }
  
    $scope.GetContactListByStatus = function (MenuId,UserId,IsActive) {
    
        var promiseGetContactListByStatus = ContactUsService.GetContactListByStatus(MenuId, UserId, IsActive);
     
        promiseGetContactListByStatus.success(function (response) {
          
            $scope.ContactListData = response.Data;
            //BindContactList();
        });
        promiseGetContactListByStatus.error(function (data, statusCode) {
        });
    }

    //function BindContactList() {
    //    if ($.fn.DataTable.isDataTable("#tblContact")) {
    //        $('#tblContact').DataTable().destroy();
    //    }

    //    $('#tblContact').DataTable({
    //        data: $scope.ContactListData,
    //        "bDestroy": true,
    //        "dom": '<"top"f><"table-responsive"rt><"bottom"lip<"clear">>',
    //        "aaSorting": [1, "desc"],
    //        "aLengthMenu": [10, 20, 50, 100, 200],
    //        "pageLength": 10,
    //        "stateSave": true,
    //        "columns": [
    //             {
    //                 "title": 'Contact Detail',
    //                 "data":'ContactDetail'
    //                 //"render": function (data, type, row) {                    
    //                 //    return "<div ng-bind-html="+ row.ContactDetail+ ">''</div>";
    //                 //}
    //             },
    //         {
    //             "title": "Active",
    //             "className": "dt-center",
    //             "data": "IsActive",
    //             "render": function (data, type, row) {
    //                 return (row.IsActive) ? "Yes" : "No";
    //             }
    //         },
          
    //        {
    //            "title": "Action",
    //            "data": null,
    //            "sClass": "action dt-center",
    //            "sorting": "false",
    //            "render": function (data, type, row) {
    //                var strAction = '';                  
    //                strAction = "<a><i ui-sref='EditContactUS({MenuId:" + $scope.MenuId + ",ContactId:" + row.ContactId + "})' class='glyphicon glyphicon-pencil  cursor-pointer' data-original-title='Edit' data-toggle='tooltip'></i></a>";
    //                //if ($rootScope.isSubModuleAccessibleToUser('Admin', 'Location Quick Links', 'Delete Region')) {
    //                strAction = strAction + "<a ng-click='DeleteContact($event)' ><i  class='glyphicon glyphicon-trash cursor-pointer' data-original-title='Delete' data-toggle='tooltip'></i></a>";
    //                //} ng-click='DeleteRegion($event)'
    //                return strAction;
    //            }
    //        }
    //        ],
    //        "initComplete": function () {
    //        },
    //        "fnDrawCallback": function () {
    //            BindToolTip();               
    //        },
    //        "fnCreatedRow": function (nRow, aData, iDataIndex) {
    //            $compile(angular.element(nRow).contents())($scope);
    //        }
    //    });
      

    //}

    $scope.DeleteContact = function (contactObj) {
    
        //var table = $('#tblContact').DataTable();
        //var row = table.row($($event.target).parents('tr')).data();
      
        bootbox.dialog({
            message: "Do you want to delete a Contact ?",
            title: "Confirmation",
            className: "model",
            buttons: {
                success:
                    {
                        label: "Yes",
                        className: "btn btn-primary theme-btn",
                        callback: function () {
                        
                            var deleteProcess = ContactUsService.DeleteContact(contactObj.ContactId, $scope.UserId);
                          
                            deleteProcess.success(function (p) {
                               
                                notificationFactory.successDelete();
                                $scope.GetContactListByStatus($scope.MenuId,$scope.UserId ,$scope.IsActive);
                              
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