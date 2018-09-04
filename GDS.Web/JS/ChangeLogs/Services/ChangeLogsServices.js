app.service('ChangeLogsServices', function ($http, configurationService) {

    var ChangeLogsServices = {};

    ChangeLogsServices.GetChangeLogs = function (userId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogs?UserId=" + userId);
    }
    
    return ChangeLogsServices;
});