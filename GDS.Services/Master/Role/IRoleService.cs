using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.Role
{
   public interface IRoleService
    {
        ApiResponse<RoleModel> GetRoleList(int RoleId, int UserId);

        BaseApiResponse AddOrUpdateRole(int UserId, RoleModel RoleObj);

        BaseApiResponse RemoveRole(int RoleId, int UserId);

        ApiResponse<RoleRightsModel> GetRoleRights(int RoleId, int UserId);

        BaseApiResponse AddOrUpdateRoleConfiguration(int UserId, List<RoleRightsModel> RoleRightsCollection);
        
    }
}
