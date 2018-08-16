using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.Region
{
    public interface IRegionService
    {
        ApiResponse<RegionMasterModel> GetRegionList();
        ApiResponse<RegionMasterModel> GetRegionDetail(int RegionID);
        BaseApiResponse AddOrUpdateRegion(int UserId, RegionMasterModel RegionObj);
        BaseApiResponse DeleteRegion(long RegionID);
    }
}
