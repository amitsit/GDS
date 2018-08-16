using GDS.Common;
using GDS.Entities.SMOM.RecoveryTimeStudy;
using GDS.Services.SMOM.RecoveryTimeStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class RecoveryTimeStudyApiController : ApiController
    {
        #region Initializtions

        private readonly IRecoveryTimeStudyService _iService;

        public RecoveryTimeStudyApiController()
        {
            _iService = EngineContext.Resolve<IRecoveryTimeStudyService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetRecoveryTimeStudy")]
        public ApiResponse<RecoveryTimeStudyModel> GetRecoveryTimeStudy(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId)
        {
            return _iService.GetRecoveryTimeStudy(CoverPageId, PressureUnitId, LengthUnitId);
        }

        [HttpPost]
        [Route("InsertUpdateRecoveryTimeStudy")]
        public BaseApiResponse InsertUpdateRecoveryTimeStudy(Int16 PressureUnitId, Int16 LengthUnitId, RecoveryTimeStudyModel model)
        {
            return _iService.InsertUpdateRecoveryTimeStudy(PressureUnitId, LengthUnitId, model);
        }

        [HttpGet]
        [Route("GetRecoveryAdditinalParameters")]
        public ApiResponse<RecoveryTimeStudyModel> GetRecoveryAdditinalParameters(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId)
        {
            return _iService.GetRecoveryAdditinalParameters(CoverPageId, PressureUnitId, LengthUnitId);
        }

        [HttpPost]
        [Route("SaveRecoveryAdditinalParametersList")]
        public BaseApiResponse SaveRecoveryAdditinalParametersList(RecoveryTimeStudyModel model)
        {
            return _iService.SaveRecoveryAdditinalParametersList(model);
        }

        #endregion
    }
}
