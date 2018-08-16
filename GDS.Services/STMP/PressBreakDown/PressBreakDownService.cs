namespace GDS.Services.STMP.PressBreakDown
{
    using Common;
    using Data.Repository;
    using Entities.STMP.PressBreakDown;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class PressBreakDownService : IPressBreakDownService
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
        private readonly IGenericRepository<PressBreakDownModel> _repository;

        #endregion

        #region ctor


        public PressBreakDownService(IGenericRepository<PressBreakDownModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<PressBreakDownModel> GetPressbreakDownList(int plantId,string cycleTimeSelection, string oee, string stdcyc, int userId,string weekString,int? tonnageRangeId, int? scenarioHeaderId,float? stdAllOeeValue)
        {
            var response = new ApiResponse<PressBreakDownModel>();

            try
            {

                object[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId", (object)scenarioHeaderId ?? DBNull.Value),
                    new SqlParameter("PlantId", Convert.ToString(plantId) ),
                    new SqlParameter("TonnageRangeId", (object)tonnageRangeId ?? DBNull.Value ),                                    
                    new SqlParameter("CycleTimeSelection",cycleTimeSelection),
                    new SqlParameter("OEE",oee),
                    new SqlParameter("STDCYC",stdcyc),
                    //new SqlParameter("UserId",userId),
                    new SqlParameter("IsOnlyTotal",false),
                    new SqlParameter("WeekString",weekString),
                    new SqlParameter("Global_StdPerfomanceGoal",oee.ToLower()=="std"?(object)stdAllOeeValue??DBNull.Value:DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",oee.ToLower()=="all"?(object)stdAllOeeValue??DBNull.Value:DBNull.Value)
                };

                var result = _repository.ExecuteSQL<PressBreakDownModel>("usp_PressBreakDownData_get", paramList).ToList();
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

        public BaseApiResponse RemoveToolFromPress(long pressBreakdownId, long? scenarioId, int userId)
        {
            var response = new BaseApiResponse();

            try
            {
                var pressBreakdownIdParam = new SqlParameter
                {
                    ParameterName = "PressBreakdownId",
                    DbType = DbType.Int64,
                    Value = (object)pressBreakdownId ?? DBNull.Value
                };
                var scenarioIdParam = new SqlParameter
                {
                    ParameterName = "ScenarioId",
                    DbType = DbType.Int64,
                    Value = (object)scenarioId ?? DBNull.Value
                };
                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)userId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("RemoveToolFromPress", pressBreakdownIdParam, scenarioIdParam, userIdParam).FirstOrDefault();
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

        public BaseApiResponse InsertNewToolToPress(int plantId, string pressNumber, string toolNumber, int userId, long? scenarioHeaderId = null,int? PlantProgramId = null)
        {
            var response = new BaseApiResponse();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId 
                };
                var pressNumberParam = new SqlParameter
                {
                    ParameterName = "PressNumber",
                    DbType = DbType.String,
                    Value = (object)pressNumber ?? DBNull.Value
                };
                var toolNumberParam = new SqlParameter
                {
                    ParameterName = "ToolNumber",
                    DbType = DbType.String,
                    Value = (object)toolNumber ?? DBNull.Value
                };

                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = userId 
                };

                var scenarioHeaderIdParam = new SqlParameter
                {
                    ParameterName = "ScenarioHeaderId",
                    DbType = DbType.Int64,
                    Value = (object)scenarioHeaderId ?? DBNull.Value
                };

                var PlantProgramIdparam = new SqlParameter
                {
                    ParameterName = "PlantProgramId",
                    DbType = DbType.Int32,
                    Value = (object)PlantProgramId ?? DBNull.Value
                };


                var result = _repository.ExecuteSQL<InsertNewToolToPressModel>("InsertNewToolToPress", plantIdParam, pressNumberParam, toolNumberParam, userIdParam, scenarioHeaderIdParam, PlantProgramIdparam).FirstOrDefault();

                if (result == null)
                    throw new Exception("Something went wrong");

                response.Success = result.ReturnId > 0;
                response.InsertedId = result.ReturnId;

                if (result.ReturnId == -3)
                    response.Message.Add(result.Message);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<ToolForDDL> GetToolListForPressbreakdownPress(int plantId,int ScenarioId)
        {
            var response = new ApiResponse<ToolForDDL>();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var ScenarioIdParam = new SqlParameter
                {
                    ParameterName = "ScenarioIdParam",
                    DbType = DbType.String,
                    Value = (object)ScenarioId ?? DBNull.Value
                };

               

                var result = _repository.ExecuteSQL<ToolForDDL>("usp_stmp_InputData_GetToolListForPressbreakdownPress", plantIdParam, ScenarioIdParam).ToList();
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

        public ApiResponse<ProgramListForDDL> GetProgramListForPressbreakdownByTool(long? inputDataId)
        {
            var response = new ApiResponse<ProgramListForDDL>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InputDataId",(object)inputDataId??(object)DBNull.Value)
                };

                var result = _repository.ExecuteSQL<ProgramListForDDL>("usp_stmp_InputData_GetProgramListForPressbreakdownByTool", paramList).ToList();
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
