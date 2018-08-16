using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.PressBreakDownOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class PressBreakDownOrderApiController : ApiController
    {
        #region Initializtions
        private readonly IPressBreakDownOrderService _PressBreakDownOrderService;

        public PressBreakDownOrderApiController()
        {
            this._PressBreakDownOrderService = EngineContext.Resolve<IPressBreakDownOrderService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetPressBreakDownOrderData")]
        public ApiResponse<PressBreakDownOrderModel> GetPressBreakDownOrderData(int PlantId)
        {
            return this._PressBreakDownOrderService.GetPressBreakDownOrderData(PlantId);
        }

        [HttpPost]
        [Route("SavePressBreakDownOrderData")]
        public BaseApiResponse SavePressBreakDownOrderData(int UserId, List<PressBreakDownOrderModel> PressBreakDownOrderData)
        {
            return this._PressBreakDownOrderService.SavePressBreakDownOrderData(UserId,PressBreakDownOrderData);
        }


        #endregion
    }
}
