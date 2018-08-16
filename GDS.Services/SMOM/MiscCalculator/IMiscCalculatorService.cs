using GDS.Common;
using GDS.Entities.SMOM.MiscCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.MiscCalculator
{
    public interface IMiscCalculatorService
    {
        ApiResponse<MiscCalculatorModel> GetMiscCalculatorDetail(long CoverPageId, Int16 LengthUnitId, Int16 PressureUnitId);
        BaseApiResponse SaveOrUpdateMiscCalculator(int UserId, long CoverPageId,Int16 LengthUnitId, Int16 PressureUnitId, MiscCalculatorModel MiscModel);
    }
}
