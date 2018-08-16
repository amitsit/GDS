using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Entities.IMIP;
using GDS.Common;
using GDS.Services.SMOM.CheckRingStudyWeight;
using GDS.Entities.SMOM.CheckRingStudyWeight;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class CheckRingStudyWeightApiController : ApiController
    {
        #region Initializtions

        private readonly ICheckRingStudyWeightService _iCheckRingStudyWeightService;
        #endregion

        #region Ctor
        public CheckRingStudyWeightApiController()
        {
            _iCheckRingStudyWeightService = EngineContext.Resolve<ICheckRingStudyWeightService>();
        }

        #endregion

        #region Methods
        [HttpGet]
        [Route("GetCheckRingStudyWeightList")]
        public ApiResponse<CheckRingStudyWeightModel> GetCheckRingStudyWeightList(long CoverPageId)
        {
            return _iCheckRingStudyWeightService.GetCheckRingStudyWeightList(CoverPageId);
        }

        [HttpPost]
        [Route("UpdateCheckRingStudyWeight")]
        public BaseApiResponse UpdateCheckRingStudyWeight(int userid, long? checkringstudyid, double? amountOfDeCompress, long CoverPageId, byte? validationStatusCode, List<CheckRingStudyWeightModel> checkRingStudyWeightList)
        {
            return _iCheckRingStudyWeightService.UpdateCheckRingStudyWeight(userid, checkringstudyid, amountOfDeCompress, CoverPageId, validationStatusCode, checkRingStudyWeightList);
        }
        #endregion
    }
}
