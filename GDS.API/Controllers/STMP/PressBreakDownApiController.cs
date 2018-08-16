namespace GDS.API.Controllers.STMP
{
    using Common;
    using Entities.STMP.PressBreakDown;
    using Services.STMP.PressBreakDown;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class PressBreakDownApiController : ApiController
    {

        #region Initializtions

        private readonly IPressBreakDownService _iPressBreakDownService;

        public PressBreakDownApiController()
        {
            _iPressBreakDownService = EngineContext.Resolve<IPressBreakDownService>();
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("GetPressbreakDownList")]
        public ApiResponse<PressBreakDownModel> GetPressbreakDownList(int plantId,string cycleTimeSelection, string oee, string stdcyc, int userId, string weekString,int? tonnageRangeId, int? scenarioHeaderId,float? stdAllOeeValue)
        {
            return _iPressBreakDownService.GetPressbreakDownList(plantId,cycleTimeSelection, oee, stdcyc, userId,weekString, tonnageRangeId, scenarioHeaderId, stdAllOeeValue);
        }

        [HttpGet]
        [Route("RemoveToolFromPress")]
        public BaseApiResponse RemoveToolFromPress(long PressBreakdownId,long? ScenarioId, int UserId)
        {
            return _iPressBreakDownService.RemoveToolFromPress(PressBreakdownId, ScenarioId, UserId);
        }

        [HttpGet]
        [Route("InsertNewToolToPress")]
        public BaseApiResponse InsertNewToolToPress(int PlantId, string PressNumber, string ToolNumber, int UserId, long? scenarioHeaderId = null,int? PlantProgramId=null)
        {
            return _iPressBreakDownService.InsertNewToolToPress(PlantId, PressNumber, ToolNumber, UserId, scenarioHeaderId, PlantProgramId);
        }

        [HttpGet]
        [Route("GetToolListForPressbreakdownPress")]
        public ApiResponse<ToolForDDL> GetToolListForPressbreakdownPress(int plantId,int ScenarioIdParam)
        {
            return _iPressBreakDownService.GetToolListForPressbreakdownPress(plantId, ScenarioIdParam);
        }

        [HttpGet]
        [Route("GetProgramListForPressbreakdownByTool")]
        public ApiResponse<ProgramListForDDL> GetProgramListForPressbreakdownByTool(long? inputDataId)
        {
            return _iPressBreakDownService.GetProgramListForPressbreakdownByTool(inputDataId);
        }

        #endregion
    }
}
