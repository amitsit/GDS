using System.Web.Http;
using GDS.Common;
using GDS.Services.SMOM.ConversionSetup;
using GDS.Entities.Master;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using GDS.Entities.SMOM.ConversionSetup;
using GDS.Entities.STMP.PlantEquipmentList;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class ConversionSetupApiController : ApiController
    {
        #region Initializtions

        private readonly IConversionSetupService _iService;

        public ConversionSetupApiController()
        {
            _iService = EngineContext.Resolve<IConversionSetupService>();
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("SaveConversionSetup")]
        public BaseApiResponse SaveConversionSetup(ConversionSetupSaveModel model)
        {
            return _iService.SaveConversionSetup(model);
        }

        [HttpPost]
        [Route("FinalizeConversionSetup")]
        public BaseApiResponse FinalizeConversionSetup(ConversionSetupSaveModel model)
        {
            return _iService.FinalizeConversionSetup(model);
        }

        #region General Info

        [HttpGet]
        [Route("GetConversionSetupPlantList")]
        public ApiResponse<PlantMasterModel> GetConversionSetupPlantList(int UserId, int moldFlowSetupHeaderId = 0)
        {
            return _iService.GetConversionSetupPlantList(UserId,moldFlowSetupHeaderId);
        }

        [HttpGet]
        [Route("GetInitialDataPlanList")]
        public ApiResponse<PlantMasterModel> GetInitialDataPlanList()
        {
            return _iService.GetInitialDataPlanList();
        }

        [HttpGet]
        [Route("GetConversionSetupInitdataPlanEquipmentList")]
        public ApiResponse<STMPPlantEquipmentListModel> GetConversionSetupInitdataPlanEquipmentList(int PlantId = 0)
        {
            return _iService.GetConversionSetupInitdataPlanEquipmentList(PlantId);
        }


        [HttpGet]
        [Route("GetLastVersionGeneralInfoFromPlant")]
        public ApiResponse<InitDataGeneralInfoModel> GetLastVersionGeneralInfoFromPlant(int plantId, int plantEquipmentListId, int moldFlowSetupHeaderId)
        {
            return _iService.GetLastVersionGeneralInfoFromPlant(plantId, plantEquipmentListId, moldFlowSetupHeaderId);
        }

        [HttpGet]
        [Route("GetLastVersionGeneralInfo")]
        public ApiResponse<InitialDataConversionSetupModel> GetLastVersionGeneralInfo(int moldFlowSetupHeaderId)
        {
            return _iService.GetLastVersionGeneralInfo(moldFlowSetupHeaderId);
        }

        #endregion

        #region Shot Position
        [HttpPost]
        [Route("GetConversionShotPosition")]
        public ApiResponse<ConversionShotPositionModel> GetConversionShotPosition(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionShotPosition(paramModel);
        }
        #endregion

        #region Pressure
        [HttpPost]
        [Route("GetConversionPressure")]
        public ApiResponse<ConversionPressureModel> GetConversionPressure(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionPressure(paramModel);
        }
        #endregion

        #region Shot weight
        [HttpPost]
        [Route("GetConversionShotWeight")]
        public ApiResponse<ConversionShotWeightModel> GetConversionShotWeight(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionShotWeight(paramModel);
        }
        #endregion

        #region Timer
        [HttpPost]
        [Route("GetConversionTimer")]
        public ApiResponse<ConversionTimerModel> GetConversionTimer(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionTimer(paramModel);
        }
        #endregion

        #region Barrel Temp
        [HttpPost]
        [Route("GetConversionBarrelTemp")]
        public ApiResponse<ConversionBarrelTempModel> GetConversionBarrelTemp(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionBarrelTemp(paramModel);
        }
        #endregion

        #region Hot Runner
        [HttpPost]
        [Route("GetConversionHotRunner")]
        public ApiResponse<ConversionHotRunnerModel> GetConversionHotRunner(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionHotRunner(paramModel);
        }
        #endregion

        #region Valve Gate Position
        [HttpPost]
        [Route("GetConversionValveGate")]
        public ApiResponse<ConversionValveGatePositionModel> GetConversionValveGate(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionValveGate(paramModel);
        }

        #endregion

        #region Fill Stages
        [HttpPost]
        [Route("GetConversionFillStages")]
        public ApiResponse<ConversionFillStagesModel> GetConversionFillStages(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionFillStages(paramModel);
        }
        #endregion

        #region Mold Temp
        [HttpPost]
        [Route("GetConversionMoldTemp")]
        public ApiResponse<ConversionMoldTempModel> GetConversionMoldTemp(ConversionSetupParameter paramModel)
        {
            return _iService.GetConversionMoldTemp(paramModel);
        }
        #endregion

        #endregion

    }
}
