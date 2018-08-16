using GDS.Common;
using GDS.Entities.SMOM.WaterFlow;
using GDS.Services.SMOM.WaterFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class WaterFlowApiController : ApiController
    {
        #region Initializtions

        private readonly IWaterFlowService _iService;

        public WaterFlowApiController()
        {
            _iService = EngineContext.Resolve<IWaterFlowService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetWaterFlowDetail")]
        public ApiResponse<WaterFlowMasterModel> GetWaterFlowDetail(int CoverPageId,Int16 LengthUnitId, Int16 PressureUnitId)
        {
            return _iService.GetWaterFlowDetail(CoverPageId, LengthUnitId, PressureUnitId);
        }

        [HttpGet]
        [Route("GetWaterFlowMinuteDataDetail")]
        public ApiResponse<WaterMinuteDataModel> GetWaterFlowMinuteDataDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId)
        {
            return _iService.GetWaterFlowMinuteDataDetail(WaterFlowId, LengthUnitId, PressureUnitId);
        }

        [HttpPost]
        [Route("SaveWaterFlowDetail")]
        public BaseApiResponse SaveWaterFlowDetail(WaterFlowMasterModel model, int CreatedBy, Int16 LengthUnitId, Int16 PressureUnitId, byte? validationStatusCode)
        {
            return _iService.SaveWaterFlowDetail(model, CreatedBy, LengthUnitId, PressureUnitId, validationStatusCode);
        }

        [HttpPost]
        [Route("SaveGallonMappingList")]
        public BaseApiResponse SaveGallonMappingList(int UserId, WaterflowGallonMappingModel gallonMappingList)
        {
            return _iService.SaveGallonMappingList(UserId, gallonMappingList);
        }

        [HttpGet]
        [Route("GetGallonMappingList")]
        public ApiResponse<WaterflowGallonMappingModel> GetGallonMappingList(int WaterFlowId)
        {
            return _iService.GetGallonMappingList(WaterFlowId);
        }

        [HttpGet]
        [Route("GetWaterFlowThermolatorMappingDetail")]
        public ApiResponse<WaterFlowThermolatorDiameterMappingModel> GetWaterFlowThermolatorMappingDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId)
        {
            return _iService.GetWaterFlowThermolatorMappingDetail(WaterFlowId, LengthUnitId, PressureUnitId);
        }
        #endregion
    }
}