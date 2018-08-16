namespace GDS.Services.STMP.PressBreakDown
{
    using Common;
    using Entities.STMP.PressBreakDown;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPressBreakDownService
    {
        ApiResponse<PressBreakDownModel> GetPressbreakDownList(int plantId, string cycleTimeSelection, string oee, string stdcyc, int userId, string weekString,int? tonnageRangeId, int? scenarioHeaderId,float? stdAllOeeValue);

        BaseApiResponse RemoveToolFromPress(long pressBreakdownId, long? scenarioId, int userId);

        BaseApiResponse InsertNewToolToPress(int plantId, string pressNumber, string toolNumber, int userId, long? scenarioHeaderId = null, int? PlantProgramId = null);

        ApiResponse<ToolForDDL> GetToolListForPressbreakdownPress(int plantId,int ScenarioIdParam);

        ApiResponse<ProgramListForDDL> GetProgramListForPressbreakdownByTool(long? inputDataId);
    }
}
