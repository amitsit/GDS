app.service('UserService', function ($http, configurationService) {

    var userService = [];

    userService.GetUserDetail = function (userId) {
        return $http.get(configurationService.basePath + "api/GetUserDetail?userId=" + userId);
    };

    userService.GetLoginUserDetails = function (networkId) {
        return $http.get(configurationService.basePath + "api/GetLoginUserDetails?networkId=" + networkId);
    };

    userService.SaveUserDetail = function (UserObj) {
        return $http.post(configurationService.basePath + "api/SaveUserDetail", UserObj);
    };
    userService.GetRegionsByUserId = function (UserID,LoggedInUserId) {
        return $http.get(configurationService.basePath + "api/GetRegionsByUserId?UserId=" + UserID + "&LoggedInUserId=" + LoggedInUserId);
    };

    userService.GetPlantByRegionList = function (RegionsCSV, UserID, LoggedInUserId) {
        return $http.get(configurationService.basePath + "api/GetPlantByRegionList?Regions=" + RegionsCSV + "&UserId=" + UserID + "&LoggedInUserId=" + LoggedInUserId);
    };

    

    return userService;
});