using System;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Dashboard;
using System.Data;

namespace GDS.Services.Dashboard
{
    public class DashboardService : IDashboardService
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
        private readonly IGenericRepository<PerformancesModel> _repository;

        #endregion

        #region ctor

        public DashboardService(IGenericRepository<PerformancesModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<ConfigurationMasterModel> GetConfigurationMasterValues()
        {
            var response = new ApiResponse<ConfigurationMasterModel>();

            try
            {

                var result = _repository.ExecuteSQL<ConfigurationMasterModel>("usp_ConfigurationMaster_GetValues").ToList();
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

        public ApiResponse<PerformancesModel> GetDashboardPerformances(PerformancesInputModel model)
        {
            var response = new ApiResponse<PerformancesModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantIdString",(object) model.PlantIdString ?? DBNull.Value),
                    new SqlParameter("CycleTimeSelection",(object)model.CycleTimeSelection ?? DBNull.Value),
                    new SqlParameter("OEE",(object)model.OEE ?? DBNull.Value),
                    new SqlParameter("UserId",(object)model.LoggedInUserId ?? DBNull.Value),
                    new SqlParameter("LengthUnitId", model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("IsPlantSpecific",false),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("Global_StdPerfomanceGoal",(object)model.Global_StdPerfomanceGoal?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<PerformancesModel>("usp_stmp_GetDashboardPerformances", paramList).ToList();
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

        public ApiResponse<GradeCardModel> GetPlantCycleTimeGradeCard(GradeCardInputModel model)
        {
            var response = new ApiResponse<GradeCardModel>();

            try
            {


                object[] paramList =
                {
                    new SqlParameter("CycleTimeSelection",(object)model.CycleTimeSelection ?? DBNull.Value),
                    new SqlParameter("OEE",(object)model.OEE ?? DBNull.Value),
                    new SqlParameter("UserId",(object)model.UserId ?? DBNull.Value),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("Global_StdPerfomanceGoal",(object)model.Global_StdPerfomanceGoal?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<GradeCardModel>("usp_stmp_GetPlantCycleTimeGradeCard", paramList).ToList();
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

        public ApiResponse<PressTotalCostSavingsModel> GetPressTotalCostSavings(PressTotalCostSavingsInputModel model)
        {
            var response = new ApiResponse<PressTotalCostSavingsModel>();
            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantIdString",model.PlantIdString),
                    new SqlParameter("CycleTimeSelection",model.CycleTimeSelection),
                    new SqlParameter("OEE",model.OEE),
                    new SqlParameter("UserId",model.UserId),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("MaxUtilizationTarget",(object)model.MaxUtilizationTarget ?? DBNull.Value),
                    new SqlParameter("Global_StdPerfomanceGoal" ,(object)model.Global_StdPerfomanceGoal  ?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal ?? DBNull.Value),
                    new SqlParameter("AssumedShiftsperMachine",(object)model.AssumedShiftsperMachine ?? DBNull.Value),
                    new SqlParameter("IsMachineIdle",model.IsMachineIdle),
                    new SqlParameter("IsavingsNewMachineCost",model.IsavingsNewMachineCost),
                    new SqlParameter("IsPlantWeigtedWageBlank",model.IsPlantWeigtedWageBlank),
                    new SqlParameter("RemoveUpdateCosts",model.RemoveUpdateCosts)
                };

                var result = _repository.ExecuteSQL<PressTotalCostSavingsModel>("usp_stmp_GetPressTotalCostSavings", paramList).ToList();
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

       

        public ApiResponse<GradeCardChartModel> GetGradeCardGraphData(int UserId)
        {
            var response = new ApiResponse<GradeCardChartModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("UserId",UserId)
                };

                var result = _repository.ExecuteSQL<GradeCardChartModel>("usp_dashboard_GetGradeCardGraphData", paramList).ToList();
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
