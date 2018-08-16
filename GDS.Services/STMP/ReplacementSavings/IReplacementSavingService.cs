using System.Collections.Generic;
using GDS.Common;
using GDS.Entities.STMP.ReplacementSavings;

namespace GDS.Services.STMP.ReplacementSavings
{
    public interface IReplacementSavingService
    {
        ApiResponse<ReplacementSavingsModel> GetReplacementSavings(ReplacementSavingsInputModel model);
        BaseApiResponse SaveReplacementSavings(List<ReplacementSavingsModel> model, int loggedInUserId);
    }
}
