using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.CoverPage;
using GDS.Entities.SMOM.MachineLinearity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CoverPage
{
    public class CoverPageService : ICoverPageService
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
        private readonly IGenericRepository<CoverPageModel> _repository;

        #endregion

        #region ctor


        public CoverPageService(IGenericRepository<CoverPageModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<CoverPageModel> GetPlantListDropdown(int? PlantId, bool MoldflowShow,int UserId)
        {
            var response = new ApiResponse<CoverPageModel>();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantID",
                    DbType = DbType.Int32,
                    Value = (object)PlantId ?? DBNull.Value
                };
                var moldflowParam = new SqlParameter
                {
                    ParameterName = "MoldflowShow",
                    DbType = DbType.Boolean,
                    Value = (object)MoldflowShow
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId??DBNull.Value
                };
                var result = _repository.ExecuteSQL<CoverPageModel>("usp_PlantDropDown_get", plantIdParam, moldflowParam, UserIdParam).ToList();
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

        public ApiResponse<CoverPageModel> GetCoverPageDetail(int CoverPageId)
        {
            var response = new ApiResponse<CoverPageModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "p_CoverPageID",
                    DbType = DbType.Int32,
                    Value = (object)CoverPageId
                };

                var result = _repository.ExecuteSQL<CoverPageModel>("usp_smom_CoverPage_get", CoverPageIdParam).ToList();
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

        public ApiResponse<CoverPageModel> GetMoldFlowFilter(int PlantId, bool NeedExistingMoldOnly)
        {
            var response = new ApiResponse<CoverPageModel>();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId ?? DBNull.Value
                };
                var needExistingMoldOnlyParam = new SqlParameter
                {
                    ParameterName = "NeedExistingMoldOnly",
                    DbType = DbType.Boolean,
                    Value = (object)NeedExistingMoldOnly??(object)DBNull.Value
                };
                var result = _repository.ExecuteSQL<CoverPageModel>("usp_smom_InputData_GetInputDataByPlant", plantIdParam, needExistingMoldOnlyParam).ToList();
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


        public ApiResponse<CoverPageModel> GetCoverPageDetail_filter(int CoverPageId, int plantId, int PlantEquipmentListId, long inputDataId)
        {
            var response = new ApiResponse<CoverPageModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "p_CoverPageID",
                    DbType = DbType.Int32,
                    Value = (object)CoverPageId ?? DBNull.Value
                };

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)plantId ?? DBNull.Value
                };

                var PlantEquipmentListIdParam = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = (object)PlantEquipmentListId ?? DBNull.Value
                };

                var InputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int64,
                    Value = (object)inputDataId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<CoverPageModel>("usp_smom_LatestCoverPageList_get", CoverPageIdParam, PlantIdParam, PlantEquipmentListIdParam, InputDataIdParam).ToList();
                if (result.Count > 1)
                {
                    result[0].CoverPageIdTool = result[1].CoverPageId;
                    result[0].InputDataId = result[1].InputDataId;
                }
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


        public ApiResponse<CoverPageHistoryModel> GetOlderCoverPageByCoverPageId(int CoverPageId, int plantId, int PlantEquipmentListId, int inputDataId)
        {
            var response = new ApiResponse<CoverPageHistoryModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = (object)CoverPageId
                };

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)plantId
                };

                var PlantEquipmentListIdParam = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = (object)PlantEquipmentListId
                };

                var InputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int32,
                    Value = (object)inputDataId
                };

                var result = _repository.ExecuteSQL<CoverPageHistoryModel>("usp_smom_OlderCoverPageListByCoverPageId_get", CoverPageIdParam, PlantIdParam, PlantEquipmentListIdParam, InputDataIdParam).ToList();
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


        public BaseApiResponse SaveCoverPageDetail(CoverPageModel model)
        {
            model.CoverPageDate = DateTime.Now;
            var response = new BaseApiResponse();
            try
            {

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)model.PlantId ?? DBNull.Value
                };

                var InputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int32,
                    Value = (object)model.InputDataId ?? DBNull.Value
                };

                var PlantEquipmentListIdParam = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = (object)model.PlantEquipmentListId ?? DBNull.Value
                };
                var CoverPageDateParam = new SqlParameter
                {
                    ParameterName = "CoverPageDate",
                    DbType = DbType.Date,
                    IsNullable = true,
                    Value = (object)model.CoverPageDate
                };

                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)model.LoggedInUserId
                };

                var IdentificationTextParam = new SqlParameter
                {
                    ParameterName = "IdentificationText",
                    DbType = DbType.String,
                    Value = (object)model.IdentificationText
                };


                var result = _repository.ExecuteSQL<long>("usp_smom_CoverPageDetail_Save", PlantIdParam, InputDataIdParam, PlantEquipmentListIdParam, CoverPageDateParam, LoggedInUserIdParam, IdentificationTextParam).FirstOrDefault();
                response.Success = true;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public ApiResponse<CoverPageMachineConfigurationModel> GetMachineConfigurationForPlasticPressure( Int16 lengthUnitId, Int16 pressureUnitId, long? CoverPageIdTool = null)
        {
            var response = new ApiResponse<CoverPageMachineConfigurationModel>();
            response.Data = new List<CoverPageMachineConfigurationModel>();
            try
            {
               

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = pressureUnitId
                };

                var CoverPageIdToolParam = new SqlParameter
                {
                    ParameterName = "p_CoverPageIDTool",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageIdTool ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<CoverPageMachineConfiguration>("GetMachineConfigurationForPlasticPressure",  LengthUnitIdParam, PressureUnitIdParam, CoverPageIdToolParam).ToList();
                CoverPageMachineConfigurationModel objMachineLinearityModel = new CoverPageMachineConfigurationModel();
                if (result.Any())
                {
                    if (result.Count > 1)
                    {
                        //-----result[1] = second rows from result set is always tool specific Coverpage ID------///
                        result[0].CoverPageIdTool = result[1].CoverPageId;
                        result[0].InputDataId = result[1].InputDataId;
                    }
                    objMachineLinearityModel.CoverPageMachineConfigurationDetails = result.FirstOrDefault();
                    
                }
                response.Success = true;
                response.Data.Add(objMachineLinearityModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }



        public ApiResponse<CoverPageMachineConfigurationModel> GetCoverPageMachineConfiguration(long? CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId, bool getAllData = false, long? CoverPageIdTool = null)
        {
            var response = new ApiResponse<CoverPageMachineConfigurationModel>();
            response.Data = new List<CoverPageMachineConfigurationModel>();
            try
            {
                var CoverPageIdPressParam = new SqlParameter
                {
                    ParameterName = "p_CoverPageIDPress",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId ?? DBNull.Value
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = pressureUnitId
                };

                var CoverPageIdToolParam = new SqlParameter
                {
                    ParameterName = "p_CoverPageIDTool",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageIdTool ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<CoverPageMachineConfiguration>("usp_smom_CoverPageMachineConfg_getByCoverPageID", CoverPageIdPressParam, LengthUnitIdParam, PressureUnitIdParam, CoverPageIdToolParam).ToList();
                CoverPageMachineConfigurationModel objMachineLinearityModel = new CoverPageMachineConfigurationModel();
                if (result.Any())
                {
                    if (result.Count > 1)
                    {
                        //-----result[1] = second rows from result set is always tool specific Coverpage ID------///
                        result[0].CoverPageIdTool = result[1].CoverPageId;
                        result[0].InputDataId = result[1].InputDataId;
                    }
                    objMachineLinearityModel.CoverPageMachineConfigurationDetails = result.FirstOrDefault();
                    if (getAllData && CoverPageId != null)
                    {
                        GetMachineLinearityPositionSetting(objMachineLinearityModel, lengthUnitId, CoverPageId.Value);

                        long machineLinearityPositionSettingId = 0;
                        if (objMachineLinearityModel.PositionSettingDetails != null && objMachineLinearityModel.PositionSettingDetails.MachineLinearityPositionSettingId > 0)
                        {
                            machineLinearityPositionSettingId = objMachineLinearityModel.PositionSettingDetails.MachineLinearityPositionSettingId;
                        }
                        if (objMachineLinearityModel.CoverPageMachineConfigurationDetails?.MaxInjectionSpeed != null && objMachineLinearityModel.CoverPageMachineConfigurationDetails.MaxInjectionSpeed > 0)
                        {
                            GetMachineShotWithParts(objMachineLinearityModel, machineLinearityPositionSettingId);
                            GetMachineLinearityAirShot(objMachineLinearityModel, machineLinearityPositionSettingId);
                        }

                        if (objMachineLinearityModel.PositionSettingDetails == null)
                        {
                            objMachineLinearityModel.PositionSettingDetails = new MachineLinearityPositionSetting();
                        }
                    }
                }
                response.Success = true;
                response.Data.Add(objMachineLinearityModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        private void GetMachineLinearityPositionSetting(CoverPageMachineConfigurationModel obj, Int16 lengthUnitId, long coverPageId)
        {
            var CoverPageId = new SqlParameter
            {
                ParameterName = "CoverPageId",
                DbType = DbType.Int64,
                Value = coverPageId
            };
            var LengthUnitId = new SqlParameter
            {
                ParameterName = "LengthUnitId",
                DbType = DbType.Int16,
                Value = lengthUnitId
            };

            obj.PositionSettingDetails = _repository.ExecuteSQL<MachineLinearityPositionSetting>("usp_smom_MachineLinearityPositionSetting_get", CoverPageId, LengthUnitId).ToList().FirstOrDefault();
        }

        private void GetMachineShotWithParts(CoverPageMachineConfigurationModel obj, long machineLinearityPositionSettingId)
        {
            var MaxInjectionSpeed = new SqlParameter
            {
                ParameterName = "MaxInjectionSpeed",
                DbType = DbType.Double,
                Value = obj.CoverPageMachineConfigurationDetails.MaxInjectionSpeed
            };
            var MachineLinearityPositionSettingId = new SqlParameter
            {
                ParameterName = "MachineLinearityPositionSettingId",
                DbType = DbType.Int64,
                Value = machineLinearityPositionSettingId
            };

            obj.ShotWithPartsList = _repository.ExecuteSQL<MachineLinearityShotWithParts>("usp_smom_MachineLinearityShotWithPart_get", MaxInjectionSpeed, MachineLinearityPositionSettingId).ToList();
        }

        private void GetMachineLinearityAirShot(CoverPageMachineConfigurationModel obj, long machineLinearityPositionSettingId)
        {
            var MaxInjectionSpeed = new SqlParameter
            {
                ParameterName = "MaxInjectionSpeed",
                DbType = DbType.Double,
                Value = obj.CoverPageMachineConfigurationDetails.MaxInjectionSpeed
            };
            var MachineLinearityPositionSettingId = new SqlParameter
            {
                ParameterName = "MachineLinearityPositionSettingId",
                DbType = DbType.Int64,
                Value = machineLinearityPositionSettingId
            };
            obj.AirShotList = _repository.ExecuteSQL<MachineLinearityAirShot>("usp_smom_MachineLinearityAirShot_get", MaxInjectionSpeed, MachineLinearityPositionSettingId).ToList();
        }


        public ApiResponse<CoverPageMoldFlow> GetMoldFlowPageRecords(string MoldNumber)
        {
            var response = new ApiResponse<CoverPageMoldFlow>();

            try
            {
                var MoldNumberParam = new SqlParameter
                {
                    ParameterName = "MoldNumber",
                    DbType = DbType.String,
                    Value = (object)MoldNumber
                };

                var result = _repository.ExecuteSQL<CoverPageMoldFlow>("usp_smom_MoldFlowPopup_get", MoldNumberParam).ToList();
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


        public ApiResponse<CoverPageMoldFlow> GetMoldList(int LoggedInUserId)
        {
            var response = new ApiResponse<CoverPageMoldFlow>();

            try
            {
                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)LoggedInUserId
                };
                var result = _repository.ExecuteSQL<CoverPageMoldFlow>("usp_smom_MoldFlowPopupMoldList_get", LoggedInUserIdParam).ToList();
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

        public ApiResponse<CoverPageDataCountModel> GetCoverPageDataCount(long? CoverPageIdPress, long? CoverPageIdTool)
        {
            var response = new ApiResponse<CoverPageDataCountModel>();

            try
            {
                object[] paramList =
             {
                    new SqlParameter("CoverPageIdPress",(object)CoverPageIdPress ?? DBNull.Value),
                    new SqlParameter("CoverPageIdTool",(object)CoverPageIdTool ?? DBNull.Value)
                };


                var result = _repository.ExecuteSQL<CoverPageDataCountModel>("usp_smom_GetCoverPageDataCount", paramList).ToList();
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

        public ApiResponse<IMPDRedirectParamsFromInputDataId> GetIMPDRedirectParamsFromInputDataId(long inputDataId)
        {
            var response = new ApiResponse<IMPDRedirectParamsFromInputDataId>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InputDataId",inputDataId)
                };

                var result = _repository.ExecuteSQL<IMPDRedirectParamsFromInputDataId>("usp_smom_GetIMPDRedirectParamsFromInputDataId", paramList).ToList();
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
    }
}
