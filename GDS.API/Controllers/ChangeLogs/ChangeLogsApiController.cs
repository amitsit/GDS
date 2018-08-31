using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.ChangeLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.ChangeLogs
{
    [RoutePrefix("api")]
    public class ChangeLogsApiController : ApiController
    {
        #region Initializtions
        private readonly IChangeLogsServices _iChangeLogsServices;

        public ChangeLogsApiController()
        {
            this._iChangeLogsServices = EngineContext.Resolve<IChangeLogsServices>();
        }
        #endregion

        [HttpGet]
        [Route("GetChangeLogs")]
        public ApiResponse<ChangeLogsModel> GetChangeLogs(int? MenuId)
        {
            return this._iChangeLogsServices.GetChangeLogs(MenuId);
        }


    }
}
