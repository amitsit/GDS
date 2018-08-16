using System;
using GDS.Common;
using GDS.Entities.SMOM.GPMCalculator;

namespace GDS.Services.SMOM.GPMCalculator
{
    public interface IGPMCalculatorService
    {
        ApiResponse<GPMCalculatorModel> GetGPMCalculatorDetails(Int16 lengthUnitId, Int16 pressureUnitId, long coverPageId);
        BaseApiResponse InsertUpdateGPMCalculator(Int16 lengthUnitId, Int16 pressureUnitId ,GPMCalculatorModel model);
    }
}
