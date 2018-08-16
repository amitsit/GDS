using System;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.SMOM.CavityBalance;
using GDS.Services.SMOM.CavityBalance;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]    
    public class CavityBalanceController : ApiController
    {
        #region Initializtions
        private readonly ICavityBalanceService _iCavityBalanceService;

        public CavityBalanceController()
        {
            _iCavityBalanceService = EngineContext.Resolve<ICavityBalanceService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetCavityBalanceList")]
        public ApiResponse<CavityBalanceModel> GetCavityBalanceList(long coverPageId)
        {
            return _iCavityBalanceService.GetCavitybalanceList(coverPageId);
        }

        [HttpPost]
        [Route("SaveCavityBalanceDetails")]
        public BaseApiResponse SaveCavityBalanceDetail(int CreatedBy, CavityBalanceModel cavityBalanceModel)
        {
            return _iCavityBalanceService.SaveCavityBalanceDetail(cavityBalanceModel, CreatedBy);
        }

        #endregion
    }
}
