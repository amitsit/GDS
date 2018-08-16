using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.CTPartThicknessAddition;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class CTPartThicknessAdditionApiController : ApiController
    {
        #region Initializtions

        private readonly ICTPartThicknessAdditionService _iCTPartThicknessAdditionService;

        public CTPartThicknessAdditionApiController()
        {
            _iCTPartThicknessAdditionService = EngineContext.Resolve<ICTPartThicknessAdditionService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetCTPartThicknessAddition")]
        public ApiResponse<CTPartThicknessAdditionModel> GetCTPartThicknessAddition(long? cTPartThicknessAdditionId = null)
        {
            return _iCTPartThicknessAdditionService.GetCTPartThicknessAddition(cTPartThicknessAdditionId);
        }

        [HttpPost]
        [Route("AddOrUpdateCTPartThicknessAdditionData")]
        public BaseApiResponse AddOrUpdateCTPartThicknessAdditionData(int UserId, CTPartThicknessAdditionModel CTPartThicknessAdditionObj)
        {
            return this._iCTPartThicknessAdditionService.AddOrUpdateCTPartThicknessAdditionData(UserId, CTPartThicknessAdditionObj);
        }


        [HttpPost]
        [Route("DeleteCTPartThicknessAdditionData")]
        public BaseApiResponse DeleteCTPartThicknessAdditionData(long CTPartThicknessAdditionId)
        {
            return this._iCTPartThicknessAdditionService.DeleteCTPartThicknessAdditionData(CTPartThicknessAdditionId);
        }
        #endregion
    }
}
