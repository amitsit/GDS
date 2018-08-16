using GDS.Entities.STMP.InputData;

namespace GDS.Services.STMP.InputData
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Common;
    using Entities;
    using Data.Repository;
    using Entities.Master;

    public class InputDataService : IInputDataService
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
        private readonly IGenericRepository<STMPInputDataModel> _repository;
        
        #endregion

        #region ctor

        
        public InputDataService(IGenericRepository<STMPInputDataModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<STMPInputDataModel> GetInputData(long? inputDataId)
        {
            var response = new ApiResponse<STMPInputDataModel>();

            try
            {
                var inputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int64,
                    Value = (object)inputDataId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<STMPInputDataModel>("usp_stmp_InputData_GetInputData_UsingMultipleProgram", inputDataIdParam).ToList();
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

        public ApiResponse<STMPInputDataModel> GetInputDataList(int UserId, int PlantId, string sortColumn, string searchValue, TableParameter<STMPInputDataModel> tableParameter)
        {
            var response = new ApiResponse<STMPInputDataModel>();

            try
            {
            
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId
                };

                var OrderByParam = new SqlParameter
                {
                    ParameterName = "OrderBy",
                    DbType = DbType.String,
                    Value = (object)sortColumn
                };

                var PageIndexParam = new SqlParameter
                {
                    ParameterName = "PageIndex",
                    DbType = DbType.Int32,
                    Value = (object)tableParameter != null ? tableParameter.PageIndex : 1
                };

                var PageSizeParam = new SqlParameter
                {
                    ParameterName = "PageSize",
                    DbType = DbType.Int32,
                    Value = (object)tableParameter != null ? tableParameter.iDisplayLength : 10
                };

                var SearchValueParam = new SqlParameter
                {
                    ParameterName = "SearchValue",
                    DbType = DbType.String,
                    Value = (object)searchValue
                };


                var result = _repository.ExecuteSQL<STMPInputDataModel>("usp_stmp_InputData_GetInputDataList_UsingMultipleProgram", UserIdParam, PlantIdParam, OrderByParam, PageIndexParam, PageSizeParam, SearchValueParam).ToList();
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

        public ApiResponse<ProgramMasterModel> GetPrograms()
        {
            var response = new ApiResponse<ProgramMasterModel>();

            try
            {
                var result = _repository.ExecuteSQL<ProgramMasterModel>("usp_ProgramMaster_GetPrograms").ToList();
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

        public BaseApiResponse SaveInputData(STMPInputDataModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters

                var inputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int64,
                    Value = model.InputDataId
                };


                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)model.PlantId ?? DBNull.Value
                };

                var programIdParam = new SqlParameter
                {
                    ParameterName = "ProgramIds",
                    DbType = DbType.String,
                    Value = (object)model.ProgramIds ?? DBNull.Value
                };

                var toolParam = new SqlParameter
                {
                    ParameterName = "Tool",
                    DbType = DbType.String,
                    Value = (object)model.Tool ?? DBNull.Value
                };

                var partDescriptionParam = new SqlParameter
                {
                    ParameterName = "PartDescription",
                    DbType = DbType.String,
                    Value = (object)model.PartDescription ?? DBNull.Value
                };

                var moldOeeParam = new SqlParameter
                {
                    ParameterName = "MoldOEE",
                    DbType = DbType.String,
                    Value = (object)model.MoldOEE ?? DBNull.Value
                };

                var totalMoldCavitiesParam = new SqlParameter
                {
                    ParameterName = "TotalMoldCavites",
                    DbType = DbType.Double,
                    Value = (object)model.TotalMoldCavites ?? DBNull.Value
                };
                var costedCycleParam = new SqlParameter
                {
                    ParameterName = "CostedCycle",
                    DbType = DbType.Double,
                    Value = (object)model.CostedCycle ?? DBNull.Value
                };

                var actualCycleParam = new SqlParameter
                {
                    ParameterName = "ActualCycle",
                    DbType = DbType.Double,
                    Value = (object)model.ActualCycle ?? DBNull.Value
                };

                var cavityInVehicleSetsParam = new SqlParameter
                {
                    ParameterName = "CavityInVehicleSets",
                    DbType = DbType.Double,
                    Value = (object)model.CavityInVehicleSets ?? DBNull.Value
                };

                var rqeuiredOpsParam = new SqlParameter
                {
                    ParameterName = "RequiredOps",
                    DbType = DbType.Double,
                    Value = (object)model.RequiredOps ?? DBNull.Value
                };

                var valueParam = new SqlParameter
                {
                    ParameterName = "Value",
                    DbType = DbType.Double,
                    Value = (object)model.Value ?? DBNull.Value
                };

                var isActiveMoldParam = new SqlParameter
                {
                    ParameterName = "IsActiveMold",
                    DbType = DbType.Boolean,
                    Value = (object)model.IsActiveMold ?? DBNull.Value
                };
                var isActiveSMOMParam = new SqlParameter
                {
                    ParameterName = "IsActiveSMOM",
                    DbType = DbType.Boolean,
                    Value = (object)model.IsActiveSMOM ?? DBNull.Value
                };

                var currentUserParam = new SqlParameter
                {
                    ParameterName = "CurrentUser",
                    DbType = DbType.Int32,
                    Value = (object)model.CurrnetUser ?? DBNull.Value
                };

                #endregion

                var result = _repository.ExecuteSQL<int>("usp_stmp_InputData_SaveInputData_UsingMultipleProgram"
                            , inputDataIdParam //, plantMonthYearIdParam 
                            , plantIdParam, programIdParam, toolParam, partDescriptionParam, moldOeeParam, totalMoldCavitiesParam, costedCycleParam
                            , actualCycleParam,cavityInVehicleSetsParam, rqeuiredOpsParam, valueParam, isActiveMoldParam, isActiveSMOMParam, currentUserParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public BaseApiResponse SaveInputData_InitialDataConverstion(bool? IsExistingMold, int? MoldFlowSetupHeaderId,STMPInputDataModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters               

                object[] paramList =
              {
                    new SqlParameter("InputDataId", (object)model.InputDataId?? DBNull.Value),
                    new SqlParameter("PlantId", (object)model.PlantId ?? DBNull.Value),
                    new SqlParameter("ProgramIds", (object)model.ProgramIds ?? DBNull.Value),
                    new SqlParameter("Tool",(object)model.Tool ?? DBNull.Value),
                    new SqlParameter("PartDescription",(object)model.PartDescription ?? DBNull.Value),
                    new SqlParameter("MoldOEE", (object)model.MoldOEE ?? DBNull.Value),
                    new SqlParameter("TotalMoldCavites", (object)model.TotalMoldCavites ?? DBNull.Value),
                    new SqlParameter("CostedCycle", (object)model.CostedCycle ?? DBNull.Value),
                    new SqlParameter("ActualCycle", (object)model.ActualCycle ?? DBNull.Value),
                    new SqlParameter("CavityInVehicleSets",(object)model.CavityInVehicleSets ?? DBNull.Value),
                    new SqlParameter("RequiredOps", (object)model.RequiredOps ?? DBNull.Value),
                    new SqlParameter("Value", (object)model.Value ?? DBNull.Value),                   
                    new SqlParameter("CurrentUser", (object)model.CurrnetUser ?? DBNull.Value),
                    new SqlParameter("IsExistingMold", (object)IsExistingMold ?? DBNull.Value),
                    new SqlParameter("MoldFlowSetupHeaderId", (object)MoldFlowSetupHeaderId ?? DBNull.Value)                    
                };


                #endregion

                var result = _repository.ExecuteSQL<long>("usp_stmp_InputData_SaveInputData_IntialDataConversion", paramList).FirstOrDefault();


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

        public BaseApiResponse DeleteInputData(long inputDataId)
        {
            var response = new BaseApiResponse();

            try
            {
                var inputDataIdParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int64,
                    Value = inputDataId
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_InputData_DeleteInputData", inputDataIdParam).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

      public  ApiResponse<STMPInputDataModel> GetMoldByProgramAndPlant(int? PlantId, long? ProgramID, int LoggedInUserId)
        {
            var response = new ApiResponse<STMPInputDataModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId", (object)PlantId?? DBNull.Value),
                    new SqlParameter("ProgramID", (object)ProgramID?? DBNull.Value),
                    new SqlParameter("LoggedInUserId", (object)LoggedInUserId?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<STMPInputDataModel>("usp_getMoldByProgram_Plant_Moldflowsetup", paramList).ToList();
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


        public BaseApiResponse UploadInputDataFile(string datatableToxml, int UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var datatableToxmlParam = new SqlParameter
                {
                    ParameterName = "datatableToxml",
                    DbType = DbType.String,
                    Value = (object)datatableToxml ?? (object)DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };
              
                var result = _repository.ExecuteSQL<string>("usp_inputData_insertFromFile", datatableToxmlParam, UserIdParam).FirstOrDefault();

                response.Success = (result=="1");
                response.Message.Add(result);
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
                response.InsertedId = -2;
            }

            return response;
        }

        #endregion
    }
}