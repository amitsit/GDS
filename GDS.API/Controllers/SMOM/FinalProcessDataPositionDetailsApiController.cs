using System.Collections.Generic;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.CorpIMPD;
using GDS.Entities.SMOM.InitialDataConversionSetup;
using GDS.Services.SMOM.CorpIMPD.FinalProcessDataPositionDetails;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class FinalProcessDataPositionDetailsApiController : ApiController
    {
        #region Initializtions

        private readonly IFinalProcessDataPositionDetailsService _iService;

        public FinalProcessDataPositionDetailsApiController()
        {
            _iService = EngineContext.Resolve<IFinalProcessDataPositionDetailsService>();
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("GetFinalProcessDataPositionDetails")]
        public ApiResponse<FinalProcessDataPositionDetailsModel> GetFinalProcessDataPositionDetails(InitDataInputDataModel model)
        {
            return _iService.GetFinalProcessDataPositionDetails(model);
        }

        [HttpPost]
        [Route("SaveFinalProcessDataPositionDetails")]
        public BaseApiResponse SaveFinalProcessDataPositionDetails(long initDataGeneralInfoId, int loggedInUserId, int lengthUnitId, List<FinalProcessDataPositionDetailsModel> listFinalProcessDataPositionDetailsMode)
        {
            return _iService.SaveFinalProcessDataPositionDetails(initDataGeneralInfoId, loggedInUserId, lengthUnitId, listFinalProcessDataPositionDetailsMode);
        }

        #endregion
    }
}
