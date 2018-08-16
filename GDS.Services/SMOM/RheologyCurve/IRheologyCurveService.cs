using System;
using GDS.Common;
using GDS.Entities.SMOM.RheologyCurve;

namespace GDS.Services.SMOM.RheologyCurve
{
    public interface IRheologyCurveService
    {
        ApiResponse<RheologyCurveModel> GetRheologyCurveDetails(int plantId, int plantEquipmentListId, Int16 lengthUnitId, long coverPageId);
        BaseApiResponse SaveRheologyCurveDetails(RheologyCurvePostModel model);
    }
}
