using System;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.LinearityResults;
using GDS.Services.SMOM.LinearityResults;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class LinearityResultsApiController : ApiController
    {
        #region Initializtions
        private readonly ILinearityResultsService _iLinearityResultsService;

        public LinearityResultsApiController()
        {
             _iLinearityResultsService = EngineContext.Resolve<ILinearityResultsService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetLinearityResults")]
        public ApiResponse<LinearityResultsModel> GetLinearityResults(int plantId, int plantEquipmentListId, Int16 lengthUnitId, long coverPageId)
        {
            return _iLinearityResultsService.GetLinearityResults(plantId, plantEquipmentListId, lengthUnitId, coverPageId);
        }

        [HttpPost]
        [Route("UpdataMachineLinearityValidationStatusCode")]
        public BaseApiResponse UpdataMachineLinearityValidationStatusCode(long coverPageId, byte? validationStatusCode)
        {
            return _iLinearityResultsService.UpdataMachineLinearityValidationStatusCode(coverPageId, validationStatusCode);
        }

        #endregion

    }
}
