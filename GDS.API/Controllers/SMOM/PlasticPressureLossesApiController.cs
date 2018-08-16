using System.Web.Http;
using GDS.Common;
using GDS.Services.SMOM.PlasticPressureLosses;
using GDS.Entities.SMOM.PlasticPressureLosses;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class PlasticPressureLossesApiController : ApiController
    {
        #region Initializtions

        private readonly IPlasticPressureLossesService _iPlasticPressureLossesService;

        public PlasticPressureLossesApiController()
        {
            _iPlasticPressureLossesService = EngineContext.Resolve<IPlasticPressureLossesService>();
        }

        #endregion

        #region Methods

        #region Cold Runner System

        [HttpGet]
        [Route("GetColdRunnerSystem")]
        public ApiResponse<ColdRunnerSystemModel> GetColdRunnerSystem(long coverPageId, int pressureUnitId)
        {
            return _iPlasticPressureLossesService.GetColdRunnerSystem(coverPageId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveColdRunnerSystem")]
        public BaseApiResponse SaveColdRunnerSystem(ColdRunnerSystemModel model, int pressureUnitId)
        {
            return _iPlasticPressureLossesService.SaveColdRunnerSystem(model, pressureUnitId);
        }

        #endregion

        #region Hot Runner

        [HttpGet]
        [Route("GetHotRunner")]
        public ApiResponse<HotRunnerModel> GetHotRunner(long coverPageId,int pressureUnitId)
        {
            return _iPlasticPressureLossesService.GetHotRunner(coverPageId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveHotRunner")]
        public BaseApiResponse SaveHotRunner(HotRunnerModel model,int pressureUnitId)
        {
            return _iPlasticPressureLossesService.SaveHotRunner(model, pressureUnitId);
        }

        #endregion

        #region Hot Drop To Cold Runner

        [HttpGet]
        [Route("GetHotDropToColdRunner")]
        public ApiResponse<HotDropToColdRunner> GetHotDropToColdRunner(long coverPageId,int pressureUnitId)
        {
            return _iPlasticPressureLossesService.GetHotDropToColdRunner(coverPageId, pressureUnitId);
        }

        [HttpPost]
        [Route("SaveHotDropToColdRunner")]
        public BaseApiResponse SaveHotDropToColdRunner(HotDropToColdRunner model,int pressureUnitId)
        {
            return _iPlasticPressureLossesService.SaveHotDropToColdRunner(model, pressureUnitId);
        }

        #endregion

        #endregion
    }
}
