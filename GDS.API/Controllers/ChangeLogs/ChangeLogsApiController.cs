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
        public ApiResponse<ChangeLogsModel> GetChangeLogs(int? UserId)
        {
            return this._iChangeLogsServices.GetChangeLogs(UserId);
        }

        [HttpGet]
        [Route("GetChangeLogsDetail")]
        public ApiResponse<ChangeLogsModel> GetChangeLogsDetail(string GUID,int? UserId)
        {
            return this._iChangeLogsServices.GetChangeLogsDetail(GUID,UserId);
        }

        [HttpGet]
        [Route("DeleteChangeLog")]
        public BaseApiResponse DeleteChangeLog(string GUID,int? UserId)
        {
            return this._iChangeLogsServices.DeleteChangeLog(GUID, UserId);
        }

        [HttpPost]
        [Route("SaveChangeLog")]
        public BaseApiResponse SaveChangeLog(int? UserId, ChangeLogsModel ChangeLogObj)
        {
            return this._iChangeLogsServices.SaveChangeLog(UserId, ChangeLogObj);
        }


    }
}
