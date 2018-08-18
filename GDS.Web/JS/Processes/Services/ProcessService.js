app.service('ProcessService', function ($http, configurationService) {

    var ProcessService = {};

    ProcessService.GetProcesses = function (menuId) {
        return $http.get(configurationService.basePath + "api/GetProcesses?MenuId=" + menuId);
    }

 

    return ProcessService;
});