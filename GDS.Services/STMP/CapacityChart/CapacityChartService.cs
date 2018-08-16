using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.PressBreakDown;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Data;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.Services.STMP.CapacityChart
{

    public class CapacityChartService : ICapacityChartService
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


        public CapacityChartService(IGenericRepository<PressBreakDownModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        #region Plant Utilization 

        public ApiResponse<PlantUtilizationModel> GetPlantUtilization(PlantUtilizationInputParamModel model)
        {
            var response = new ApiResponse<PlantUtilizationModel>();

            try
            {
                SqlParameter[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId",model.ScenarioHeaderId),
                    new SqlParameter("PlantId",model.PlantId),
                    new SqlParameter("CycleTimeSelection",model.CycleTimeSelection),
                    new SqlParameter("OEE",model.OEE),
                    new SqlParameter("STDCYC",model.STDCYC),
                    //new SqlParameter("UserId",model.UserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("MoldingManning",(object)model.MoldingManning ?? DBNull.Value),
                    new SqlParameter("FringeWageRate",(object)model.FringeWageRate ?? DBNull.Value),
                    new SqlParameter("HourlyWageRate",(object)model.HourlyWageRate ?? DBNull.Value),
                    new SqlParameter("StdReliefDivisor",(object)model.StdReliefDivisor ?? DBNull.Value),
                    new SqlParameter("StdQuotedWeek",(object)model.StdQuotedWeek ?? DBNull.Value),
                    new SqlParameter("Global_StdPerfomanceGoal",(object)model.Global_StdPerfomanceGoal?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal?? DBNull.Value)
                };

                var ctx = new DBAccess();
                var ds = ctx.QuerySQL("usp_ManningAndUtilization_get", paramList);

                if (ds != null && ds.Tables.Count > 0)
                {
                    response.Data = Utility.ConvertDataTable<PlantUtilizationModel>(ds.Tables[2]);
                    response.Success = true;
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

        #region Cycle Time Performance And TLN Saving Report

        public ApiResponse<CycleTimePerformanceAndTLNSavingReportModel> GetCycleTimePerformanceAndTLNSavingReport(int plantId, string cycleTimeSelection, string oee, string stdcyc,
            string weekString, double? moldingManning, double? fringeWageRate, double? hourlyWageRate, int? scenarioHeaderId,int UserId)
        {
            var response = new ApiResponse<CycleTimePerformanceAndTLNSavingReportModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId",plantId),
                    new SqlParameter("ScenarioHeaderId",(object)scenarioHeaderId?? DBNull.Value),
                    new SqlParameter("CycleTimeSelection",cycleTimeSelection),
                    new SqlParameter("OEE",oee),
                    new SqlParameter("STDCYC",stdcyc),
                    new SqlParameter("WeekString",weekString),
                    new SqlParameter("MoldingManning",(object)moldingManning ?? DBNull.Value),
                    new SqlParameter("FringeWageRate",(object)fringeWageRate ?? DBNull.Value),
                    new SqlParameter("HourlyWageRate",(object)hourlyWageRate ?? DBNull.Value),
                     new SqlParameter("UserId",(object)UserId ?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<CycleTimePerformanceAndTLNSavingReportModel>("usp_stmp_CapacityChart_GetCycleTimePerformanceAndTLNSavingReport", paramList).ToList();
                response.Success = result.Count > 0;
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

        public ApiResponse<CapacityChartModel> GetPressbreakDownList_CapacityChart(int plantId, string cycleTimeSelection, string oee, string stdcyc, int userId,
            string weekString,double? moldingManning, double? fringeWageRate,double? hourlyWageRate,int? scenarioHeaderId,double? Global_StdPerfomanceGoal,double? Global_AllPerformanceGoal)
        {
            var response = new ApiResponse<CapacityChartModel>();

            try
            {
                SqlParameter[] paramList =
                {
                    new SqlParameter("ScenarioHeaderId",(object)scenarioHeaderId?? DBNull.Value),
                    new SqlParameter("PlantId",plantId),                 
                    new SqlParameter("CycleTimeSelection",cycleTimeSelection),
                    new SqlParameter("OEE",oee),
                    new SqlParameter("STDCYC",stdcyc),
                    //new SqlParameter("UserId",userId),
                    new SqlParameter("WeekString",weekString),
                    new SqlParameter("MoldingManning",(object)moldingManning ?? DBNull.Value),
                    new SqlParameter("FringeWageRate",(object)fringeWageRate ?? DBNull.Value),
                    new SqlParameter("HourlyWageRate",(object)hourlyWageRate ?? DBNull.Value),
                     new SqlParameter("Global_StdPerfomanceGoal",(object)Global_StdPerfomanceGoal ?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)Global_AllPerformanceGoal ?? DBNull.Value)
                };

                var ctx = new DBAccess();
                var ds = ctx.QuerySQL("usp_PressBreakDownData_CapacityChart_get", paramList);

                if (ds != null && ds.Tables.Count > 0)
                {
                    var list = new List<CapacityChartModel>
                    {
                        new CapacityChartModel
                        {
                            PressBreakDownModel = Utility.ConvertDataTable<PressBreakDownModel>(ds.Tables[0]),
                            PressManSummaryModel = Utility.ConvertDataTable<PressManSummaryModel>(ds.Tables[1]),
                        }
                    };

                    response.Data =list;
                    response.Success = true;
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<DateListModel> GetSevenDayIntervalDateListForCapacityChart(int plantId)
        {
            var response = new ApiResponse<DateListModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId", plantId)
                };
                
                var result = _repository.ExecuteSQL<DateListModel>("usp_stmp_GetSevenDayIntervalDateListForCapacityChart", paramList).ToList();
                response.Success = result.Count > 0;
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
    }
}
