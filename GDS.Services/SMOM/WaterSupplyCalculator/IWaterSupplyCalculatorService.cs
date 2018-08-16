using GDS.Common;
using GDS.Entities.SMOM.WaterSupplyCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.WaterSupplyCalculator
{
   public  interface IWaterSupplyCalculatorService
    {
        ApiResponse<WaterSupplyCalculatorModel> GetWaterSupplyDetail(long CoverPageId, int UserId, int lengthUnitId, int pressureUnitId);
        BaseApiResponse UpdateWaterSupplyDetail(int lengthUnitId, int pressureUnitId, WaterSupplyCalculatorModel CalculatorModel);
    }
}
