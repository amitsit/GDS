app.controller('IndexController', function ($scope, $state, localStorageService, $stateParams, $rootScope, $location, notificationFactory, configurationService, $compile, $filter) {
    decodeParams($stateParams);
    BindToolTip();

    $rootScope.SelectedMenuId ="";


});