using GDS.Entities.STMP.CapacityChart;
using GDS.Common;
using GDS.Entities.STMP.STMP_Configuration;

namespace GDS.Services.STMP.STMP_Configuration
{
    public interface IStmpConfigurationService
    {
        ApiResponse<PlantYearMonthModel> GetPlantYearMonthList(int plantId, int year, int month, int userId);

        BaseApiResponse CreateScenarioHeader(CreateScenarioInputParams model);

        ApiResponse<ScenarioHeaderModel> GetAllScenariosForSelectedPlant(int plantId, int loggedInUserId);

        BaseApiResponse SelectScenarioForSelectedPlant(long scenarioHeaderId, int plantId, int loggedInUserId);

        BaseApiResponse DeleteScenarioForSelectedPlant(long scenarioHeaderId, int loggedInUserId);

        BaseApiResponse DeactivateAllScenario(int plantId, int loggedInUserId);

        BaseApiResponse SetScenarioDataAsBaseData(long scenarioHeaderId, int loggedInUserId);
    }
}
