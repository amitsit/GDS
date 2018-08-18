using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Process
{
    [RoutePrefix("api")]
    public class ProcessApiController : ApiController
    {
        #region Initializtions
        private readonly IProcessService _iProcessService;

        public ProcessApiController()
        {
            this._iProcessService = EngineContext.Resolve<IProcessService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetProcesses")]
        public ApiResponse<ProcessModel> GetProcesses(int? MenuId)
        {
            return this._iProcessService.GetProcesses(MenuId);
        }


        #endregion
    }
}
