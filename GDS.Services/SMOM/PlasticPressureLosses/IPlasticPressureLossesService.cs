using GDS.Common;
using GDS.Entities.SMOM.PlasticPressureLosses;

namespace GDS.Services.SMOM.PlasticPressureLosses
{
    public interface IPlasticPressureLossesService
    {
        // Cold Runner System

        ApiResponse<ColdRunnerSystemModel> GetColdRunnerSystem(long coverPageId, int pressureUnitId);

        BaseApiResponse SaveColdRunnerSystem(ColdRunnerSystemModel model, int PressureUnitId);

        // Hot Runner System

        ApiResponse<HotRunnerModel> GetHotRunner(long coverPageId, int pressureUnitId);

        BaseApiResponse SaveHotRunner(HotRunnerModel model, int pressureUnitId);

        // Hot Drop To Cold Runner

        ApiResponse<HotDropToColdRunner> GetHotDropToColdRunner(long coverPageId, int pressureUnitId);

        BaseApiResponse SaveHotDropToColdRunner(HotDropToColdRunner model, int pressureUnitId);
    }
}
