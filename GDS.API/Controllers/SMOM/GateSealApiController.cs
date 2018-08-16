using GDS.Common;
using GDS.Entities.SMOM;
using GDS.Services.SMOM.GateSeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class GateSealApiController : ApiController
    {
       
        #region Initializtions

        private readonly IGateSealService _iService;

        public GateSealApiController()
        {
            _iService = EngineContext.Resolve<IGateSealService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetSealPartDetail")]
        public ApiResponse<GateSealPartModel> GetSealPartDetail(int GateSealId)
        {
            return _iService.GetSealPartDetail(GateSealId);
        }

        [HttpGet]
        [Route("GetSealDetail")]
        public ApiResponse<GateSealMasterModel> GetSealDetail(long CoverPageId, Int16 PressureUnitId)
        {
            return _iService.GetSealDetail(CoverPageId, PressureUnitId);
        }
        [HttpPost]
        [Route("SaveOrUpdateSealDetail")]
        public BaseApiResponse SaveOrUpdateSealDetail(int UserId,long CoverPageId, Int16 PressureUnitId, GateSealMasterModel MasterModel)
        {
            return _iService.SaveOrUpdateSealDetail(UserId, CoverPageId, PressureUnitId,MasterModel);
        }

        #endregion
    }
}