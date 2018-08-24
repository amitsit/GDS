app.service('ProcessService', function ($http, configurationService) {

    var ProcessService = {};

    ProcessService.GetProcesses = function (menuId,isActive) {
        return $http.get(configurationService.basePath + "api/GetProcesses?MenuId=" + menuId + "&IsActive=" + isActive);
    }

    ProcessService.GetProcessesListByStatus = function (menuId, isActive) {
        return $http.get(configurationService.basePath + "api/GetProcessesListByStatus?MenuId=" + menuId + "&IsActive=" + isActive);
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

    ProcessService.DeleteProcess = function (ProcessId,UserId) {
        return $http.get(configurationService.basePath + "api/DeleteProcess?ProcessId=" + ProcessId + "&UserId=" + UserId);
    }
    

    return ProcessService;
});