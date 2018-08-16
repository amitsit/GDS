using GDS.Common;
using GDS.Entities.STMP.CapitalPlanBenifits;
using System.Web.Http;
using GDS.Services.STMP.MainDashboard;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class MainDashboardApiController : ApiController
    {
        #region Initializtions

        private readonly IMainDashboardService _iService;

        public MainDashboardApiController()
        {
            _iService = EngineContext.Resolve<IMainDashboardService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetDashboardPlantSelectionData")]
        public ApiResponse<DashboardPlantSelection> GetDashboardPlantSelectionData(int regionId,int UserId)
        {
            return _iService.GetDashboardPlantSelectionData(regionId, UserId);
        }

        [HttpPost]
        [Route("GetMainDashBoardData")]
        public ApiResponse<CapitalPlanBenifitsModel> GetMainDashBoardData(CapitalPlanBenifitsInputModel model)
        {
            return _iService.GetMainDashBoardData(model);
        }

        #endregion
    }
}