using System;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.GPMCalculator;
using GDS.Services.SMOM.GPMCalculator;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class GPMCalculatorApiController : ApiController
    {

        #region Initializtions
        private readonly IGPMCalculatorService _iGPMCalculatorService;

        public GPMCalculatorApiController()
        {
            _iGPMCalculatorService = EngineContext.Resolve<IGPMCalculatorService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetGPMCalculatorDetails")]
        public ApiResponse<GPMCalculatorModel> GetGPMCalculatorDetails(Int16 lengthUnitId, Int16 pressureUnitId, long coverPageId)
        {
            return _iGPMCalculatorService.GetGPMCalculatorDetails(lengthUnitId, pressureUnitId,coverPageId);
        }

        [HttpPost]
        [Route("InsertUpdateGPMCalculator")]
        public BaseApiResponse InsertUpdateGPMCalculator(Int16 lengthUnitId, Int16 pressureUnitId, GPMCalculatorModel model)
        {
            return _iGPMCalculatorService.InsertUpdateGPMCalculator(lengthUnitId, pressureUnitId, model);
        }
        #endregion
    }
}
 