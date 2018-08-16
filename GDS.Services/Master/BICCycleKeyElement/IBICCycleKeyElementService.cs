using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.BICCycleKeyElement
{
   public interface IBICCycleKeyElementService
    {
        ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementList();

        ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementDetail(int BICCycleKeyElementID);

        BaseApiResponse AddOrUpdateBICCycleKeyElement(int UserId, BICCycleKeyElementModel model);

        BaseApiResponse DeleteBICCycleKeyElement(int BICCycleKeyElementID);

        ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardList();

        ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardDetail(int BICCycleKeyElementStandardID);

        BaseApiResponse AddOrUpdateBICCycleKeyElementStandard(int UserId, BICCycleKeyElementStandardModel model);

        BaseApiResponse DeleteBICCycleKeyElementStandard(int BICCycleKeyElementStandardID);
    }
}
