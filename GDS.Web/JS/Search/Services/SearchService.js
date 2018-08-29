app.service('SearchService', function ($http, configurationService) {

    var SearchService = {};

    SearchService.SearchText = function (menuId,searchText,UserId) {
        return $http.get(configurationService.basePath + "api/SearchText?MenuId=" + menuId + "&SearchText=" + searchText + "&UserId=" + UserId);
    }
    return SearchService;
});