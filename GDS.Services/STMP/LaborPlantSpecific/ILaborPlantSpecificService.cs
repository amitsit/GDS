using GDS.Common;
using GDS.Entities.STMP.LaborPlantSpecific;

namespace GDS.Services.STMP.LaborPlantSpecific
{
    public interface ILaborPlantSpecificService
    {
        ApiResponse<LaborPlantSpecificModel> GetLaborPlantSpecificDetail(LaborPlantSpecificInputDataModel model);
    }
}
