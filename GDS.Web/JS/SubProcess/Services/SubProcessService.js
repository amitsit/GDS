app.service('SubProcessService', function ($http, configurationService) {

    var SubProcessService = {};

    SubProcessService.GetSubProcess = function (processId,subProcessId,regionId,userId) {
        return $http.get(configurationService.basePath + "api/GetSubProcess?ProcessId=" + processId + "&SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId);
    }

    SubProcessService.GetSubProcessListByStatus = function (processId, regionId, userId,isActive) {
        return $http.get(configurationService.basePath + "api/GetSubProcessListByStatus?ProcessId=" + processId + "&RegionId=" + regionId + "&UserId=" + userId + "&IsActive=" + isActive);
    }
    SubProcessService.GetProcessDocumentBySubProcessIdAndRegionId = function (subProcessId, regionId, userId,isActive) {
        return $http.get(configurationService.basePath + "api/GetProcessDocumentBySubProcessIdAndRegionId?SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId + "&IsActive=" + isActive);
    }

    SubProcessService.DeleteSubProcessFromRegion = function (subProcessId, regionId, userId) {
        return $http.get(configurationService.basePath + "api/DeleteSubProcessFromRegion?SubProcessId=" + subProcessId + "&RegionId=" + regionId + "&UserId=" + userId );
    }

    SubProcessService.DeleteSubProcess = function (processId,subProcessId, userId) {
        return $http.get(configurationService.basePath + "api/DeleteSubProcess?ProcessId=" + processId + "&SubProcessId=" + subProcessId + "&UserId=" + userId);
    }
    SubProcessService.SaveSubProcessDetail = function (userId,SubProcessobj) {
        return $http.post(configurationService.basePath + "api/SaveSubProcessDetail?UserId=" + userId, SubProcessobj);
    }

    SubProcessService.SaveDocument = function (userId, DocumentObj) {
        return $http.post(configurationService.basePath + "api/SaveDocument?UserId=" + userId, DocumentObj);
    }
    

    SubProcessService.DeleteDocument = function (userId, SubProcessDocumentId) {
        return $http.get(configurationService.basePath + "api/DeleteDocument?UserId=" + userId + "&SubProcessDocumentId=" + SubProcessDocumentId);
    }

    

    return SubProcessService;
});