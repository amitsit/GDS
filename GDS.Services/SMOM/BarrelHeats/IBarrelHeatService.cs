using GDS.Common;
using GDS.Entities.SMOM.BarrelHeats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.BarrelHeats
{
     public interface IBarrelHeatService
    {
        ApiResponse<BarrelHeatModel> GetBerralHeatDetail(long CoverPageId, int UserId);
        BaseApiResponse SaveOrUpdateBarrelHeats(BarrelHeatModel BarrelModel);
    }
}
