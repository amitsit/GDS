using GDS.Common;
using GDS.Entities.Dashboard;

namespace GDS.Services.Dashboard
{
    public interface IDashboardService
    {
        ApiResponse<ConfigurationMasterModel> GetConfigurationMasterValues(); 

        ApiResponse<PerformancesModel> GetDashboardPerformances(PerformancesInputModel model);

        ApiResponse<GradeCardModel> GetPlantCycleTimeGradeCard(GradeCardInputModel model);

        ApiResponse<PressTotalCostSavingsModel> GetPressTotalCostSavings(PressTotalCostSavingsInputModel model);
        
        ApiResponse<GradeCardChartModel> GetGradeCardGraphData(int UserId);
    }
}
