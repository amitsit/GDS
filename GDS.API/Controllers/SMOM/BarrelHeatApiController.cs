using GDS.Common;
using GDS.Entities.SMOM.BarrelHeats;
using GDS.Services.SMOM.BarrelHeats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class BarrelHeatApiController : ApiController
    {

        #region Initializtions

        private readonly IBarrelHeatService _iService;

        public BarrelHeatApiController()
        {
            _iService = EngineContext.Resolve<IBarrelHeatService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetBerralHeatDetail")]
        public ApiResponse<BarrelHeatModel> GetBerralHeatDetail(long CoverPageId, int UserId)
        {
            return _iService.GetBerralHeatDetail(CoverPageId, UserId);
        }


        [HttpPost]
        [Route("SaveOrUpdateBarrelHeats")]
        public BaseApiResponse SaveOrUpdateBarrelHeats(BarrelHeatModel BarrelModel)
        {
            return _iService.SaveOrUpdateBarrelHeats(BarrelModel);
        }
        #endregion
    }
}