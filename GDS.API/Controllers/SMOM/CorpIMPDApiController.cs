using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.SMOM.CorpIMPD;
using GDS.Services.SMOM.CorpIMPD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class CorpIMPDApiController : ApiController
    {
        #region Initializtions

        private readonly ICorpIMPDService _iService;

        public CorpIMPDApiController()
        {
            _iService = EngineContext.Resolve<ICorpIMPDService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetCorpIMPDMaterialData")]
        public ApiResponse<MaterialModel> GetCorpIMPDMaterialData(int MaterialTypeId)
        {
            return _iService.GetCorpIMPDMaterialData(MaterialTypeId);
        }

        [HttpPost]
        [Route("InsertOrUpdateCorpIMPD")]
        public BaseApiResponse InsertOrUpdateCorpIMPD(CorpIMPDModel model)
        {
            return _iService.InsertOrUpdateCorpIMPD(model);
        }

        [HttpGet]
        [Route("GetCorpIMPDDetail")]
        public ApiResponse<CorpIMPDModel> GetCorpIMPDDetail(int CoverPageId)
        {
            return _iService.GetCorpIMPDDetail(CoverPageId);
        }


        #endregion
    }
}
