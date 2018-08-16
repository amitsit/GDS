using GDS.Common;
using GDS.Entities.STMP.STMP_Configuration;
using GDS.Services.STMP.STMP_Configuration;
using System.Web.Http;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class StmpConfigurationApiController : ApiController
    {
        #region Initializtions

        private readonly IStmpConfigurationService _iStmpConfigurationService;

        public StmpConfigurationApiController()
        {
            _iStmpConfigurationService = EngineContext.Resolve<IStmpConfigurationService>();
        }
        
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetPlantYearMonthList")]
        public ApiResponse<PlantYearMonthModel> GetPlantYearMonthList(int plantId, int year, int month, int userId)
        {
            return _iStmpConfigurationService.GetPlantYearMonthList(plantId, year, month, userId);
        }

        [HttpPost]
        [Route("CreateScenarioHeader")]
        public BaseApiResponse CreateScenarioHeader(CreateScenarioInputParams model)
        {
            return _iStmpConfigurationService.CreateScenarioHeader(model);
        }

        [HttpGet]
        [Route("GetAllScenariosForSelectedPlant")]
        public ApiResponse<ScenarioHeaderModel> GetAllScenariosForSelectedPlant(int plantId, int loggedInUserId)
        {
            return _iStmpConfigurationService.GetAllScenariosForSelectedPlant(plantId, loggedInUserId);
        }

        [HttpPost]
        [Route("SelectScenarioForSelectedPlant")]
        public BaseApiResponse SelectScenarioForSelectedPlant(long scenarioHeaderId, int plantId, int loggedInUserId)
        {
            return _iStmpConfigurationService.SelectScenarioForSelectedPlant(scenarioHeaderId,plantId, loggedInUserId);
        }

        [HttpPost]
        [Route("DeleteScenarioForSelectedPlant")]
        public BaseApiResponse DeleteScenarioForSelectedPlant(long scenarioHeaderId, int loggedInUserId)
        {
            return _iStmpConfigurationService.DeleteScenarioForSelectedPlant(scenarioHeaderId, loggedInUserId);
        }

        [HttpPost]
        [Route("DeactivateAllScenario")]
        public BaseApiResponse DeactivateAllScenario(int plantId, int loggedInUserId)
        {
            return _iStmpConfigurationService.DeactivateAllScenario(plantId, loggedInUserId);
        }

        [HttpPost]
        [Route("SetScenarioDataAsBaseData")]
        public BaseApiResponse SetScenarioDataAsBaseData(long scenarioHeaderId, int loggedInUserId)
        {
            return _iStmpConfigurationService.SetScenarioDataAsBaseData(scenarioHeaderId, loggedInUserId);
        }
        #endregion
    }
}
