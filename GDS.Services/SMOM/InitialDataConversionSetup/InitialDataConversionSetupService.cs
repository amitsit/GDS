using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace GDS.Services.SMOM.InitialDataConversionSetup
{
    public class InitialDataConversionSetupService : IInitialDataConversionSetupService
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
        private readonly IGenericRepository<InitialDataConversionSetupModel> _repository;

        #endregion

        #region ctor


        public InitialDataConversionSetupService(IGenericRepository<InitialDataConversionSetupModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Common 

        public ApiResponse<LoadInitDataFromMoldFlowSetupModel> LoadInitDataFromMoldFlowSetup(long moldFlowSetupId, int lengthUnitId)
        {
            var response = new ApiResponse<LoadInitDataFromMoldFlowSetupModel>();

            try
            {
                var moldFlowSetupIdParam = new SqlParameter
                {
                    ParameterName = "MoldFlowSetupId",
                    DbType = DbType.Int64,
                    Value = moldFlowSetupId
                };

                var lengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int32,
                    Value = lengthUnitId
                };

                var result =
                    _repository.ExecuteSQL<LoadInitDataFromMoldFlowSetupModel>("usp_smom_InitDataShotPositions_LoadInitDataFromMoldFlowSetup", moldFlowSetupIdParam, lengthUnitIdParam).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Methods 1

        #region General Information

        public ApiResponse<MaterialDataModel> GetMaterialListForInitialDataGeneralInformation()
        {
            var response = new ApiResponse<MaterialDataModel>();

            try
            {
                var result = _repository.ExecuteSQL<MaterialDataModel>(
                    "usp_smom_MaterialMaster_GetMaterialListForInitialDataGeneralInformation").ToList();
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

        public ApiResponse<InitDataGeneralInfoModel> GetInitDataGeneralInfo(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataGeneralInfoModel>();
            List<InitDataGeneralInfoModel> IniDataGeneralInfoList = new List<InitDataGeneralInfoModel>();
            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),                    
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("IsHistory",(object)model.IsHistory ?? DBNull.Value)
                };

                 IniDataGeneralInfoList = _repository.ExecuteSQL<InitDataGeneralInfoModel>("usp_smom_InitDataGeneralInfo_GetInitDataGeneralInfo", paramList).ToList();
                if (IniDataGeneralInfoList.Count<=0)
                {
                    IniDataGeneralInfoList.Add(new InitDataGeneralInfoModel());                
                }

                response.Data = IniDataGeneralInfoList;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataGeneralInfo(InitDataGeneralInfoModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",(object)model.InitDataGeneralInfoId ?? DBNull.Value),
                    new SqlParameter("PlantId",model.PlantId),
                    new SqlParameter("MoldNumber",model.MoldNumber),
                    new SqlParameter("JobName",model.JobName),
                    new SqlParameter("PlantEquipmentListId",model.PlantEquipmentListId),
                    new SqlParameter("Date",model.Date),
                    new SqlParameter("MaterialId",model.MaterialId),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("MoldFlowSetupHeaderId",(object)model.MoldFlowSetupHeaderId ?? DBNull.Value),
                    new SqlParameter("IdentificationText",(object)model.IdentificationText?? DBNull.Value),
                    new SqlParameter("MeltTempInput",(object)model.MeltTempInput?? DBNull.Value),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("Ejectors",(object)model.Ejectors?? DBNull.Value),
                    new SqlParameter("Cores",(object)model.Cores??DBNull.Value),
                    new SqlParameter("SpecialNote_Issue",(object)model.SpecialNote_Issue?? DBNull.Value),
                    new SqlParameter("IsPushedToProducton",(object)model.IsPushedToProducton?? DBNull.Value)

                };

                var result =
                    _repository.ExecuteSQL<long>("usp_smom_InitDataGeneralInfo_SaveInitDataGeneralInfo", paramList).FirstOrDefault();
                response.Success = result > 0;
                if (result > 0)
                {
                    response.lng_InsertedId = result;
                }
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

        public ApiResponse<InitDataShotPositionModel> GetInitDataShotPositions(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataShotPositionModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result = _repository.ExecuteSQL<InitDataShotPositionModel>("usp_smom_InitDataShotPositions_GetInitDataShotPositions", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataShotPositions(InitDataShotPositionModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("ShotSize",(object)model.ShotSize ?? DBNull.Value),
                    new SqlParameter("Transfer",(object)model.Transfer ?? DBNull.Value),
                    new SqlParameter("Decompress",(object)model.Decompress ?? DBNull.Value),
                    new SqlParameter("Cushion",(object)model.Cushion ?? DBNull.Value),
                    new SqlParameter("FillCubicVolume",(object)model.FillCubicVolume ?? DBNull.Value),
                    new SqlParameter("TotalCubicVolume",(object)model.TotalCubicVolume ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)

                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataShotPositions_SaveInitDataShotPositions", paramList).FirstOrDefault();
                response.Success = result > 0;
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

        public ApiResponse<InitDataShotWeightModel> GetInitDataShotWeight(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataShotWeightModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataShotWeightModel>("usp_smom_InitDataShotWeight_GetInitDataShotWeight", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataShotWeight(InitDataShotWeightModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("TransferCAV1LH",(object)model.TransferCAV1LH ?? DBNull.Value),
                    new SqlParameter("TransferCAV2LH",(object)model.TransferCAV2LH ?? DBNull.Value),
                    new SqlParameter("TransferCAV3LH",(object)model.TransferCAV3LH ?? DBNull.Value),
                    new SqlParameter("TransferCAV4LH",(object)model.TransferCAV4LH ?? DBNull.Value),
                    new SqlParameter("TransferWeightRunner",(object)model.TransferWeightRunner ?? DBNull.Value),
                    new SqlParameter("FullPartCAV1LH",(object)model.FullPartCAV1LH ?? DBNull.Value),
                    new SqlParameter("FullPartCAV2LH",(object)model.FullPartCAV2LH ?? DBNull.Value),
                    new SqlParameter("FullPartCAV3LH",(object)model.FullPartCAV3LH ?? DBNull.Value),
                    new SqlParameter("FullPartCAV4LH",(object)model.FullPartCAV4LH ?? DBNull.Value),
                    new SqlParameter("FullPartWeightRunner",(object)model.FullPartWeightRunner ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)

                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataShotWeight_SaveInitDataShotWeight", paramList).FirstOrDefault();
                response.Success = result > 0;
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

        public ApiResponse<InitDataPressureModel> GetInitDataPressure(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataPressureModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataPressureModel>("usp_smom_InitDataPressure_GetInitDataPressure", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataPressure(InitDataPressureModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("Transfer",(object)model.Transfer ?? DBNull.Value),
                    new SqlParameter("Pack",(object)model.Pack ?? DBNull.Value),
                    new SqlParameter("Hold",(object)model.Hold ?? DBNull.Value),
                    new SqlParameter("Back",(object)model.Back ?? DBNull.Value),
                    new SqlParameter("Tonnage",(object)model.Tonnage ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)
                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataPressure_SaveInitDataPressure", paramList).FirstOrDefault();
                response.Success = result > 0;
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

        #region Methods 2

        #region Barrel Tempreture Setting
        public ApiResponse<BarrelTempSettingModel> GetBarrelTempSetting(InitDataInputDataModel model)
        {
            var response = new ApiResponse<BarrelTempSettingModel>();

            try
            {
                object[] paramList =
                 {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<BarrelTempSettingModel>("usp_smom_InitDataBarrelTempSetting_Get", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }



        public BaseApiResponse SaveBarrelTempSetting(BarrelTempSettingModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("Nozzle",(object)model.Nozzle ?? DBNull.Value),
                    new SqlParameter("Valve",(object)model.Valve ?? DBNull.Value),
                    new SqlParameter("FrontZone",(object)model.FrontZone ?? DBNull.Value),
                    new SqlParameter("MidFront",(object)model.MidFront ?? DBNull.Value),
                    new SqlParameter("MidRear",(object)model.MidRear ?? DBNull.Value),
                    new SqlParameter("RearZone",(object)model.RearZone ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("MeltTempInput",(object)model.MeltTempInput?? DBNull.Value)

                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_BarrelTempSetting_Save", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Hot Runner

        public ApiResponse<InitDataHotRunnerModel> GetInitDataHotRunner(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataHotRunnerModel>();
            InitDataHotRunnerModel hotRunnerModel = new InitDataHotRunnerModel();
            IList<InitDataHotRunnerModel> hotRunnerlist = new List<InitDataHotRunnerModel>();
            try
            {
                object[] paramList =
                 {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataHotRunnerList>("usp_smom_InitDataHotRunner_Get", paramList).ToList();

                hotRunnerModel.HotRunnerList = result;
                hotRunnerlist.Add(hotRunnerModel);
                response.Data = hotRunnerlist;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        public BaseApiResponse SaveInitDataHotRunner(InitDataHotRunnerModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                string HotRunnerDataXML = GDS.Common.ConvertToXml<InitDataHotRunnerList>.GetXMLString(model.HotRunnerList);



                var InitDataGeneralInfoIdParam = new SqlParameter
                {
                    ParameterName = "InitDataGeneralInfoId",
                    DbType = DbType.Int64,
                    Value = (object)model.InitDataGeneralInfoId
                };

                var HotRunnerListParam = new SqlParameter
                {
                    ParameterName = "HotRunnerModelCollectionXML",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(HotRunnerDataXML) ? HotRunnerDataXML : (object)DBNull.Value
                };

                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int64,
                    Value = (object)model.LoggedInUserId
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int32,
                    Value = (object)model.LengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int32,
                    Value = (object)model.PressureUnitId
                };


                //object[] paramList =
                //{
                //    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                //    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                //    new SqlParameter("HotRunnerModelCollectionXML",HotRunnerDataXML)
                //};

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataHotRunner_Save", InitDataGeneralInfoIdParam, HotRunnerListParam, LoggedInUserIdParam, LengthUnitIdParam, PressureUnitIdParam).FirstOrDefault();
                response.Success = result > 0;
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
        public ApiResponse<InitDataMoldTempModel> GetInitDataMoldTemp(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataMoldTempModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataMoldTempModel>("usp_smom_InitDataMoldTemp_Get", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataMoldTemp(InitDataMoldTempModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("Stationary_1",(object)model.Stationary_1 ?? DBNull.Value),
                    new SqlParameter("Stationary_2",(object)model.Stationary_2 ?? DBNull.Value),
                    new SqlParameter("Moveable_1",(object)model.Moveable_1 ?? DBNull.Value),
                    new SqlParameter("Moveable_2",(object)model.Moveable_2 ?? DBNull.Value),
                    new SqlParameter("Misc_1",(object)model.Misc_1 ?? DBNull.Value),
                    new SqlParameter("Misc_2",(object)model.Misc_2 ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)
                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataMoldTemp_Save", paramList).FirstOrDefault();
                response.Success = result > 0;
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

        public ApiResponse<InitDataTimerModel> GetInitDataTimer(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataTimerModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataTimerModel>("usp_smom_InitDataTimer_Get", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataTimer(InitDataTimerModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("Fill",(object)model.Fill ?? DBNull.Value),
                    new SqlParameter("Pack",(object)model.Pack ?? DBNull.Value),
                    new SqlParameter("Hold",(object)model.Hold ?? DBNull.Value),
                    new SqlParameter("Cooling",(object)model.Cooling ?? DBNull.Value),
                    new SqlParameter("ScrewRecovery",(object)model.ScrewRecovery ?? DBNull.Value),
                    new SqlParameter("ClampClose",(object)model.ClampClose ?? DBNull.Value),
                    new SqlParameter("ClampOpen",(object)model.ClampOpen ?? DBNull.Value),
                    new SqlParameter("CycleTime",(object)model.CycleTime ?? DBNull.Value),
                    new SqlParameter("RobotTakeOut",(object)model.RobotTakeOut ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId)
                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataTimer_Save", paramList).FirstOrDefault();
                response.Success = result > 0;
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

        #region Fill Stages

        public ApiResponse<InitDataFillStagesModel> GetInitDataFillStages(InitDataInputDataModel model)
        {
            var response = new ApiResponse<InitDataFillStagesModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataFillStagesModel>("usp_smom_InitDataFillStages_GetFillStages", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveInitDataFillStages(InitDataFillStagesModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("Velocity_Xferpos",(object)model.Velocity_Xferpos ?? DBNull.Value),
                    new SqlParameter("Velocity4",(object)model.Velocity4 ?? DBNull.Value),
                    new SqlParameter("Velocity3",(object)model.Velocity3 ?? DBNull.Value),
                    new SqlParameter("Velocity2",(object)model.Velocity2 ?? DBNull.Value),
                    new SqlParameter("Velocity1",(object)model.Velocity1 ?? DBNull.Value),
                    new SqlParameter("Position_Xferpos",(object)model.Position_Xferpos ?? DBNull.Value),
                    new SqlParameter("Position4",(object)model.Position4 ?? DBNull.Value),
                    new SqlParameter("Position3",(object)model.Position3 ?? DBNull.Value),
                    new SqlParameter("Position2",(object)model.Position2 ?? DBNull.Value),
                    new SqlParameter("Position1",(object)model.Position1 ?? DBNull.Value),
                    new SqlParameter("CubicFlow_Xferpos",(object)model.CubicFlow_Xferpos ?? DBNull.Value),
                    new SqlParameter("CubicFlow4",(object)model.CubicFlow4 ?? DBNull.Value),
                    new SqlParameter("CubicFlow3",(object)model.CubicFlow3 ?? DBNull.Value),
                    new SqlParameter("CubicFlow2",(object)model.CubicFlow2 ?? DBNull.Value),
                    new SqlParameter("CubicFlow1",(object)model.CubicFlow1 ?? DBNull.Value),
                    new SqlParameter("ReasonForProfile",(object)model.ReasonForProfile ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)

                };

                var result =
                    _repository.ExecuteSQL<int>("usp_smom_InitDataFillStages_SaveFillStages", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region VersionList

        public ApiResponse<InitDataVersionModel> GetInitDataVersionList(long moldflowHeaderId)
        {
            var response = new ApiResponse<InitDataVersionModel>();

            try
            {
                //var initDataGeneralInfoIdParam = new SqlParameter
                //{
                //    ParameterName = "MoldflowHeaderId",
                //    DbType = DbType.Int64,
                //    Value = moldflowHeaderId
                //};

                object[] paramList =
               {
                    new SqlParameter("MoldflowHeaderId",moldflowHeaderId),
                };

                var result =
                    _repository.ExecuteSQL<InitDataVersionModel>("usp_smom_InitData_GetVersionList", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Attachments

        public BaseApiResponse UploadInitDataConversionSetupAttachment(long InitDataGeneralInfoId, HttpPostedFile Attachment, int LoggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                if (Attachment != null)
                {
                    byte[] AttachmentData = null;
                    using (var binaryReader = new BinaryReader(Attachment.InputStream))
                    {
                        AttachmentData = binaryReader.ReadBytes(Attachment.ContentLength);
                    }
                    object[] paramList =
             {
                    new SqlParameter("InitDataGeneralInfoId",InitDataGeneralInfoId),
                    new SqlParameter("Attachment",(object)AttachmentData?? DBNull.Value),
                    new SqlParameter("AttachmentName",(object)Attachment.FileName?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",(object)LoggedInUserId?? DBNull.Value)
                };

                    var result = _repository.ExecuteSQL<long>("usp_SMOM_InitDataConversionSetupAttachment_Insert", paramList).FirstOrDefault();
                    response.Success = result > 0;
                    response.lng_InsertedId = result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;

        }

        public ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachment(int InitDataGeneralInfoId)
        {
            var response = new ApiResponse<InitDataConversionSetupAttachmentModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",InitDataGeneralInfoId)
                };

                var result = _repository.ExecuteSQL<InitDataConversionSetupAttachmentModel>(
                                "usp_SMOM_InitDataConversionSetupAttachment_Get", paramList).ToList();

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


        public ApiResponse<InitDataConversionSetupAttachmentModel> GetInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId)
        {
            var response = new ApiResponse<InitDataConversionSetupAttachmentModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataConversionSetupAttachmentId",InitDataConversionSetupAttachmentId)
                };

                var result = _repository.ExecuteSQL<InitDataConversionSetupAttachmentModel>(
                                "usp_SMOM_InitDataConversionSetupAttachment_GetById", paramList).ToList();
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

        public HttpResponseMessage DownloadInitDataConversionSetupAttachmentById(long InitDataConversionSetupAttachmentId)
        {
            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataConversionSetupAttachmentId",InitDataConversionSetupAttachmentId)
                };

                var result = _repository.ExecuteSQL<InitDataConversionSetupAttachmentModel>(
                                "usp_SMOM_InitDataConversionSetupAttachment_GetById", paramList).ToList();
                HttpResponseMessage httpResponseMessage;
                if (result != null && result.Count > 0)
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                    var response = new HttpResponseMessage();
                    response.Content = new ByteArrayContent(result[0].Attachment);
                    response.Content.Headers.ContentDisposition
                        = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = result[0].AttachmentName;
                    response.Content.Headers.ContentType
                        = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentLength = result[0].Attachment.Length;
                    return response;
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }


        public BaseApiResponse DeleteInitDataConversionSetupAttachment(long InitDataConversionSetupAttachmentId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("InitDataConversionSetupAttachmentId",InitDataConversionSetupAttachmentId)
                };

                var result = _repository.ExecuteSQL<int>("usp_SMOM_InitDataConversionSetupAttachment_Delete", paramList).FirstOrDefault();
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


        #endregion

        #region Push to production

        public BaseApiResponse PushToProduction(InitDataPushToProductionInputModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId",model.PlantId),
                    new SqlParameter("MoldNumber",model.MoldNumber),
                    new SqlParameter("UserId",model.UserId)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_InitData_PushToProduction", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion
    }
}