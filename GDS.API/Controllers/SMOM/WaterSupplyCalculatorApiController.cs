using GDS.Common;
using GDS.Entities.SMOM.WaterSupplyCalculator;
using GDS.Services.SMOM.WaterSupplyCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class WaterSupplyCalculatorApiController : ApiController
    {
        #region Initializtions

        private readonly IWaterSupplyCalculatorService _iService;

        public WaterSupplyCalculatorApiController()
        {
            _iService = EngineContext.Resolve<IWaterSupplyCalculatorService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetWaterSupplyDetail")]
        public ApiResponse<WaterSupplyCalculatorModel> GetWaterSupplyDetail(long CoverPageId, int UserId, int lengthUnitId, int pressureUnitId)
        {
            return _iService.GetWaterSupplyDetail(CoverPageId, UserId, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("UpdateWaterSupplyDetail")]
        public BaseApiResponse UpdateWaterSupplyDetail(int lengthUnitId, int pressureUnitId, WaterSupplyCalculatorModel CalculatorModel)
        {
            return _iService.UpdateWaterSupplyDetail(lengthUnitId, pressureUnitId, CalculatorModel);
        }
        #endregion
    }
}