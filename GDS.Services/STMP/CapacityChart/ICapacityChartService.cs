using GDS.Common;
using GDS.Entities.STMP.PressBreakDown;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.Services.STMP.CapacityChart
{
    public interface ICapacityChartService
    {
        // PlantUtilization

        ApiResponse<PlantUtilizationModel> GetPlantUtilization(PlantUtilizationInputParamModel model);

        // Cycle Time Performance And TLN Saving Report

        ApiResponse<CycleTimePerformanceAndTLNSavingReportModel> GetCycleTimePerformanceAndTLNSavingReport(int plantId, string cycleTimeSelection, string oee, string stdcyc, 
            string weekString, double? moldingManning, double? fringeWageRate, double? hourlyWageRate, int? scenarioHeaderId,int UserId);

        ApiResponse<CapacityChartModel> GetPressbreakDownList_CapacityChart(int plantId,string cycleTimeSelection, string oee, string stdcyc, int userId,
            string weekString, double? moldingManning, double? fringeWageRate, double? hourlyWageRate, int? scenarioHeaderId, double? Global_StdPerfomanceGoal, double? Global_AllPerformanceGoal);

        ApiResponse<DateListModel> GetSevenDayIntervalDateListForCapacityChart(int plantId);
    }
}
