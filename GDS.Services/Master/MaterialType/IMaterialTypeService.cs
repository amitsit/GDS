using GDS.Common;
using GDS.Entities.Master;

namespace GDS.Services.Master.MaterialType
{
    public interface IMaterialTypeService
    {
        ApiResponse<MaterialTypeMasterModel> GetMaterialType(int? materialTypeId);

        BaseApiResponse SaveMaterialType(MaterialTypeMasterModel model);

        BaseApiResponse DeleteMaterialType(int materialTypeId);
    }
}
