using GDS.Common;
using GDS.Entities.STMP.PressBreakDown;
using GDS.Services.STMP.CapacityChart;
using System.Web.Http;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class CapacityChartApiController : ApiController
    {

        #region Initializtions

        private readonly ICapacityChartService _iCapacityChartService;

        public CapacityChartApiController()
        {
            _iCapacityChartService = EngineContext.Resolve<ICapacityChartService>();
        }

        #endregion

        #region Methods

        #region Plant Utilization

        [HttpPost]
        [Route("GetPlantUtilization")]
        public ApiResponse<PlantUtilizationModel> GetPlantUtilization(PlantUtilizationInputParamModel model)
        {
            return _iCapacityChartService.GetPlantUtilization(model);
        }

        #endregion

        #region Cycle Time Performance And TLN Saving Report

        [HttpGet]
        [Route("GetCycleTimePerformanceAndTLNSavingReport")]
        public ApiResponse<CycleTimePerformanceAndTLNSavingReportModel> GetCycleTimePerformanceAndTLNSavingReport(int plantId, string cycleTimeSelection, string oee, string stdcyc, 
            string weekString, double? moldingManning, double? fringeWageRate, double? hourlyWageRate, int? scenarioHeaderId,int UserId)
        {
            return _iCapacityChartService.GetCycleTimePerformanceAndTLNSavingReport(plantId, cycleTimeSelection, oee, stdcyc, weekString, moldingManning, fringeWageRate, hourlyWageRate, scenarioHeaderId,UserId);
        }

        #endregion

        [HttpGet]
        [Route("GetPressbreakDownList_CapacityChart")]
        public ApiResponse<CapacityChartModel> GetPressbreakDownList_CapacityChart(int plantId, string cycleTimeSelection, string oee, string stdcyc, int userId,
            string weekString, double? moldingManning, double? fringeWageRate, double? hourlyWageRate, int? scenarioHeaderId, double? Global_StdPerfomanceGoal, double? Global_AllPerformanceGoal)
        {
            return _iCapacityChartService.GetPressbreakDownList_CapacityChart(plantId,cycleTimeSelection, oee, stdcyc, userId, weekString, moldingManning, fringeWageRate, hourlyWageRate,scenarioHeaderId, Global_StdPerfomanceGoal, Global_AllPerformanceGoal);
        }

        [HttpGet]
        [Route("GetSevenDayIntervalDateListForCapacityChart")]
        public ApiResponse<DateListModel> GetSevenDayIntervalDateListForCapacityChart(int plantId)
        {
            return _iCapacityChartService.GetSevenDayIntervalDateListForCapacityChart(plantId);
        }

        #endregion
    }
}
