using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.TonnageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.TonnageCalculator
{
   public interface ITonnageCalculatorService
    {
        ApiResponse<TonnageCalculatorModel> GetTonnageCalculatorDetails(long CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId);

        BaseApiResponse SaveTonnageCalculator(long CoverPageId, int UserId, Int16 LengthUnitId, Int16 PressureUnitId, TonnageCalculatorModel TonnageCalculatorObj);

        ApiResponse<WallStockRangeModel> GetWallStockRange(int WallstockTypeId,int MaterialTypeId);
    }
}
