using GDS.Entities.STMP.CapacityChart;
using System;
using System.Linq;
using System.Data.SqlClient;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.STMP_Configuration;

namespace GDS.Services.STMP.STMP_Configuration
{
    public class StmpConfiguration : IStmpConfigurationService
    {
        #region Constants
        
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields
        
        private readonly IGenericRepository<PlantYearMonthModel> _repository;

        #endregion

        #region ctor

        public StmpConfiguration(IGenericRepository<PlantYearMonthModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<PlantYearMonthModel> GetPlantYearMonthList(int plantId, int year, int month, int userId)
        {
            var response = new ApiResponse<PlantYearMonthModel>();

            try
            {
                object[] paramList =
                {
                     new SqlParameter("p_PlantId",plantId)
                    ,new SqlParameter("p_Year",year)
                    ,new SqlParameter("p_Month",month)
                    ,new SqlParameter("p_LoginUserId",userId)
                };
                
                var result = _repository.ExecuteSQL<PlantYearMonthModel>("usp_stmp_PlantYearMonthList_get", paramList).ToList();
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

        public BaseApiResponse CreateScenarioHeader(CreateScenarioInputParams model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                     new SqlParameter("ScenarioName",model.ScenarioName)
                    ,new SqlParameter("PlantId",model.PlantId)
                    ,new SqlParameter("MoldingManning",(object)model.MoldingManning ?? DBNull.Value)
                    ,new SqlParameter("FringeWageRate",(object)model.FringeWageRate ?? DBNull.Value)
                    ,new SqlParameter("HourlyWageRate",(object)model.HourlyWageRate ?? DBNull.Value)
                    ,new SqlParameter("Utilization",(object)model.Utilization ?? DBNull.Value)
                    ,new SqlParameter("LoggedInUserId",model.LoggedInUserId)
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_ScenarioHeader_CreateScenarioHeader", paramList).FirstOrDefault();
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

        public ApiResponse<ScenarioHeaderModel> GetAllScenariosForSelectedPlant(int plantId, int loggedInUserId)
        {
            var response = new ApiResponse<ScenarioHeaderModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId", plantId),
                    new SqlParameter("LoggedInUserId", loggedInUserId),
                };

                var result = _repository.ExecuteSQL<ScenarioHeaderModel>("usp_stmp_GetAllScenariosForSelectedPlant", paramList).ToList();
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

        public BaseApiResponse SelectScenarioForSelectedPlant(long scenarioHeaderId, int plantId, int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId", scenarioHeaderId),
                    new SqlParameter("PlantId", plantId),
                    new SqlParameter("LoggedInUserId", loggedInUserId),
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_SelectScenarioForSelectedPlant", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteScenarioForSelectedPlant(long scenarioHeaderId, int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId", scenarioHeaderId),
                    new SqlParameter("LoggedInUserId", loggedInUserId),
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_DeleteScenarioForSelectedPlant", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeactivateAllScenario(int plantId, int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId", plantId),
                    new SqlParameter("LoggedInUserId", loggedInUserId),
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_DeactivateAllScenario", paramList).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SetScenarioDataAsBaseData(long scenarioHeaderId, int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId", scenarioHeaderId),
                    new SqlParameter("LoggedInUserId", loggedInUserId)
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_SetScenarioDataAsBaseData", paramList).FirstOrDefault();
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
