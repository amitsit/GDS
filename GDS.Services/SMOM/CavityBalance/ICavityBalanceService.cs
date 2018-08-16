using System;
using GDS.Common;
using GDS.Entities.SMOM.CavityBalance;

namespace GDS.Services.SMOM.CavityBalance
{
    public interface ICavityBalanceService
    {
        ApiResponse<CavityBalanceModel> GetCavitybalanceList(long coverPageId);
        BaseApiResponse SaveCavityBalanceDetail(CavityBalanceModel model, int CreatedBy);
    }
}
