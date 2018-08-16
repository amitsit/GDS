using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.User
{
    public interface IUserService
    {
        ApiResponse<UserMasterModel> GetUserDetail(int? userId);
        BaseApiResponse SaveUserDetail(UserMasterModel UserObj);
        ApiResponse<UserMasterModel> GetLoginUserDetails(string networkId);
        ApiResponse<RegionMasterModel> GetRegionsByUserId(int? UserId, int? LoggedInUserId);
        ApiResponse<PlantMasterModel> GetPlantByRegionList(string Regions, int? UserId, int? LoggedInUserId);
        ApiResponse<RoleRightsPermissionModel> GetLoginUserRoleRights(int? UserId);
    }
}
