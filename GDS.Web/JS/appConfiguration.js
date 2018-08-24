/// <reference path="../Templates/Inbox/Inbox.html" />
/// <reference path="../Templates/Inbox/Inbox.html" />

'use strict';



var app = angular.module("IACBI", ["ui.router", "LocalStorageModule", "ngFileUpload", "ngSanitize", "rzModule", "textAngular", "pascalprecht.translate", "swxSessionStorage", "angular.filter", "datatables", "angularUtils.directives.dirPagination","angucomplete-alt"]);
//app.factory("ShareData", function () {
//    return { value: 0 };
//});

//app.config(function (localStorageServiceProvider) {
//    localStorageServiceProvider
//      .setStorageType('localStorage');

//}); 

app.config(function ($stateProvider, $urlRouterProvider, $locationProvider, $translateProvider) {
    

    $stateProvider.state({
        name: 'Home',
        url: '/Home',
        templateUrl: '/Templates/Home/Index.html'
    });


   $stateProvider.state({
       name: 'Home1',
        url: '/Home1',
        //templateUrl: '/Templates/Home/Index.html'
        templateUrl: '/Templates/Home/ContentTestPage.html'
       
    });

   $stateProvider.state({
       name: 'Home2',
       url: '/Home2',    
       templateUrl: '/Templates/Home/ContentTestPage1.html'

   });
   $stateProvider.state({
       name: 'Home3',
       url: '/Home3', 
       templateUrl: '/Templates/Home/ContentTestPage2.html'
   });

   $stateProvider.state({
       name: 'Master',
       url: '/Master',
       templateUrl: '/Templates/Master/Admin_Links/Index.html'
   });

   $stateProvider.state({
       name: 'Region',
       url: '/Region',
       templateUrl: '/Templates/Master/Region/Index.html'
   });

   $stateProvider.state({
       name: 'AddRegion',
       url: '/AddRegion?RegionID',
       templateUrl: '/Templates/Master/Region/AddOrEditRegion.html'
   });

   $stateProvider.state({
       name: 'EditRegion',
       url: '/EditRegion?RegionID',
       templateUrl: '/Templates/Master/Region/AddOrEditRegion.html'
   });

   $stateProvider.state({
       name: 'Roles',
       url: '/Roles',
       templateUrl: '/Templates/Master/Role/Index.html'
   });

   
   $stateProvider.state({
       name: 'AddRole',
       url: '/AddRole?RoleId',
       templateUrl: '/Templates/Master/Role/AddOrUpdateRole.html'
   });

    $stateProvider.state({
        name: 'EditRole',
        url: '/EditRole?RoleId',
        templateUrl: '/Templates/Master/Role/AddOrUpdateRole.html'
    });

    $stateProvider.state({
        name: 'RoleConfiguration',
        url: '/RoleConfiguration?RoleId&RoleName',
        templateUrl: '/Templates/Master/Role/RoleConfiguration.html'
    });

    $stateProvider.state({
        name: 'State',
        url: '/State',
        templateUrl: '/Templates/Master/State/Index.html'
    });

    $stateProvider.state({
        name: 'AddState',
        url: '/AddState?StateID',
        templateUrl: '/Templates/Master/State/AddOrEditState.html'
    });

    $stateProvider.state({
        name: 'EditState',
        url: '/EditState?StateID',
        templateUrl: '/Templates/Master/State/AddOrEditState.html'
    });
 
    $stateProvider.state({
        name: 'User',
        url: '/User',
        templateUrl: '/Templates/Master/User/Index.html'
    });

    $stateProvider.state({
        name: 'EditUser',
        url: '/EditUser?UserId',
        templateUrl: '/Templates/Master/User/EditUser.html'
    });


    $stateProvider.state({
        name: 'Process',
        url: '/Process?MenuId',
        templateUrl: '/Templates/Processes/Index.html'
    });


    $stateProvider.state({
        name: 'SubProcessDetail',
        url: '/SubProcessDetail?MenuId&ProcessId&&SubProcessId&RegionId',
        templateUrl: '/Templates/SubProcess/Index.html'
    });
    $stateProvider.state({
        name: 'EditProcess',
        url: '/EditProcess?MenuId&ProcessId',
        templateUrl: '/Templates/Processes/AddOrUpdateProcess.html'
    });

    $stateProvider.state({
        name: 'ProcessList',
        url: '/ProcessList?MenuId',
        templateUrl: '/Templates/Processes/ProcessList.html'
    });


    //any url that doesn't exist in routes redirect to '/'
    $urlRouterProvider.otherwise('/Home');

    //$locationProvider.html5Mode({
    //    enabled: true,
    //    requireBase: false
    //});
    $locationProvider.html5Mode(true);

    //$translateProvider.translations('en',
    //    {
    //    'lblTest':'TestLabel'
    //    })
    //.translations('sp',
    //{
    //    'lblTest': 'TestLabel-Spanish'
    //})   
    //.preferredLanguage('en');

    $translateProvider.useStaticFilesLoader({
        prefix: 'ResourceFiles/lang_',
        suffix: '.json'
    })
        .preferredLanguage('en')
        .useMissingTranslationHandlerLog();

    $translateProvider.useSanitizeValueStrategy('escapeParameters');

})
    .run(function ($http, $rootScope, $location, $filter, $state, $stateParams, localStorageService, $translate, $templateCache, $sessionStorage) {

        $rootScope.$state = $state;
 
        $rootScope.GlobalDateFormat = 'dd-MMM-yyyy';//'MM/dd/yyyy';

        $rootScope.$on('$viewcontentloaded', function () {
            $templatecache.removeall();
           
        });
            
        $rootScope.MenuList = [
                                { id: 1, name: "Home" },
                                { id: 2, name: "Core Processes" },
                                { id: 3, name: "Management Processes" },
                                { id: 4, name: "Supporting Process" },
                                { id: 5, name: "Processes" },
                                { id: 6, name: "Document Logs" },
                                { id: 7, name: "Contact Us" },
                                 { id: 8, name: "Search" },
     
        ];

      
        $rootScope.isSubModuleAccessibleToUser = function (module, subModule, func) {    
            var IsAccessible = false;
            if ($rootScope.UserRoleRightsList.length>0) {
                var Obj = $filter('filter')($rootScope.UserRoleRightsList, { ModuleName: module, SubmoduleName: subModule, FunctionName: func }, true).length >= 1;
                if(Obj)
                {
                    IsAccessible = true;
                }
            }
            return IsAccessible;
        }

        $rootScope.CheckIsPageAccessible = function (module, subModule, func) {
            if (!$rootScope.isSubModuleAccessibleToUser(module, subModule, func)) {
                window.location.href = '/AccessDenied';
            }          
        }

        $rootScope.RedirectsTOAccessDenied = function (NeedToRedirect) {
            if (NeedToRedirect) {
                window.location.href = '/AccessDenied';
            }
        }

        $rootScope.RemoveAllFromLocalStorage_StartWith = function (startWith) {
            var CmpStrLength=0;

            if (isNullOrUndefinedOrEmpty(startWith))
            {
                CmpStrLength = 0;
            } else {
                CmpStrLength = startWith.length;
            }
            if (CmpStrLength > 0) {
                if (localStorage.length > 0) {
                    var arr = []; // Array to hold the keys
                    // Iterate over localStorage and insert the keys that meet the condition into arr
                    for (var i = 0; i < localStorage.length; i++) {
                        if (localStorage.key(i).substring(0, 3) == startWith) {
                            arr.push(localStorage.key(i));
                        }
                    }

                    // Iterate over arr and remove the items by key
                    for (var i = 0; i < arr.length; i++) {
                        localStorage.removeItem(arr[i]);
                    }
                }
            }

        }




        // Redirect to login if route requires auth and you're not logged in
        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            //if ($rootScope.IdentifyUnsavedData != undefined && $rootScope.IdentifyUnsavedData != null) {
            //    var IsUnsaved = $rootScope.IdentifyUnsavedData();
            //    if (IsUnsaved) {
            //        if (!confirm("You have changes that have not been submitted. Are you sure you want to leave this page?")) {
            //            event.preventDefault();
            //        }
            //        else {
            //            $rootScope.IdentifyUnsavedData = null;
            //        }
            //    }
            //}



            $state.previous = fromState;
            $state.previousParams = fromParams;
            //if (fromState.name != "") {
            //    localStorageService.remove("previous");
            //    localStorageService.set("previous", $state.previous);
            //    localStorageService.remove("previousParams");
            //    localStorageService.set("previousParams", $state.previousParams);
            //}
            if (!(fromParams == toParams)) {
                //encodeParams(toParams);

            }
            // to track previous url
            $state.previousHref = $state.href(fromState, fromParams);

            //check for user authentication         
            //if ($rootScope.CurrentUser() == null && toState.authenticate == true) {
            //    $state.transitionTo('Home');
            //}

            // check for authorization
            //////////////////////
            //if (typeof (toState) !== "undefined") {
            //    $templateCache.remove(toState.templateUrl);
            //}
            event.targetScope.$watch('$viewContentLoaded', function () {
                
                //$rootScope.EnableTextSelection();
            })

        });



    });

