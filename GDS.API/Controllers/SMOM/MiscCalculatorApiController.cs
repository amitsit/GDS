using GDS.Common;
using GDS.Entities.SMOM.MiscCalculator;
using GDS.Services.SMOM.MiscCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class MiscCalculatorApiController : ApiController
    {
        #region Initializtions

        private readonly IMiscCalculatorService _iService;

        public MiscCalculatorApiController()
        {
            _iService = EngineContext.Resolve<IMiscCalculatorService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetMiscCalculatorDetail")]
        public ApiResponse<MiscCalculatorModel> GetMiscCalculatorDetail(long CoverPageId,Int16 LengthUnitId,Int16 PressureUnitId)
        {
            return _iService.GetMiscCalculatorDetail(CoverPageId, LengthUnitId, PressureUnitId);
        }


        [HttpPost]
        [Route("SaveOrUpdateMiscCalculator")]
        public BaseApiResponse SaveOrUpdateMiscCalculator(int UserId, long CoverPageId , Int16 LengthUnitId, Int16 PressureUnitId,MiscCalculatorModel MiscModel)
        {
            return _iService.SaveOrUpdateMiscCalculator(UserId, CoverPageId, LengthUnitId, PressureUnitId, MiscModel);
        }
        #endregion
    }

}