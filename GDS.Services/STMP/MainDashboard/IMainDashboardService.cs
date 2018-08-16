using GDS.Common;
using GDS.Entities.STMP.CapitalPlanBenifits;

namespace GDS.Services.STMP.MainDashboard
{
    public interface IMainDashboardService
    {
        ApiResponse<DashboardPlantSelection> GetDashboardPlantSelectionData(int regionId, int UserId);

        ApiResponse<CapitalPlanBenifitsModel> GetMainDashBoardData(CapitalPlanBenifitsInputModel model);
    }
}
