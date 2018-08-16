using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api/Region")]
    public class RegionApiController : ApiController
    {
        #region Initializtions
        private readonly IRegionService _iRegionService;

        public RegionApiController()
        {
            this._iRegionService = EngineContext.Resolve<IRegionService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetRegionList")]
        public ApiResponse<RegionMasterModel> GetRegionList()
        {
            return this._iRegionService.GetRegionList();
        }

        [HttpGet]
        [Route("GetRegionDetail")]
        public ApiResponse<RegionMasterModel> GetRegionDetail(int RegionID)
        {
            return this._iRegionService.GetRegionDetail(RegionID);
        }

      

        [HttpPost]
        [Route("AddOrUpdateRegion")]
        public BaseApiResponse AddOrUpdateRegion(int UserId, RegionMasterModel RegionObj)
        {
            return this._iRegionService.AddOrUpdateRegion(UserId, RegionObj);
        }

        [HttpPost]
        [Route("DeleteRegion")]
        public BaseApiResponse DeleteRegion(long RegionID)
        {
            return this._iRegionService.DeleteRegion(RegionID);
        }



        #endregion
    }
}