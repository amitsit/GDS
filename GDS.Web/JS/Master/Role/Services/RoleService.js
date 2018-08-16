app.service('RoleService', function ($http, configurationService) {

    var roleService = {};

    roleService.GetRoleList = function (UserId, RoleId) { 
        return $http.get(configurationService.basePath + "api/GetRoleList?RoleId=" + RoleId + "&UserId=" + UserId);
    }
   
    roleService.AddOrUpdateRole = function (UserId, RoleObj) {
        return $http.post(configurationService.basePath + "api/AddOrUpdateRole?UserId=" + UserId, RoleObj);
    }

    roleService.RemoveRole = function (UserId, RoleId) {
        return $http.get(configurationService.basePath + "api/RemoveRole?RoleId=" + RoleId + "&UserId=" + UserId);
    }

    roleService.GetRoleRights = function (RoleId,UserId) {
        return $http.get(configurationService.basePath + "api/GetRoleRights?RoleId=" + RoleId + "&UserId=" + UserId);
    }

    roleService.AddOrUpdateRoleConfiguration = function (UserId, RoleRightsCollection) {
        return $http.post(configurationService.basePath + "api/AddOrUpdateRoleConfiguration?UserId=" + UserId, RoleRightsCollection);
    }

    return roleService;
});