app.service('ContactUsService', function ($http, configurationService) {

    var ContactUsService = {};

    ContactUsService.GetContactUs = function (contactId, userId) {
        return $http.get(configurationService.basePath + "api/GetContactUs?ContactId=" + contactId + "&UserId=" + userId);    }


    return ContactUsService;
});