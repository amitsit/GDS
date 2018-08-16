using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.MaterialData
{
    public interface IMaterialDataService
    {
        ApiResponse<MaterialModel> GetMaterialData(int? materialTypeId, string searchFilter);
        BaseApiResponse InsertOrUpdateMaterial(MaterialModel model);
        BaseApiResponse DeleteMaterial(int materialId);
    }
}
