using System;
using GDS.Common;
using GDS.Entities.SMOM.LinearityResults;

namespace GDS.Services.SMOM.LinearityResults
{
    public interface ILinearityResultsService
    {
        ApiResponse<LinearityResultsModel> GetLinearityResults(int plantId, int plantEquipmentListId, Int16 lengthUnitId, long coverPageId);

        BaseApiResponse UpdataMachineLinearityValidationStatusCode(long coverPageId, byte? validationStatusCode);
    }
}
