app.service('CountryService', function ($http, configurationService) {

    var countryService = {};

    countryService.GetCountyList = function () {
        return $http.get(configurationService.basePath + "api/GetCountyList");
    }

    countryService.GetCountyListByRegionId = function (CountryId, RegionId) {
        return $http.get(configurationService.basePath + "api/GetCountyList?CountryId=" + CountryId + "&RegionId=" + RegionId);
    }

    countryService.GetCountryDetail = function (CountryID) {
        return $http.get(configurationService.basePath + "api/GetCountryDetail?CountryID=" + CountryID);
    }

    countryService.GetRegionList = function () {
        return $http.get(configurationService.basePath + "api/GetRegionList");
    }

    countryService.AddOrUpdateCountry = function (UserId, CountryObj) {
        return $http.post(configurationService.basePath + "api/AddOrUpdateCountry?UserId=" + UserId, CountryObj);
    }

    countryService.DeleteCountry = function (countryId) {
        return $http.get(configurationService.basePath + "api/DeleteCountry?countryId=" + countryId);
    }

    return countryService;
});