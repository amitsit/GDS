using GDS.Common;
using GDS.Entities.STMP.ReplacementSavings;
using GDS.Services.STMP.ReplacementSavings;
using System.Web.Http;
using System.Collections.Generic;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class ReplacementSavingApiController : ApiController
    {
        private readonly IReplacementSavingService _iReplacementSavingService;

        public ReplacementSavingApiController()
        {
            _iReplacementSavingService = EngineContext.Resolve<IReplacementSavingService>();
        }

        #region Methods

        [HttpPost]
        [Route("GetReplacementSavings")]
        public ApiResponse<ReplacementSavingsModel> GetReplacementSavings(ReplacementSavingsInputModel model)
        {
            return _iReplacementSavingService.GetReplacementSavings(model);
        }

        [HttpPost]
        [Route("SaveReplacementSavings")]
        public BaseApiResponse SaveReplacementSavings(List<ReplacementSavingsModel> model, int loggedInUserId)
        {
            return _iReplacementSavingService.SaveReplacementSavings(model, loggedInUserId);
        }
        
        #endregion
    }
}
