using System.Web.Http;
using GDS.Common;
using GDS.Entities.Dashboard;
using GDS.Services.Dashboard;

namespace GDS.API.Controllers.Dashboard
{
    [RoutePrefix("api")]
    public class DashboardApiController : ApiController
    {

        #region Initializtions

        private readonly IDashboardService _service;

        public DashboardApiController()
        {
            _service = EngineContext.Resolve<IDashboardService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetConfigurationMasterValues")]
        public ApiResponse<ConfigurationMasterModel> GetConfigurationMasterValues()
        {
            return _service.GetConfigurationMasterValues();
        }

        [HttpPost]
        [Route("GetDashboardPerformances")]
        public ApiResponse<PerformancesModel> GetDashboardPerformances(PerformancesInputModel model)
        {
            return _service.GetDashboardPerformances(model);
        }

        [HttpPost]
        [Route("GetPlantCycleTimeGradeCard")]
        public ApiResponse<GradeCardModel> GetPlantCycleTimeGradeCard(GradeCardInputModel model)
        {
            return _service.GetPlantCycleTimeGradeCard(model);
        }

        [HttpPost]
        [Route("GetPressTotalCostSavings")]
        public ApiResponse<PressTotalCostSavingsModel> GetPressTotalCostSavings(PressTotalCostSavingsInputModel model)
        {
            return _service.GetPressTotalCostSavings(model);
        }
        
        [HttpGet]
        [Route("GetGradeCardGraphData")]
        public ApiResponse<GradeCardChartModel> GetGradeCardGraphData(int UserId)
        {
            return _service.GetGradeCardGraphData(UserId);
        }

        #endregion
    }
}
