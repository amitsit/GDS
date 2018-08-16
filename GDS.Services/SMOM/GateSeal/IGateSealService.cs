using GDS.Common;
using GDS.Entities.SMOM;
using System;
using System.Collections.Generic;

namespace GDS.Services.SMOM.GateSeal
{
    public  interface IGateSealService
    {
     
        ApiResponse<GateSealPartModel> GetSealPartDetail(int GateSealId);
        ApiResponse<GateSealMasterModel> GetSealDetail(long CoverPageId,Int16 PressureUnitId);
        BaseApiResponse SaveOrUpdateSealDetail(int UserId, long CoverPageId, Int16 PressureUnitId, GateSealMasterModel MasterModel);
    }
}
