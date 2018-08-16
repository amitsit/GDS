using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Common;
using GDS.Services.Master.TroubleShooter;
using GDS.Entities.Master;
using GDS.Entities.SMOM;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class TroubleShooterApiController : ApiController
    {
        #region Initializtions

        private readonly ITroubleShooterService _iTroubleShooterService;

        public TroubleShooterApiController()
        {
            _iTroubleShooterService = EngineContext.Resolve<ITroubleShooterService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetTroubleShooterList")]
        public ApiResponse<TroubleShooterModel> GetTroubleShooterList(long TroubleShooterId)
        {
            return _iTroubleShooterService.GetTroubleShooterList(TroubleShooterId);
        }

        [HttpGet]
        [Route("GetTroubleShooterDetail")]
        public ApiResponse<TroubleShooterModel> GetTroubleShooterDetail(long TroubleShooterId)
        {
            return _iTroubleShooterService.GetTroubleShooterDetail(TroubleShooterId);
        }

        [HttpPost]
        [Route("AddOrUpdateTroubleShooter")]
        public BaseApiResponse AddOrUpdateTroubleShooter(TroubleShooterModel model)
        {
            return _iTroubleShooterService.AddOrUpdateTroubleShooter(model);
        }

        [HttpPost]
        [Route("DeleteTroubleShooter")]
        public BaseApiResponse DeleteTroubleShooter(long TroubleShooterId)
        {
            return this._iTroubleShooterService.DeleteTroubleShooter(TroubleShooterId);
        }

        [HttpGet]
        [Route("GetPageHelpContent")]
        public ApiResponse<TroubleShooterModel> GetPageHelpContent(long TroubleShooterId)
        {
            return _iTroubleShooterService.GetPageHelpContent(TroubleShooterId);
        }

        [HttpGet]
        [Route("GetPageHelp")]
        public ApiResponse<TroubleShooterModel> GetPageHelp(string PageName,string LanguageCd)
        {
            return _iTroubleShooterService.GetPageHelp(PageName, LanguageCd);
        }

        [HttpPost]
        [Route("GetPageHelpDetail")]
        public ApiResponse<TroubleShooterModel> GetPageHelpDetail(TroubleShooterPostModel model)
        {
            return _iTroubleShooterService.GetPageHelpDetail(model.PageName, model.LanguageCd);
        }

        #endregion
    }
}
