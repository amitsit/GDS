using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {
        #region Initializtions

        private readonly IUserService _iService;

        public UserApiController()
        {
            _iService = EngineContext.Resolve<IUserService>();
        }

        #endregion

        [HttpGet]
        [Route("GetUserDetail")]
        public ApiResponse<UserMasterModel> GetUserDetail(int? userId = null)
        {
            return _iService.GetUserDetail(userId);
        }

        [HttpPost]
        [Route("SaveUserDetail")]
        public BaseApiResponse SaveUserDetail(UserMasterModel model)
        {
            return _iService.SaveUserDetail(model);
        }

        [HttpGet]
        [Route("GetLoginUserDetails")]
        public ApiResponse<UserMasterModel> GetLoginUserDetails(string networkId = null)
        {
            return _iService.GetLoginUserDetails(networkId);
        }

        [HttpGet]
        [Route("GetRegionsByUserId")]
        public ApiResponse<RegionMasterModel> GetRegionsByUserId(int? UserId,int? LoggedInUserId)
        {
            return _iService.GetRegionsByUserId(UserId, LoggedInUserId);
        }

        [HttpGet]
        [Route("GetPlantByRegionList")]
        public ApiResponse<PlantMasterModel> GetPlantByRegionList(string Regions, int? UserId, int? LoggedInUserId)
        {
            return _iService.GetPlantByRegionList(Regions,UserId, LoggedInUserId);
        }

        [HttpGet]
        [Route("GetLoginUserRoleRights")]
        public ApiResponse<RoleRightsPermissionModel> GetLoginUserRoleRights(int? UserId)
        {
            return _iService.GetLoginUserRoleRights(UserId);
        }


    }
}
