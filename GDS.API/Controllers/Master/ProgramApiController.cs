using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class ProgramApiController : ApiController
    {
        #region Initializtions
        private readonly IProgramService _iProgramService;

        public ProgramApiController()
        {
            this._iProgramService = EngineContext.Resolve<IProgramService>();
        }
        #endregion


        [HttpGet]
        [Route("GetProgramList")]
        public ApiResponse<ProgramMasterModel> GetProgramList()
        {
            return this._iProgramService.GetProgramList();
        }

        [HttpGet]
        [Route("GetProgramDetail")]
        public ApiResponse<ProgramMasterModel> GetProgramDetail(int ProgramID)
        {
            return this._iProgramService.GetProgramDetail(ProgramID);
        }

        [HttpGet]
        [Route("GetPlantList")]
        public ApiResponse<PlantMasterModel> GetPlantList(int UserId)
        {
            return this._iProgramService.GetPlantList(UserId);
        }

        [HttpPost]
        [Route("AddOrUpdateProgram")]
        public BaseApiResponse AddOrUpdateProgram(int UserId, ProgramMasterModel ProgramObj)
        {
            return this._iProgramService.AddOrUpdateProgram(UserId, ProgramObj);
        }


        [HttpPost]
        [Route("DeleteProgram")]
        public BaseApiResponse DeleteProgram(long ProgramID)
        {
            return _iProgramService.DeleteProgram(ProgramID);
        }


    }
}
