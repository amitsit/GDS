app.service('ProcessService', function ($http, configurationService) {

    var ProcessService = {};

    ProcessService.GetProcesses = function (menuId) {
        return $http.get(configurationService.basePath + "api/GetProcesses?MenuId=" + menuId);
    }


    ProcessService.GetSubProcesses = function (processId) {
        return $http.get(configurationService.basePath + "api/GetSubProcesses?ProcessId=" + processId);
    }

    ProcessService.GetProcessOrSubProcessListByProcessId = function (menuId,processId,userId) {
        return $http.get(configurationService.basePath + "api/GetProcessOrSubProcessListByProcessId?MenuId=" + menuId + "&ProcessId=" + processId + "&UserId=" + userId);
    }

    ProcessService.SaveProcessDetail = function (UserId, ProcessObj) {
        return $http.post(configurationService.basePath + "api/SaveProcessDetail?UserId=" + UserId, ProcessObj);
    }

    return ProcessService;
});