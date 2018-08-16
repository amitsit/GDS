using GDS.Entities.STMP.CapacityChart;
using GDS.Common;
using GDS.Entities.STMP.ManningUtilization;

namespace GDS.Services.STMP.ManningUtilization
{
    public interface IManningUtilizationService
    {
        ApiResponse<ManningUtilizationModel> GetManningUtilizationAllocation(PlantUtilizationInputParamModel model);

        BaseApiResponse UpdateStdReliefDivisorOrStdQuotedWeekhours(int PlantId, int UserId, ManningUtilizationModel ManningUtilizationObj);
    }
}
