app.service('ChangeLogsServices', function ($http, configurationService) {

    var ChangeLogsServices = {};

    ChangeLogsServices.GetChangeLogs = function (menuId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogs?MenuId=" + menuId);
    }
    
    return ChangeLogsServices;
});