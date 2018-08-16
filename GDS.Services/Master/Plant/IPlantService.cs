using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.Plant
{
    public interface IPlantService
    {
        ApiResponse<PlantMasterModel> GetPlantDetail(int plantId);
        BaseApiResponse SavePlant(PlantMasterModel plantObj);
        BaseApiResponse DeletePlant(long plantId);
        ApiResponse<PlantMasterModel> GetPlantListMaster(int? PlantId, int UserId);
    }
}
