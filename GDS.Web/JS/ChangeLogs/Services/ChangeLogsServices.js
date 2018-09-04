app.service('ChangeLogsServices', function ($http, configurationService) {

    var ChangeLogsServices = {};

    ChangeLogsServices.GetChangeLogs = function (userId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogs?UserId=" + userId);
    }

    ChangeLogsServices.DeleteChangeLog = function (guId, userId) {
        return $http.get(configurationService.basePath + "api/DeleteChangeLog?GUID=" + guId + "&UserId=" + userId);
    }

    ChangeLogsServices.GetChangeLogsDetail = function (contactId, userId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogsDetail?GUID=" + guId + "&UserId=" + userId);
    }
    
    return ChangeLogsServices;
});