using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.SMOM.ConversionSetup;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using GDS.Entities.STMP.PlantEquipmentList;

namespace GDS.Services.SMOM.ConversionSetup
{
    public class ConversionSetupService : IConversionSetupService
    {
        #region Constants

        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #endregion

        #region Fields

        /// <summary>
        /// Declare The provider repository object for perform operation on Provider repository
        /// </summary>
        private readonly IGenericRepository<ConversionSetupModel> _repository;

        #endregion

        #region ctor


        public ConversionSetupService(IGenericRepository<ConversionSetupModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods 

        public BaseApiResponse SaveConversionSetup(ConversionSetupSaveModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("MoldFlowPlantId",model.MoldFlowPlantId),
                    new SqlParameter("MoldFlowPlantEquipmentListId",model.MoldFlowPlantEquipmentListId),
                    new SqlParameter("SelectedPlantId",model.SelectedPlantId),
                    new SqlParameter("SelectedPlantEquipmentListId",model.SelectedPlantEquipmentListId),
                    new SqlParameter("UserId",model.UserId),
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_ConversionSetup_SaveConversionSetup", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse FinalizeConversionSetup(ConversionSetupSaveModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("MoldFlowPlantId",model.MoldFlowPlantId),
                    new SqlParameter("MoldFlowPlantEquipmentListId",model.MoldFlowPlantEquipmentListId),
                    new SqlParameter("SelectedPlantId",model.SelectedPlantId),
                    new SqlParameter("SelectedPlantEquipmentListId",model.SelectedPlantEquipmentListId),
                    new SqlParameter("UserId",model.UserId),
                };

                var result = _repository.ExecuteSQL<long>("usp_ConversionSetup_FinalizeConversionSetup", paramList).FirstOrDefault();
                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #region Plant List

        public ApiResponse<PlantMasterModel> GetConversionSetupPlantList(int UserId,int moldflowSetupHeaderId)
        {
            var response = new ApiResponse<PlantMasterModel>();

            try
            {

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value =(object) UserId??DBNull.Value
                };
                var moldflowSetupHeaderIdParam = new SqlParameter
                {
                    ParameterName = "MoldflowSetupHeaderId",
                    DbType = DbType.Int64,
                    Value = moldflowSetupHeaderId
                };


                var result = _repository.ExecuteSQL<PlantMasterModel>("usp_ConversionSetup_GetPlanList", UserIdParam, moldflowSetupHeaderIdParam).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }




        #endregion

        #region Get Initial Data Plan List AND PlanEquipment List
        public ApiResponse<PlantMasterModel> GetInitialDataPlanList()
        {
            var response = new ApiResponse<PlantMasterModel>();
            try
            {
                var result = _repository.ExecuteSQL<PlantMasterModel>("usp_ConversionSetup_GetInitDataPlanList").ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public ApiResponse<STMPPlantEquipmentListModel> GetConversionSetupInitdataPlanEquipmentList(int plantId)
        {
            var response = new ApiResponse<STMPPlantEquipmentListModel>();

            try
            {
                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };

                var result = _repository.ExecuteSQL<STMPPlantEquipmentListModel>("usp_ConversionSetup_GetInitDataPressList", plantidParam).ToList();

                response.Data = result.ToList();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        #endregion

        #region Last Version General Info

        public ApiResponse<InitDataGeneralInfoModel> GetLastVersionGeneralInfoFromPlant(int plantId, int plantEquipmentListId, int moldFlowSetupHeaderId)
        {
            var response = new ApiResponse<InitDataGeneralInfoModel>();

            try
            {

                object[] paramList =
               {
                    new SqlParameter("plantId",plantId),
                    new SqlParameter("plantEquipmentListId",plantEquipmentListId),
                    new SqlParameter("moldFlowSetupHeaderId",moldFlowSetupHeaderId)
                };

                var result = _repository.ExecuteSQL<InitDataGeneralInfoModel>("usp_smom_ConversionSetup_GetGeneralInfoFromPlant", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<InitialDataConversionSetupModel> GetLastVersionGeneralInfo(int moldFlowSetupHeaderId)
        {
            var response = new ApiResponse<InitialDataConversionSetupModel>();

            try
            {

                object[] paramList =
                {
                    new SqlParameter("moldFlowSetupHeaderId",moldFlowSetupHeaderId),
                     //new SqlParameter("InitDataGeneralInfoId",generalInfoId),
                };

                var result = _repository.ExecuteSQL<InitialDataConversionSetupModel>("usp_smom_ConversionSetup_GetGeneralInfo", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Shot Position

        public ApiResponse<ConversionShotPositionModel> GetConversionShotPosition(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionShotPositionModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionShotPositionModel>("usp_ConversionSetup_GetShotPosition", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Pressure 

        public ApiResponse<ConversionPressureModel> GetConversionPressure(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionPressureModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionPressureModel>("usp_ConversionSetup_GetPressure", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Shot Weight

        public ApiResponse<ConversionShotWeightModel> GetConversionShotWeight(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionShotWeightModel>();
            try
            {
                var paramList = GetOnlyInitDataParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionShotWeightModel>("usp_ConversionSetup_GetShotWeight", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Timer

        public ApiResponse<ConversionTimerModel> GetConversionTimer(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionTimerModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionTimerModel>("usp_ConversionSetup_GetTimer", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Barrel Temp

        public ApiResponse<ConversionBarrelTempModel> GetConversionBarrelTemp(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionBarrelTempModel>();
            try
            {
                var paramList = GetOnlyInitDataParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionBarrelTempModel>("usp_ConversionSetup_GetBarrelTempSetting", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region HotRunner

        public ApiResponse<ConversionHotRunnerModel> GetConversionHotRunner(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionHotRunnerModel>();
            try
            {
                var paramList = GetOnlyInitDataParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionHotRunnerModel>("usp_ConversionSetup_GetHotRunner", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Valve Gate Position

        public ApiResponse<ConversionValveGatePositionModel> GetConversionValveGate(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionValveGatePositionModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionValveGatePositionModel>("usp_ConversionSetup_GetValveGatePosition", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Fill Stages
        public ApiResponse<ConversionFillStagesModel> GetConversionFillStages(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionFillStagesModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionFillStagesModel>("usp_ConversionSetup_FillStages", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        #endregion

        #region Mold Temp

        public ApiResponse<ConversionMoldTempModel> GetConversionMoldTemp(ConversionSetupParameter paramModel)
        {
            var response = new ApiResponse<ConversionMoldTempModel>();
            try
            {
                var paramList = GetAllParamList(paramModel);
                var result = _repository.ExecuteSQL<ConversionMoldTempModel>("usp_ConversionSetup_GetMoldTemp", paramList).ToList();
                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #endregion

        #region Utils

        private static object[] GetAllParamList(ConversionSetupParameter paramModel)
        {
            object[] paramList =
               {
                    //new SqlParameter("InitDataPlantId",paramModel.SelectedMachinePlantId),
                    //new SqlParameter("InitDataPlantEquipmentId",paramModel.SelectedMachinePlantEquipmentId),
                    //new SqlParameter("InitDataMoldFlowSetupHeaderId",paramModel.InitDataMoldFlowSetupHeaderId),
                    //new SqlParameter("SelectedMachinePlantId",paramModel.InitDataPlantId),
                    //new SqlParameter("SelectedMachinePlantEquipmentId",paramModel.InitDataPlantEquipmentId),
                    //new SqlParameter("InitDataGeneralInfoId", paramModel.InitDataGeneralInfoId),
                    //new SqlParameter("LengthUnitId",paramModel.LengthUnitId),
                    //new SqlParameter("PressureUnitId",paramModel.PressureUnitId)


                    new SqlParameter("InitDataPlantId",paramModel.InitDataPlantId),
                    new SqlParameter("InitDataPlantEquipmentId",paramModel.InitDataPlantEquipmentId),
                    new SqlParameter("InitDataMoldFlowSetupHeaderId",paramModel.InitDataMoldFlowSetupHeaderId),
                    new SqlParameter("SelectedMachinePlantId",paramModel.SelectedMachinePlantId),
                    new SqlParameter("SelectedMachinePlantEquipmentId",paramModel.SelectedMachinePlantEquipmentId),
                    new SqlParameter("InitDataGeneralInfoId", paramModel.InitDataGeneralInfoId),
                    new SqlParameter("LengthUnitId",paramModel.LengthUnitId),
                    new SqlParameter("PressureUnitId",paramModel.PressureUnitId)
                };

            return paramList;
        }

        private static object[] GetOnlyInitDataParamList(ConversionSetupParameter paramModel)
        {
            object[] paramList =
               {

                    new SqlParameter("InitDataPlantId",paramModel.SelectedMachinePlantId),
                    new SqlParameter("InitDataPlantEquipmentId",paramModel.SelectedMachinePlantEquipmentId),
                    new SqlParameter("InitDataMoldFlowSetupHeaderId",paramModel.InitDataMoldFlowSetupHeaderId),
                    new SqlParameter("InitDataGeneralInfoId", paramModel.InitDataGeneralInfoId),
                    new SqlParameter("LengthUnitId",paramModel.LengthUnitId),
                    new SqlParameter("PressureUnitId",paramModel.PressureUnitId)

                    //new SqlParameter("InitDataPlantId",paramModel.SelectedMachinePlantId),
                    //new SqlParameter("InitDataPlantEquipmentId",paramModel.SelectedMachinePlantEquipmentId),
                    //new SqlParameter("InitDataMoldFlowSetupHeaderId",paramModel.InitDataMoldFlowSetupHeaderId),
                    //new SqlParameter("InitDataGeneralInfoId", paramModel.InitDataGeneralInfoId),
                    //new SqlParameter("LengthUnitId",paramModel.LengthUnitId),
                    //new SqlParameter("PressureUnitId",paramModel.PressureUnitId)
                };

            return paramList;
        }

        #endregion
    }
}