using GDS.Common;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using System.Net.Http;
using System.Web;

namespace GDS.Services.SMOM.InitialDataConversionSetup
{
    public interface IInitialDataConversionSetupService
    {

        #region Common

        ApiResponse<LoadInitDataFromMoldFlowSetupModel> LoadInitDataFromMoldFlowSetup(long moldFlowSetupId, int lengthUnitId);

        #endregion

        #region Methods 

        // General Information

        ApiResponse<MaterialDataModel> GetMaterialListForInitialDataGeneralInformation();

        ApiResponse<InitDataGeneralInfoModel> GetInitDataGeneralInfo(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataGeneralInfo(InitDataGeneralInfoModel model);

        // Shot Position

        ApiResponse<InitDataShotPositionModel> GetInitDataShotPositions(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataShotPositions(InitDataShotPositionModel model);

        // Shot Weight

        ApiResponse<InitDataShotWeightModel> GetInitDataShotWeight(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataShotWeight(InitDataShotWeightModel model);

        // Pressure

        ApiResponse<InitDataPressureModel> GetInitDataPressure(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataPressure(InitDataPressureModel model);

        #endregion

        #region Methods 2

        // Barrel Temp

        ApiResponse<BarrelTempSettingModel> GetBarrelTempSetting(InitDataInputDataModel model);

        BaseApiResponse SaveBarrelTempSetting(BarrelTempSettingModel model);

        // Hot Runner
        ApiResponse<InitDataHotRunnerModel> GetInitDataHotRunner(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataHotRunner(InitDataHotRunnerModel model);

        // Mold Temp
        ApiResponse<InitDataMoldTempModel> GetInitDataMoldTemp(InitDataInputDataModel model);

        BaseApiResponse SaveInitDataMoldTemp(InitDataMoldTempModel model);

        //Timer
        BaseApiResponse SaveInitDataTimer(InitDataTimerModel model);
        ApiResponse<InitDataTimerModel> GetInitDataTimer(InitDataInputDataModel model);

        #endregion

        #region Version List
        ApiResponse<InitDataVersionModel> GetInitDataVersionList(long moldflowHeaderId);
        #endregion

        #region Fill Stages
        BaseApiResponse SaveInitDataFillStages(InitDataFillStagesModel model);
        ApiResponse<InitDataFillStagesModel> GetInitDataFillStages(InitDataInputDataModel model);
        #endregion


        #region Attachments

        BaseApiResponse UploadInitDataConversionSetupAttachment(long InitDataGeneralInfoId, HttpPostedFile Attachment, int LoggedInUserId);
        ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachment(int InitDataGeneralInfoId);
        ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId);
        HttpResponseMessage DownloadInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId);
        BaseApiResponse DeleteInitDataConversionSetupAttachment(long InitDataConversionSetupAttachmentId);

        #endregion

        // Push to procuction
        BaseApiResponse PushToProduction(InitDataPushToProductionInputModel model);
    }


}
