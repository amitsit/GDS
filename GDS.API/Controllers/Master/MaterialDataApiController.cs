using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.SMOM.MaterialData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class MaterialDataApiController : ApiController
    {
        #region Initializtions
        private readonly IMaterialDataService _iService;

        public MaterialDataApiController()
        {
            this._iService = EngineContext.Resolve<IMaterialDataService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetMaterialData")]
        public ApiResponse<MaterialModel> GetMaterialData(int? materialTypeId = 0, string searchFilter = "")
        {
            return this._iService.GetMaterialData(materialTypeId, searchFilter);
        }

        [HttpPost]
        [Route("InsertOrUpdateMaterial")]
        public BaseApiResponse InsertOrUpdateMaterial(MaterialModel model)
        {
            return this._iService.InsertOrUpdateMaterial(model);
        }

        [HttpGet]
        [Route("DeleteMaterial")]
        public BaseApiResponse DeleteMaterial(int materialId)
        {
            return this._iService.DeleteMaterial(materialId);
        }


        #endregion
    }
}
