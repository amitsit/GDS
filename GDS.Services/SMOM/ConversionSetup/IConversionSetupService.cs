using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.ConversionSetup;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using GDS.Entities.STMP.PlantEquipmentList;

namespace GDS.Services.SMOM.ConversionSetup
{
    public interface IConversionSetupService
    {
        ApiResponse<PlantMasterModel> GetConversionSetupPlantList(int UserId,int moldFlowSetupHeaderId);

        BaseApiResponse SaveConversionSetup(ConversionSetupSaveModel model);

        BaseApiResponse FinalizeConversionSetup(ConversionSetupSaveModel model);

        #region General Info
        ApiResponse<InitDataGeneralInfoModel> GetLastVersionGeneralInfoFromPlant(int plantId, int plantEquipmentListId, int moldFlowSetupHeaderId);

        ApiResponse<InitialDataConversionSetupModel> GetLastVersionGeneralInfo(int moldFlowSetupHeaderId);
        #endregion

        #region Shot Position
        ApiResponse<ConversionShotPositionModel> GetConversionShotPosition(ConversionSetupParameter paramModel);
        #endregion

        #region Pressure
        ApiResponse<ConversionPressureModel> GetConversionPressure(ConversionSetupParameter paramModel);
        #endregion

        #region Shot weight
        ApiResponse<ConversionShotWeightModel> GetConversionShotWeight(ConversionSetupParameter paramModel);
        #endregion

        #region Timer
        ApiResponse<ConversionTimerModel> GetConversionTimer(ConversionSetupParameter paramModel);
        #endregion

        #region Barrel Temp
        ApiResponse<ConversionBarrelTempModel> GetConversionBarrelTemp(ConversionSetupParameter paramModel);
        #endregion

        #region Hot Runner
        ApiResponse<ConversionHotRunnerModel> GetConversionHotRunner(ConversionSetupParameter paramModel);
        #endregion

        #region Valve Gate Position
        ApiResponse<ConversionValveGatePositionModel> GetConversionValveGate(ConversionSetupParameter paramModel);
        #endregion

        #region Fill Stages
        ApiResponse<ConversionFillStagesModel> GetConversionFillStages(ConversionSetupParameter paramModel);
        #endregion

        #region Mold Temp
        ApiResponse<ConversionMoldTempModel> GetConversionMoldTemp(ConversionSetupParameter paramModel);
        #endregion

        #region InitialData Plan list
        ApiResponse<PlantMasterModel> GetInitialDataPlanList();
        ApiResponse<STMPPlantEquipmentListModel> GetConversionSetupInitdataPlanEquipmentList(int plantId);
        #endregion
    }
}
