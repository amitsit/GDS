using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.SubProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SubProcess
{
    [RoutePrefix("api")]
    public class SubProcessApiController : ApiController
    {

        #region Initializtions
        private readonly ISubProcessService _iSubProcessService;

        public SubProcessApiController()
        {
            this._iSubProcessService = EngineContext.Resolve<ISubProcessService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetSubProcess")]
        public ApiResponse<SubProcessModel> GetSubProcess(int? ProcessId,int? SubProcessId,int? RegionId,int? UserId)
        {
            return this._iSubProcessService.GetSubProcess(ProcessId, SubProcessId, RegionId, UserId);
        }

        [HttpGet]
        [Route("GetSubProcessListByStatus")]
        public ApiResponse<SubProcessModel> GetSubProcessListByStatus(int? ProcessId, int? SubProcessId, int? RegionId, int? UserId,bool? IsActive)
        {
            return this._iSubProcessService.GetSubProcessListByStatus(ProcessId, SubProcessId, RegionId, UserId,IsActive);
        }

        [HttpGet]
        [Route("GetProcessDocumentBySubProcessIdAndRegionId")]
        public ApiResponse<ProcessDocument> GetProcessDocumentBySubProcessIdAndRegionId(int? SubProcessId,int? RegionId, int? UserId)
        {
            return this._iSubProcessService.GetProcessDocumentBySubProcessIdAndRegionId(SubProcessId, RegionId, UserId);
        }

        #endregion

    }
}
