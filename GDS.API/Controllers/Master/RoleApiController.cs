using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    
    [RoutePrefix("api")]
    public class RoleApiController : ApiController
    {
        #region Initializtions
        private readonly IRoleService _iRoleService;

        public RoleApiController()
        {
            this._iRoleService = EngineContext.Resolve<IRoleService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetRoleList")]
        public ApiResponse<RoleModel> GetRoleList(int RoleId, int UserId)
        {
            return this._iRoleService.GetRoleList(RoleId,UserId);
        }

        [HttpPost]
        [Route("AddOrUpdateRole")]
        public BaseApiResponse AddOrUpdateRole(int UserId, RoleModel RoleObj)
        {
            return this._iRoleService.AddOrUpdateRole(UserId, RoleObj);
        }

        [HttpGet]
        [Route("RemoveRole")]
        public BaseApiResponse RemoveRole(int RoleId, int UserId)
        {
            return this._iRoleService.RemoveRole(RoleId, UserId);
        }

        [HttpGet]
        [Route("GetRoleRights")]
        public ApiResponse<RoleRightsModel> GetRoleRights(int RoleId, int UserId)
        {
            return this._iRoleService.GetRoleRights(RoleId, UserId);
        }

        [HttpPost]
        [Route("AddOrUpdateRoleConfiguration")]
        public BaseApiResponse AddOrUpdateRoleConfiguration(int UserId, List<RoleRightsModel> RoleRightsCollection)
        {
            return this._iRoleService.AddOrUpdateRoleConfiguration(UserId, RoleRightsCollection);
        }

        #endregion
    }
}
