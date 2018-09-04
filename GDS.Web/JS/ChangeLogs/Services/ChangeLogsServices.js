app.service('ChangeLogsServices', function ($http, configurationService) {

    var ChangeLogsServices = {};

    ChangeLogsServices.GetChangeLogs = function (userId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogs?UserId=" + userId);
    }

    ChangeLogsServices.DeleteChangeLog = function (guId, userId) {
        return $http.get(configurationService.basePath + "api/DeleteChangeLog?GUID=" + guId + "&UserId=" + userId);
    }

    ChangeLogsServices.GetChangeLogsDetail = function (GUID, userId) {
        return $http.get(configurationService.basePath + "api/GetChangeLogsDetail?GUID=" + GUID + "&UserId=" + userId);
    }

    ChangeLogsServices.SaveChangeLog = function (userId,ChangeLogObj) {
        return $http.post(configurationService.basePath + "api/SaveChangeLog?UserId=" + userId,ChangeLogObj);
    }
    
    return ChangeLogsServices;
});