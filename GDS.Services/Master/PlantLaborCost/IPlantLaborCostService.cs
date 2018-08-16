using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.PlantLaborCost
{
    public interface IPlantLaborCostService
    {
        ApiResponse<PlantLaborCostModel> GetPlantLaborCost(long? PlantLaborCostId = null);
        BaseApiResponse SavePlantLaborCost(PlantLaborCostModel plantLaborCostObject);
        BaseApiResponse DeletePlantLaborCost(long PlantLaborCostId);
    }
}
