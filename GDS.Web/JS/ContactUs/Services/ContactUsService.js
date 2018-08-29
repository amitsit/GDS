app.service('ContactUsService', function ($http, configurationService) {

    var ContactUsService = {};

    ContactUsService.GetContactUs = function (contactId, userId) {
        return $http.get(configurationService.basePath + "api/GetContactUs?ContactId=" + contactId + "&UserId=" + userId);    }

    ContactUsService.GetContactUsDetail = function (contactId, userId) {
        return $http.get(configurationService.basePath + "api/GetContactUsDetail?ContactId=" + contactId + "&UserId=" + userId);
    }

    ContactUsService.GetContactListByStatus = function (menuId, userId, isActive) {
        return $http.get(configurationService.basePath + "api/GetContactListByStatus?MenuId=" + menuId + "&UserId=" + userId + "&IsActive" + isActive);
    }
    ContactUsService.SaveContactDetail = function (UserId, ProcessObj) {
        return $http.post(configurationService.basePath + "api/SaveContactDetail?UserId=" + UserId, ProcessObj);
    }
    return ContactUsService;
});