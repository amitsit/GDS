app.service('SubProcessService', function ($http, configurationService) {

    var SubProcessService = {};

    SubProcessService.GetSubProcess = function (processId,subProcessId,regionId,userId) {
        return $http.get(configurationService.basePath + "api/GetSubProcess?ProcessId=" + processId + "&SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId);
    }

    SubProcessService.GetSubProcessListByStatus = function (processId, subProcessId, regionId, userId,isActive) {
        return $http.get(configurationService.basePath + "api/GetSubProcessListByStatus?ProcessId=" + processId + "&SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId + "@IsActive" + isActive);
    }
    SubProcessService.GetProcessDocumentBySubProcessIdAndRegionId = function (subProcessId, regionId, userId) {
        return $http.get(configurationService.basePath + "api/GetProcessDocumentBySubProcessIdAndRegionId?SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId);
    }

    SubProcessService.DeleteSubProcessFromRegion = function (subProcessId, regionId, userId) {
        return $http.get(configurationService.basePath + "api/DeleteSubProcessFromRegion?SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId );
    }

    SubProcessService.SaveSubProcessDetail = function (userId,SubProcessobj) {
        return $http.post(configurationService.basePath + "api/SaveSubProcessDetail?UserId=" + userId, SubProcessobj);
    }
    
    

    return SubProcessService;
});