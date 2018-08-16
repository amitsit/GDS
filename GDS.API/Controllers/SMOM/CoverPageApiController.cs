using GDS.Common;
using GDS.Entities.SMOM.CoverPage;
using GDS.Services.SMOM.CoverPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class CoverPageApiController : ApiController
    {
        #region Initializtions

        private readonly ICoverPageService _iService;

        public CoverPageApiController()
        {
            _iService = EngineContext.Resolve<ICoverPageService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetCoverPageDetail")]
        public ApiResponse<CoverPageModel> GetCoverPageDetail(int CoverPageId)
        {
            return _iService.GetCoverPageDetail(CoverPageId);
        }

        [HttpGet]
        [Route("GetCoverPageDetailfilter")]
        public ApiResponse<CoverPageModel> GetCoverPageDetail_filter(int CoverPageId = 0,int plantId = 0,int PlantEquipmentListId = 0, long inputDataId = 0)
        {
            return _iService.GetCoverPageDetail_filter(CoverPageId, plantId, PlantEquipmentListId, inputDataId);
        }

        [HttpGet]
        [Route("GetOlderCoverPageByCoverPageId")]
        public ApiResponse<CoverPageHistoryModel> GetOlderCoverPageByCoverPageId(int CoverPageId = 0, int plantId = 0, int PlantEquipmentListId = 0, int inputDataId = 0)
        {
            return _iService.GetOlderCoverPageByCoverPageId(CoverPageId, plantId, PlantEquipmentListId, inputDataId);
        }



        [HttpPost]
        [Route("SaveCoverPageDetail")]
        public BaseApiResponse SaveCoverPageDetail(CoverPageModel model)
        {
            return _iService.SaveCoverPageDetail(model);
        }


        [HttpGet]
        [Route("GetCoverPageMachineConfiguration")]
        public ApiResponse<CoverPageMachineConfigurationModel> GetCoverPageMachineConfiguration(long? CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId, bool getAllData = false, long? CoverPageIdTool = null)
        {
            return _iService.GetCoverPageMachineConfiguration(CoverPageId, lengthUnitId, pressureUnitId, getAllData, CoverPageIdTool);
        }

        [HttpGet]
        [Route("GetMachineConfigurationForPlasticPressure")]
        public ApiResponse<CoverPageMachineConfigurationModel> GetMachineConfigurationForPlasticPressure( Int16 lengthUnitId, Int16 pressureUnitId, long? CoverPageIdTool = null)
        {
            return _iService.GetMachineConfigurationForPlasticPressure( lengthUnitId, pressureUnitId,  CoverPageIdTool);
        }


        [HttpGet]
        [Route("GetMoldList")]
        public ApiResponse<CoverPageMoldFlow> GetMoldList(int LoggedInUserId)
        {
            return this._iService.GetMoldList(LoggedInUserId);
        }



        [HttpGet]
        [Route("GetMoldFlowPageRecords")]
        public ApiResponse<CoverPageMoldFlow> GetMoldFlowPageRecords( string MoldNumber)
        {
            return _iService.GetMoldFlowPageRecords(MoldNumber);
        }


        [HttpGet]
        [Route("GetCoverPageDataCount")]
        public ApiResponse<CoverPageDataCountModel> GetCoverPageDataCount(long? CoverPageIdPress, long? CoverPageIdTool)
        {
            return _iService.GetCoverPageDataCount(CoverPageIdPress, CoverPageIdTool);
        }

        [HttpGet]
        [Route("GetPlantListDropdown")]
        public ApiResponse<CoverPageModel> GetPlantListDropdown(int? PlantId, bool MoldflowShow,int UserId)
        {
            return this._iService.GetPlantListDropdown(PlantId, MoldflowShow, UserId);
        }

        [HttpGet]
        [Route("GetMoldFlowFilter")]
        public ApiResponse<CoverPageModel> GetMoldFlowFilter(int PlantId, bool NeedExistingMoldOnly)
        {
            return this._iService.GetMoldFlowFilter(PlantId,NeedExistingMoldOnly);
        }

        [HttpGet]
        [Route("GetIMPDRedirectParamsFromInputDataId")]
        public ApiResponse<IMPDRedirectParamsFromInputDataId> GetIMPDRedirectParamsFromInputDataId(long inputDataId)
        {
            return _iService.GetIMPDRedirectParamsFromInputDataId(inputDataId);
        }

        #endregion
    }
}
