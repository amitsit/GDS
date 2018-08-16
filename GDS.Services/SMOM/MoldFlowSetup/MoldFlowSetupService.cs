using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.SMOM.MoldFlowSetup;
using static GDS.Entities.SMOM.MoldFlowSetup.MoldFlowInsertFileModel;

namespace GDS.Services.SMOM.MoldFlowSetup
{
    public class MoldFlowSetupService : IMoldFlowSetupService
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
        private readonly IGenericRepository<ManualInputModel> _repository;

        #endregion

        #region ctor


        public MoldFlowSetupService(IGenericRepository<ManualInputModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        #region Mold Flow Header

        public ApiResponse<MoldFlowHeaderModel> GetMoldFlowListForDropDown()
        {
            var response = new ApiResponse<MoldFlowHeaderModel>();

            try
            {
                var result = _repository.ExecuteSQL<MoldFlowHeaderModel>("usp_smom_MoldFlowSetup_Header_GetMoldFlowListForDropDown").ToList();
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

        public ApiResponse<MoldFlowHeaderModel> GetMoldFlowListByProgram(long? ProgramId, int? ConversionMode, int UserId)
        {
            var response = new ApiResponse<MoldFlowHeaderModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ProgramId",(object)ProgramId??(object)DBNull.Value)
                    , new SqlParameter("ConversionMode",(object)ConversionMode??(object)DBNull.Value)
                    ,  new SqlParameter("UserId",(object)UserId??(object)DBNull.Value)
                };

                var result = _repository.ExecuteSQL<MoldFlowHeaderModel>("usp_smom_MoldFlowSetup_Header_GetMoldFlowListByProgram", paramList).ToList();
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

        #region Manual Input

        public ApiResponse<ManualInputModel> GetManualInput(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<ManualInputModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<ManualInputModel>("usp_smom_MoldFlowSetup_ManualInput_GetManualInput", paramList).ToList();
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

        public ApiResponse<ManualInputModel> GetManualInputFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<ManualInputModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("GUID",GUID),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<ManualInputModel>("usp_smom_MoldFlowSetup_ManualInput_GetManualInputFromGUID", paramList).ToList();
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

        public BaseApiResponse SaveManualInput(ManualInputModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    new SqlParameter("MeltTemp",(object)model.MeltTemp ?? DBNull.Value),
                    new SqlParameter("MoldCavitySideTemp",(object)model.MoldCavitySideTemp ?? DBNull.Value),
                    new SqlParameter("MoldCoreSideTemp",(object)model.MoldCoreSideTemp ?? DBNull.Value),
                    new SqlParameter("NominalFlowRate",(object)model.NominalFlowRate ?? DBNull.Value),
                    new SqlParameter("TotalVolumeOfThePartsAndRunners",(object)model.TotalVolumeOfThePartsAndRunners ?? DBNull.Value),
                    new SqlParameter("SwitchOverPressure",(object)model.SwitchOverPressure ?? DBNull.Value),
                    new SqlParameter("MaxClampForceRequired",(object)model.MaxClampForceRequired ?? DBNull.Value),
                    new SqlParameter("VolumeFilledInitially",(object)model.VolumeFilledInitially ?? DBNull.Value),
                    new SqlParameter("VolumeToBeFilled",(object)model.VolumeToBeFilled ?? DBNull.Value),
                    new SqlParameter("TotalProjectedArea",(object)model.TotalProjectedArea ?? DBNull.Value),
                    new SqlParameter("ClampForceMaximum",(object)model.ClampForceMaximum ?? DBNull.Value),
                    new SqlParameter("TotalPartWeightExcludingRunners",(object)model.TotalPartWeightExcludingRunners ?? DBNull.Value),
                    new SqlParameter("TotalPartWeightMaximum",(object)model.TotalPartWeightMaximum ?? DBNull.Value),
                    new SqlParameter("MaximumInjectionPressure",(object)model.MaximumInjectionPressure ?? DBNull.Value),
                    new SqlParameter("TimeAtTheEndOfFilling",(object)model.TimeAtTheEndOfFilling ?? DBNull.Value),
                    new SqlParameter("TotalWeightPartsPlusRunnersFillWeight",(object)model.TotalWeightPartsPlusRunnersFillWeight ?? DBNull.Value),
                    new SqlParameter("TotalWeightExcludingRunnersFillWeight",(object)model.TotalWeightExcludingRunnersFillWeight ?? DBNull.Value),
                    new SqlParameter("PackingPhase",(object)model.PackingPhase ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_MoldFlowSetup_ManualInput_SaveManualInput", paramList).FirstOrDefault();
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

        #region Valve Gate Position

        public ApiResponse<ValveGatePositionModel> GetValveGatePosition(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<ValveGatePositionModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<ValveGatePositionModel>("usp_smom_ValveGatePosition_GetValveGatePosition", paramList).ToList();
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

        public ApiResponse<ValveGatePositionModel> GetValveGatePositionFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<ValveGatePositionModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("GUID",GUID),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<ValveGatePositionModel>("usp_smom_ValveGatePositionFromGUID_GetValveGatePosition", paramList).ToList();
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

        public BaseApiResponse SaveValveGatePosition(List<ValveGatePositionModel> model, long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId, int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var valveGatePositionxml = ConvertToXml<ValveGatePositionModel>.GetXMLString(model);

                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId", lengthUnitId),
                    new SqlParameter("PressureUnitId", pressureUnitId),
                    new SqlParameter("LoggedInUserId",loggedInUserId),
                    new SqlParameter("ValveGatePositionxml",valveGatePositionxml),
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_ValveGatePosition_SaveValveGatePosition", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse CreateMoldFlowHeader_PostProduction(long? ProgramId, long? InputDataId, int UserId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("ProgramId",(object)ProgramId??(object)DBNull.Value),
                    new SqlParameter("InputDataId",(object)InputDataId??(object)DBNull.Value ),
                    new SqlParameter("UserId",(object)UserId??(object)DBNull.Value )
                };

                var result = _repository.ExecuteSQL<int>("CreateDefaultHeaderForMoldinPostProduction", paramList).FirstOrDefault();
                response.Success = result > 0;
                if (result > 0)
                {
                    response.InsertedId = result;
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

        #region General Information
        public BaseApiResponse ValidateMoldNumber(string MoldNumber, long? MoldFlowGeneralInfoId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("MoldFlowGeneralInfoId",(object)MoldFlowGeneralInfoId??(object)DBNull.Value),
                    new SqlParameter("MoldNumber",(object)MoldNumber??(object)DBNull.Value )
                };

                var result = _repository.ExecuteSQL<long>("usp_ValidateMoldNumber", paramList).FirstOrDefault();
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

        public ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfo(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowGeneralInfoModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowGeneralInfoModel>("usp_smom_MoldFlow_GeneralInfo_Get", paramList).ToList();
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

        public ApiResponse<MoldFlowGeneralInfoModel> GetMoldFlowGeneralInfoFromGUID(string GUID)
        {
            var response = new ApiResponse<MoldFlowGeneralInfoModel>();

            try
            {
                var GUIDParam = new SqlParameter
                {
                    ParameterName = "GUID",
                    DbType = DbType.String,
                    Value = (object)GUID
                };

                var result = _repository.ExecuteSQL<MoldFlowGeneralInfoModel>("usp_smom_MoldFlow_GeneralInfoFromGUID_Get", GUIDParam).ToList();
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

        public BaseApiResponse SaveMoldFlowGeneralInfo(int? FinalizeMoldflowSetup, bool? IsExistingMold, MoldFlowGeneralInfoModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                   
                    //new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    //new SqlParameter("PlantId",model.PlantId),
                    //new SqlParameter("ProgramID",(object)model.ProgramID??(object)DBNull.Value),                    
                    //new SqlParameter("MoldNumber",model.MoldNumber ),
                    //new SqlParameter("MoldFlowSetupHeaderId", (object)model.MoldFlowSetupHeaderId?? DBNull.Value),
                    //new SqlParameter("JobName",model.JobName),
                    //new SqlParameter("IdentificationText",(object)model.IdentificationText??(object)DBNull.Value),
                    //new SqlParameter("PlantEquipmentListId",model.PlantEquipmentListId),
                    //new SqlParameter("Date",model.Date.Year==1?DateTime.Now:model.Date),
                    //new SqlParameter("MaterialId",model.MaterialId),
                    //new SqlParameter("SpecificGravity",(object)model.SpecificGravity??(object)DBNull.Value),
                    //new SqlParameter("MeltDensity",(object)model.MeltDensity??(object)DBNull.Value),
                    //new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    //new SqlParameter("LengthUnitId",model.LengthUnitId),
                    //new SqlParameter("PressureUnitId",model.PressureUnitId),
                    //new SqlParameter("SpecialNote_Issue", (object)model.SpecialNote_Issue?? DBNull.Value),
                    //new SqlParameter("FinalizeMoldflowSetup",(object)FinalizeMoldflowSetup??(object)DBNull.Value),
                    //new SqlParameter("IsExistingMold",(object)IsExistingMold??(object)DBNull.Value)


                    new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    new SqlParameter("PlantId",(object)model.PlantId??(object)DBNull.Value ),
                    new SqlParameter("ProgramID",(object)model.ProgramID??(object)DBNull.Value),
                    new SqlParameter("MoldNumber",model.MoldNumber ),
                    new SqlParameter("MoldFlowSetupHeaderId", (object)model.MoldFlowSetupHeaderId?? DBNull.Value),
                    new SqlParameter("JobName",(object)model.JobName??(object)DBNull.Value),
                    new SqlParameter("IdentificationText",(object)model.IdentificationText??(object)DBNull.Value),
                    new SqlParameter("PlantEquipmentListId",(object)model.PlantEquipmentListId??(object)DBNull.Value),
                    new SqlParameter("Date",model.Date.Year==1?DateTime.Now:model.Date),
                    new SqlParameter("MaterialId",(object)model.MaterialId??(object)DBNull.Value),
                    new SqlParameter("SpecificGravity",(object)model.SpecificGravity??(object)DBNull.Value),
                    new SqlParameter("MeltDensity",(object)model.MeltDensity??(object)DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("SpecialNote_Issue", (object)model.SpecialNote_Issue?? DBNull.Value),
                    new SqlParameter("FinalizeMoldflowSetup",(object)FinalizeMoldflowSetup??(object)DBNull.Value),
                    new SqlParameter("IsExistingMold",(object)IsExistingMold??(object)DBNull.Value),
                    new SqlParameter("MoldIsAlreadyInProduction",(object)model.MoldIsAlreadyInProduction?? DBNull.Value),
                    new SqlParameter("chkIsVoidCalculative",(object)model.chkIsVoidCalculative?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<long>("usp_smom_MoldFlow_GeneralInfo_Save", paramList).FirstOrDefault();
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

        public ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPosition(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowShotPositioinModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowShotPositioinModel>("usp_smom_MoldFlow_ShotPositions_Get", paramList).ToList();
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

        public ApiResponse<MoldFlowShotPositioinModel> GetMoldFlowShotPositionFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowShotPositioinModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("GUID",GUID),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowShotPositioinModel>("usp_smom_MoldFlow_ShotPositionsFromGUID_Get", paramList).ToList();
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


        public BaseApiResponse SaveMoldFlowShotPosition(MoldFlowShotPositioinModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
               {
                    new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    new SqlParameter("Cushion",(object)model.Cushion?? DBNull.Value),
                    new SqlParameter("ShotSize",(object)model.ShotSize ?? DBNull.Value),
                    new SqlParameter("Transfer",(object)model.Transfer?? DBNull.Value),
                    new SqlParameter("CubicVolumnTransfer",(object)model.CubicVolumnTransfer?? DBNull.Value),
                    new SqlParameter("TotalCubicVolume",(object)model.TotalCubicVolumn?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),

                };

                var result = _repository.ExecuteSQL<int>("usp_smom_MoldFlow_Shotposition_Save", paramList).FirstOrDefault();
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

        public ApiResponse<MoldFlowPressureModel> GetMoldFlowPressure(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowPressureModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowPressureModel>("usp_smom_MoldFlow_Pressure_Get", paramList).ToList();
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

        public ApiResponse<MoldFlowPressureModel> GetMoldFlowPressureFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowPressureModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("GUID",GUID),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowPressureModel>("usp_smom_MoldFlow_PressureFromGUID_Get", paramList).ToList();
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

        public BaseApiResponse SaveMoldFlowPressure(MoldFlowPressureModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
               {
                    new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    new SqlParameter("HydraulicTransfer",(object)model.HydraulicTransfer ?? DBNull.Value),
                    new SqlParameter("PlasticTransfer",(object)model.PlasticTransfer ?? DBNull.Value),
                    new SqlParameter("HydraulicPack",(object)model.HydraulicPack ?? DBNull.Value),
                    new SqlParameter("PlasticPack",(object)model.PlasticPack ?? DBNull.Value),
                    new SqlParameter("HydaulicHold",(object)model.HydaulicHold ?? DBNull.Value),
                    new SqlParameter("PlasticHold",(object)model.PlasticHold ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_MoldFlow_Pressure_Save", paramList).FirstOrDefault();
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

        public ApiResponse<MoldFlowTimerModel> GetMoldFlowTimer(long moldFlowGeneralInfoId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowTimerModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowGeneralInfoId",moldFlowGeneralInfoId),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowTimerModel>("usp_smom_MoldFlow_Timer_Get", paramList).ToList();
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

        public ApiResponse<MoldFlowTimerModel> GetMoldFlowTimerFromGUID(string GUID, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<MoldFlowTimerModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("GUID",GUID),
                    new SqlParameter("LengthUnitId",lengthUnitId),
                    new SqlParameter("PressureUnitId",pressureUnitId)
                };

                var result = _repository.ExecuteSQL<MoldFlowTimerModel>("usp_smom_MoldFlow_TimerFromGUID_Get", paramList).ToList();
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

        public BaseApiResponse SaveMoldFlowTimer(MoldFlowTimerModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("MoldFlowGeneralInfoId",model.MoldFlowGeneralInfoId),
                    new SqlParameter("Fill",(object)model.Fill ?? DBNull.Value),
                    new SqlParameter("Pack",(object)model.Pack ?? DBNull.Value),
                    new SqlParameter("Hold",(object)model.Hold ?? DBNull.Value),
                    new SqlParameter("Cooling",(object)model.Cooling ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId)

                };

                var result = _repository.ExecuteSQL<int>("usp_smom_MoldFlow_Timer_Save", paramList).FirstOrDefault();
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

        #region Moldflow Version List

        public ApiResponse<MoldFlowVersionModel> GetMoldFlowVersion(long moldFlowHeaderId)
        {
            var response = new ApiResponse<MoldFlowVersionModel>();
            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowHeaderId",moldFlowHeaderId),
                };

                var result = _repository.ExecuteSQL<MoldFlowVersionModel>("usp_smom_MoldFlow_VersionList", paramList).ToList();
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


        #region
        public BaseApiResponse UploadMoldFlowDataFile(MoldFlowInsertFileModel MoldFlowFileModel)
        {
            var response = new BaseApiResponse();
           
            try
            {
                var valveGatePositionxml = ConvertToXml<ValveGatePositionsCell>.GetXMLString(MoldFlowFileModel.Valvegatelist);

                object[] paramList =
               {
                new SqlParameter("UserId",(object)MoldFlowFileModel.UserId?? DBNull.Value),

                new SqlParameter("MoldFlowSetup_GeneralInfo_PlantName",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_PlantName?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_GeneralInfo_MoldNumber",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_MoldNumber?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_GeneralInfo_JobName",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_JobName?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_GeneralInfo_PressNumber",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_PressNumber?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_GeneralInfo_Date",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_Date?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_GeneralInfo_MaterialName",(object)MoldFlowFileModel.MoldFlowSetup_GeneralInfo_MaterialName.Split(':')[0].Trim()?? DBNull.Value),

                new SqlParameter("MoldFlowSetup_MoldTemp_Stationary",(object)MoldFlowFileModel.MoldFlowSetup_MoldTemp_Stationary?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_MoldTemp_Moveable",(object)MoldFlowFileModel.MoldFlowSetup_MoldTemp_Moveable?? DBNull.Value),

                new SqlParameter("MoldFlowSetup_ShotPosition_ShotSize",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_ShotSize?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_Transfer",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_Transfer?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_Cushion",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_Cushion?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_CubicVolumnTransfer",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_CubicVolumnTransfer?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_TotalCubicVolumn",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_TotalCubicVolumn?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_ShrinkRateMoldIsCutTo",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_ShrinkRateMoldIsCutTo?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_MeltSolidRatio",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_MeltSolidRatio?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_VolumefromAnalysisin3",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_VolumefromAnalysisin3?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_MeltDensity",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_MeltDensity?? DBNull.Value),
                new SqlParameter("MoldFlowSetup_ShotPosition_SolidDensity",(object)MoldFlowFileModel.MoldFlowSetup_ShotPosition_SolidDensity?? DBNull.Value),

                new SqlParameter("MoldFlow_Pressure_HydraulicTransfer",(object)MoldFlowFileModel.MoldFlow_Pressure_HydraulicTransfer?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_PlasticTransfer",(object)MoldFlowFileModel.MoldFlow_Pressure_PlasticTransfer?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_HydraulicPack",(object)MoldFlowFileModel.MoldFlow_Pressure_HydraulicPack?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_PlasticPack",(object)MoldFlowFileModel.MoldFlow_Pressure_PlasticPack?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_HydaulicHold",(object)MoldFlowFileModel.MoldFlow_Pressure_HydaulicHold?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_PlasticHold",(object)MoldFlowFileModel.MoldFlow_Pressure_PlasticHold?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_HydaulicTonnage",(object)MoldFlowFileModel.MoldFlow_Pressure_HydaulicTonnage?? DBNull.Value),
                new SqlParameter("MoldFlow_Pressure_PlasticTonnage",(object)MoldFlowFileModel.MoldFlow_Pressure_PlasticTonnage?? DBNull.Value),

                new SqlParameter("MoldFlow_Timer_Fill",(object)MoldFlowFileModel.MoldFlow_Timer_Fill?? DBNull.Value),
                new SqlParameter("MoldFlow_Timer_Pack",(object)MoldFlowFileModel.MoldFlow_Timer_Pack?? DBNull.Value),
                new SqlParameter("MoldFlow_Timer_Hold",(object)MoldFlowFileModel.MoldFlow_Timer_Hold?? DBNull.Value),
                new SqlParameter("MoldFlow_Timer_Cooling",(object)MoldFlowFileModel.MoldFlow_Timer_Cooling?? DBNull.Value),
                new SqlParameter("VIPOfAnalysis",(object)MoldFlowFileModel.VIPOfAnalysis?? DBNull.Value),

                new SqlParameter("MoldFlowGeneralInfoId",(object)MoldFlowFileModel.MoldFlowGeneralInfoId?? DBNull.Value),
                new SqlParameter("MeltTemp",(object)MoldFlowFileModel.MeltTemp?? DBNull.Value),
                new SqlParameter("MoldCavitySideTemp",(object)MoldFlowFileModel.MoldCavitySideTemp?? DBNull.Value),
                new SqlParameter("MoldCoreSideTemp",(object)MoldFlowFileModel.MoldCoreSideTemp?? DBNull.Value),
                new SqlParameter("TimeAtTheEndOfFilling",(object)MoldFlowFileModel.TimeAtTheEndOfFilling?? DBNull.Value),
                new SqlParameter("SwitchOverPressure",(object)MoldFlowFileModel.SwitchOverPressure?? DBNull.Value),
                new SqlParameter("MaximumInjectionPressure",(object)MoldFlowFileModel.MaximumInjectionPressure?? DBNull.Value),
                new SqlParameter("PackingPhase",(object)MoldFlowFileModel.PackingPhase?? DBNull.Value),
                new SqlParameter("ClampForceMaximum",(object)MoldFlowFileModel.ClampForceMaximum?? DBNull.Value),
                new SqlParameter("MaxClampForceRequired",(object)MoldFlowFileModel.MaxClampForceRequired?? DBNull.Value),
                new SqlParameter("NominalFlowRate",(object)MoldFlowFileModel.NominalFlowRate?? DBNull.Value),
                new SqlParameter("TotalVolumeOfThePartsAndRunners",(object)MoldFlowFileModel.TotalVolumeOfThePartsAndRunners?? DBNull.Value),
                new SqlParameter("VolumeFilledInitially",(object)MoldFlowFileModel.VolumeFilledInitially?? DBNull.Value),
                new SqlParameter("VolumeToBeFilled",(object)MoldFlowFileModel.VolumeToBeFilled?? DBNull.Value),
                new SqlParameter("TotalProjectedArea",(object)MoldFlowFileModel.TotalProjectedArea?? DBNull.Value),
                new SqlParameter("TotalPartWeightExcludingRunners",(object)MoldFlowFileModel.TotalPartWeightExcludingRunners?? DBNull.Value),
                new SqlParameter("TotalPartWeightMaximum",(object)MoldFlowFileModel.TotalPartWeightMaximum?? DBNull.Value),
                new SqlParameter("TotalWeightPartsPlusRunnersFillWeight",(object)MoldFlowFileModel.TotalWeightPartsPlusRunnersFillWeight?? DBNull.Value),
                new SqlParameter("TotalWeightExcludingRunnersFillWeight",(object)MoldFlowFileModel.TotalWeightExcludingRunnersFillWeight?? DBNull.Value),


                new SqlParameter("ValveGatePositionxml",valveGatePositionxml),

               };

                var result = _repository.ExecuteSQL<string>("usp_moldflowdata_insertFromFile", paramList).FirstOrDefault();
                response.Success = (result != "");
                response.Message.Add(result);
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
        #endregion
    }
}