using GDS.Common;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.PressBreakDownOrder
{
    public interface IPressBreakDownOrderService
    {
        ApiResponse<PressBreakDownOrderModel> GetPressBreakDownOrderData(int PlantId);

        BaseApiResponse SavePressBreakDownOrderData(int UserId, List<PressBreakDownOrderModel> PressBreakDownOrderData);
    }
}
