app.service('StateService', function ($http, configurationService) {

    var stateService = {};

    stateService.GetStateList = function () {
        return $http.get(configurationService.basePath + "api/GetStateList");
    }
    stateService.AddOrUpdateState = function (UserId, StateObj) {
        return $http.post(configurationService.basePath + "api/AddOrUpdateState?UserId=" + UserId, StateObj);
    }
    stateService.GetStateDetail = function (StateID) {
        return $http.get(configurationService.basePath + "api/GetStateDetail?StateID=" + StateID);
    }

    stateService.GetCountryList = function () {
        return $http.get(configurationService.basePath + "api/GetCountryList");
    }

    stateService.DeleteState = function (StateID) {
        return $http.post(configurationService.basePath + "api/DeleteState?StateID=" + StateID);
    }
    return stateService;
});