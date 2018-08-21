app.service('ProcessService', function ($http, configurationService) {

    var ProcessService = {};

    ProcessService.GetProcesses = function (menuId) {
        return $http.get(configurationService.basePath + "api/GetProcesses?MenuId=" + menuId);
    }


    ProcessService.GetSubProcesses = function (processId) {
        return $http.get(configurationService.basePath + "api/GetSubProcesses?ProcessId=" + processId);
    }

    
 

    return ProcessService;
});