using System;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.RheologyCurve;
using GDS.Services.SMOM.RheologyCurve;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class RheologyCurveApiController : ApiController
    {
        #region Initializtions
        private readonly IRheologyCurveService _iRheologyCurveService;

        public RheologyCurveApiController()
        {
            _iRheologyCurveService = EngineContext.Resolve<IRheologyCurveService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetRheologyCurveDetails")]
        public ApiResponse<RheologyCurveModel> GetRheologyCurveDetails(int plantId, int plantEquipmentListId, Int16 lengthUnitId, long coverPageId)
        {
            return _iRheologyCurveService.GetRheologyCurveDetails(plantId, plantEquipmentListId, lengthUnitId, coverPageId);
        }

        [HttpPost]
        [Route("SaveRheologyCurveDetails")]
        public BaseApiResponse SaveRheologyCurveDetails(RheologyCurvePostModel model)
        {
            return _iRheologyCurveService.SaveRheologyCurveDetails(model);
        }
        #endregion
    }
}
