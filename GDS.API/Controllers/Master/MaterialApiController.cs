using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class MaterialApiController : ApiController
    {
        #region Initializtions
        private readonly IMaterialService _iMaterialService;

        public MaterialApiController()
        {
            this._iMaterialService = EngineContext.Resolve<IMaterialService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetMaterialList")]
        public ApiResponse<MaterialModel> GetMaterialList(int MaterialId = 0)
        {
            return this._iMaterialService.GetMaterialList(MaterialId);
        }
        #endregion
    }
}
