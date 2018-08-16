using GDS.Common;
using GDS.Entities.SMOM.DOE;
using GDS.Services.SMOM.DOE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class DOEApiController : ApiController
    {
        #region Initializtions
        private readonly IDOEService _iIDOEService;

        public DOEApiController()
        {
            _iIDOEService = EngineContext.Resolve<IDOEService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetDOEList")]
        public ApiResponse<DOEModel> GetDOEList(long coverPageId, int lengthUnitId,int pressureUnitId)
        {
            return _iIDOEService.GetDOEList(coverPageId, lengthUnitId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveDOEModelList")]
        public BaseApiResponse SaveDOEModelList(DOEModel dOEModel)
        {
            return _iIDOEService.SaveDOEModelList(dOEModel);
        }

        [HttpGet]
        [Route("DOEVariableList")]
        public ApiResponse<DOEVariableList> DOEVariableList()
        {
            return _iIDOEService.DOEVariableList();
        }

        #endregion
    }
}
