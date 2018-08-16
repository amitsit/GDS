using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM;
using GDS.Services.Master.ColorCodeScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class ColorCodeSchemeApiController : ApiController
    {
        #region Initializtions
        private readonly IColorCodeSchemeService _iColorCodeSchemeService;

        public ColorCodeSchemeApiController()
        {
            this._iColorCodeSchemeService = EngineContext.Resolve<IColorCodeSchemeService>();
        }
        #endregion

        #region Methods
        [HttpPost]
        [Route("GetColorCodeSchemeList")]
        public ApiResponse<ColorCodeSchemeModel> GetColorCodeSchemeList(Int16 LengthUnitId, Int16 PressureUnitId, TroubleShooterPostModel Model)
        {
            return this._iColorCodeSchemeService.GetColorCodeSchemeList(LengthUnitId, PressureUnitId, Model);
        }

        #endregion
    }
}
