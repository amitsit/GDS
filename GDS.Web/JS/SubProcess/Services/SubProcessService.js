app.service('SubProcessService', function ($http, configurationService) {

    var SubProcessService = {};

    SubProcessService.GetSubProcess = function (processId,subProcessId,regionId,userId) {
        return $http.get(configurationService.basePath + "api/GetSubProcess?ProcessId=" + processId + "&SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId);
    }


    SubProcessService.GetProcessDocumentBySubProcessIdAndRegionId = function (subProcessId, regionId, userId) {
        return $http.get(configurationService.basePath + "api/GetProcessDocumentBySubProcessIdAndRegionId?SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId);
    }

    
 

    return SubProcessService;
});