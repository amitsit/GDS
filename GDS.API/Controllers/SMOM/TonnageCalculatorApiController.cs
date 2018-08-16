using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.TonnageCalculator;
using GDS.Services.SMOM.TonnageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{

    [RoutePrefix("api")]
    public class TonnageCalculatorApiController : ApiController
    {
        #region Initializtions

        private readonly ITonnageCalculatorService _iTonnageCalculatorService;

        public TonnageCalculatorApiController()
        {
            _iTonnageCalculatorService = EngineContext.Resolve<ITonnageCalculatorService>();
        }

        #endregion

        #region methods

        [HttpGet]
        [Route("GetTonnageCalculatorDetails")]
        public ApiResponse<TonnageCalculatorModel> GetTonnageCalculatorDetails(long CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId)
        {
            return _iTonnageCalculatorService.GetTonnageCalculatorDetails(CoverPageId, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveTonnageCalculator")]
        public BaseApiResponse SaveTonnageCalculator(long CoverPageId,int UserId, Int16 LengthUnitId, Int16 PressureUnitId, TonnageCalculatorModel TonnageCalculatorObj)
        {
            return _iTonnageCalculatorService.SaveTonnageCalculator(CoverPageId, UserId, LengthUnitId, PressureUnitId,TonnageCalculatorObj);
        }

        [HttpGet]
        [Route("GetWallStockRange")]
        public ApiResponse<WallStockRangeModel> GetWallStockRange(int WallstockTypeId,int MaterialTypeId)
        {
            return _iTonnageCalculatorService.GetWallStockRange(WallstockTypeId, MaterialTypeId);
        }

        #endregion
    }
}
