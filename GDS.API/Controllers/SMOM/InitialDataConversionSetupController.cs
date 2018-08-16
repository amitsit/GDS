using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using GDS.Entities.SMOM.PlasticPressureLosses;
using GDS.Services.SMOM.InitialDataConversionSetup;
using System.Web;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class InitialDataConversionSetupController : ApiController
    {
        #region Initializtions

        private readonly IInitialDataConversionSetupService _iService;

        public InitialDataConversionSetupController()
        {
            _iService = EngineContext.Resolve<IInitialDataConversionSetupService>();
        }

        #endregion

        #region Common

        [HttpGet]
        [Route("LoadInitDataFromMoldFlowSetup")]
        public ApiResponse<LoadInitDataFromMoldFlowSetupModel> LoadInitDataFromMoldFlowSetup(long moldFlowSetupId, int lengthUnitId = 1)
        {
            return _iService.LoadInitDataFromMoldFlowSetup(moldFlowSetupId, lengthUnitId);
        }

        #endregion

        #region Methods 1

        #region General Information

        [HttpGet]
        [Route("GetMaterialListForInitialDataGeneralInformation")]
        public ApiResponse<MaterialDataModel> GetMaterialListForInitialDataGeneralInformation()
        {
            return _iService.GetMaterialListForInitialDataGeneralInformation();
        }

        [HttpPost]
        [Route("GetInitDataGeneralInfo")]
        public ApiResponse<InitDataGeneralInfoModel> GetInitDataGeneralInfo(InitDataInputDataModel model)
        {
            return _iService.GetInitDataGeneralInfo(model);
        }

        [HttpPost]
        [Route("SaveInitDataGeneralInfo")]
        public BaseApiResponse SaveInitDataGeneralInfo(InitDataGeneralInfoModel model)
        {
            return _iService.SaveInitDataGeneralInfo(model);
        }

        #endregion

        #region Shot Position

        [HttpPost]
        [Route("GetInitDataShotPositions")]
        public ApiResponse<InitDataShotPositionModel> GetInitDataShotPositions(InitDataInputDataModel model)
        {
            return _iService.GetInitDataShotPositions(model);
        }

        [HttpPost]
        [Route("SaveInitDataShotPositions")]
        public BaseApiResponse SaveInitDataShotPositions(InitDataShotPositionModel model)
        {
            return _iService.SaveInitDataShotPositions(model);
        }

        #endregion

        #region Shot Weight

        [HttpPost]
        [Route("GetInitDataShotWeight")]
        public ApiResponse<InitDataShotWeightModel> GetInitDataShotWeight(InitDataInputDataModel model)
        {
            return _iService.GetInitDataShotWeight(model);
        }

        [HttpPost]
        [Route("SaveInitDataShotWeight")]
        public BaseApiResponse SaveInitDataShotWeight(InitDataShotWeightModel model)
        {
            return _iService.SaveInitDataShotWeight(model);
        }

        #endregion

        #region Pressure

        [HttpPost]
        [Route("GetInitDataPressure")]
        public ApiResponse<InitDataPressureModel> GetInitDataPressure(InitDataInputDataModel model)
        {
            return _iService.GetInitDataPressure(model);
        }

        [HttpPost]
        [Route("SaveInitDataPressure")]
        public BaseApiResponse SaveInitDataPressure(InitDataPressureModel model)
        {
            return _iService.SaveInitDataPressure(model);
        }

        #endregion

        #endregion

        #region Methods 2

        #region Barrel Temperature Setting

        [HttpPost]
        [Route("GetBarrelTempSetting")]
        public ApiResponse<BarrelTempSettingModel> GetBarrelTempSetting(InitDataInputDataModel model)
        {
            return _iService.GetBarrelTempSetting(model);
        }

        [HttpPost]
        [Route("SaveBarrelTempSetting")]
        public BaseApiResponse SaveBarrelTempSetting(BarrelTempSettingModel model)
        {
            return _iService.SaveBarrelTempSetting(model);
        }

        #endregion

        #region Hot Runner

        [HttpPost]
        [Route("GetInitDataHotRunner")]
        public ApiResponse<InitDataHotRunnerModel> GetInitDataHotRunner(InitDataInputDataModel model)
        {
            return _iService.GetInitDataHotRunner(model);
        }

        [HttpPost]
        [Route("SaveInitDataHotRunner")]
        public BaseApiResponse SaveBarrelTempSetting(InitDataHotRunnerModel model)
        {
            return _iService.SaveInitDataHotRunner(model);
        }

        #endregion

        #region Mold Temp
        [HttpPost]
        [Route("GetInitDataMoldTemp")]
        public ApiResponse<InitDataMoldTempModel> GetInitDataMoldTemp(InitDataInputDataModel model)
        {
            return _iService.GetInitDataMoldTemp(model);
        }

        [HttpPost]
        [Route("SaveInitDataMoldTemp")]
        public BaseApiResponse SaveInitDataMoldTemp(InitDataMoldTempModel model)
        {
            return _iService.SaveInitDataMoldTemp(model);
        }


        #endregion

        #region Timer
        [HttpPost]
        [Route("GetInitDataTimer")]
        public ApiResponse<InitDataTimerModel> GetInitDataTimer(InitDataInputDataModel model)
        {
            return _iService.GetInitDataTimer(model);
        }

        [HttpPost]
        [Route("SaveInitDataTimer")]
        public BaseApiResponse SaveInitDataTimer(InitDataTimerModel model)
        {
            return _iService.SaveInitDataTimer(model);
        }



        #endregion

        #region Version List
        [HttpGet]
        [Route("GetInitDataVersionList")]
        public ApiResponse<InitDataVersionModel> GetInitDataVersionList(long moldflowHeaderId)
        {
            return _iService.GetInitDataVersionList(moldflowHeaderId);
        }


        #endregion


        #endregion


        #region Fill Stages

        [HttpPost]
        [Route("GetInitDataFillStages")]
        public ApiResponse<InitDataFillStagesModel> GetInitDataFillStages(InitDataInputDataModel model)
        {
            return _iService.GetInitDataFillStages(model);
        }

        [HttpPost]
        [Route("SaveInitDataFillStages")]
        public BaseApiResponse SaveInitDataFillStages(InitDataFillStagesModel model)
        {
            return _iService.SaveInitDataFillStages(model);
        }


        #endregion

        #region Attachments

        [HttpPost]
        [Route("UploadInitDataConversionSetupAttachment")]
        public BaseApiResponse UploadInitDataConversionSetupAttachment(long InitDataGeneralInfoId, int LoggedInUserId)
        {
            HttpPostedFile httpPostedFile = null;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                httpPostedFile = HttpContext.Current.Request.Files[0];
            }
            return _iService.UploadInitDataConversionSetupAttachment(InitDataGeneralInfoId, httpPostedFile, LoggedInUserId);
        }

        [HttpGet]
        [Route("GetInitDataConversionSetupAttachment")]
        public ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachment(int InitDataGeneralInfoId)
        {
            return _iService.GetInitDataConversionSetupAttachment(InitDataGeneralInfoId);
        }

        [HttpGet]
        [Route("GetInitDataConversionSetupAttachmentById")]
        public ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId)
        {
            return _iService.GetInitDataConversionSetupAttachmentById(InitDataConversionSetupAttachmentId);
        }

        [HttpGet]
        [Route("DownloadInitDataConversionSetupAttachmentById")]
        public HttpResponseMessage DownloadInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId)
        {
            return _iService.DownloadInitDataConversionSetupAttachmentById(InitDataConversionSetupAttachmentId);
        }

        [HttpPost]
        [Route("DeleteInitDataConversionSetupAttachment")]
        public BaseApiResponse DeleteInitDataConversionSetupAttachment(long InitDataConversionSetupAttachmentId)
        {
            return _iService.DeleteInitDataConversionSetupAttachment(InitDataConversionSetupAttachmentId);
        }

        #endregion

        #region PushToProduction

        [HttpPost]
        [Route("PushToProduction")]
        public BaseApiResponse PushToProduction(InitDataPushToProductionInputModel model)
        {
            return _iService.PushToProduction(model);
        }

        #endregion

    }
}
