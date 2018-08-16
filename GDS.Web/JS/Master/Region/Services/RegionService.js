app.service('RegionService', function ($http, configurationService) {

    var regionService = {};

    regionService.GetRegionList = function () {
        return $http.get(configurationService.basePath + "api/Region/GetRegionList");
    }

    regionService.GetRegionDetail = function (RegionID) {
        return $http.get(configurationService.basePath + "api/Region/GetRegionDetail?RegionID=" + RegionID);
    }

    regionService.AddOrUpdateRegion = function (UserId, RegionObj) {
        return $http.post(configurationService.basePath + "api/Region/AddOrUpdateRegion?UserId=" + UserId, RegionObj);
    }

    regionService.DeleteRegion = function (RegionID) {
        
        return $http.post(configurationService.basePath + "api/Region/DeleteRegion?RegionID=" + RegionID);
    }

    return regionService;
});