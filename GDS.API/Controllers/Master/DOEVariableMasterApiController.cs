
using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.DOEVariableMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class DOEVariableMasterApiController : ApiController
    {
        #region Initializtions
        private readonly IDOEVariableMasterService _iIDOEVariableMasterService;

        public DOEVariableMasterApiController()
        {
            _iIDOEVariableMasterService = EngineContext.Resolve<IDOEVariableMasterService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetDOEVariableType")]
        public ApiResponse<DOEVariableMasterModel> GetDOEVariableType()
        {
            return _iIDOEVariableMasterService.GetDOEVariableType();
        }

        [HttpPost]
        [Route("SaveDOEVariableMaster")]
        public BaseApiResponse SaveDOEVariableMaster(DOEVariableMasterModel dOEVariableModel)
        {
            return _iIDOEVariableMasterService.SaveDOEVariableMaster(dOEVariableModel);
        }

        [HttpGet]
        [Route("GetDOEVariableMasterById")]
        public ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterById(int VariableId)
        {
            return _iIDOEVariableMasterService.GetDOEVariableMasterById(VariableId);
        }

        [HttpGet]
        [Route("GetDOEVariableMasterList")]
        public ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterList()
        {
            return _iIDOEVariableMasterService.GetDOEVariableMasterList();
        }

        #endregion
    }
}




