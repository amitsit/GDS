using System.Web.Http;
using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.MaterialType;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class MaterialTypeController : ApiController
    {
        #region Initializtions

        private readonly IMaterialTypeService _iService;

        public MaterialTypeController()
        {
            _iService = EngineContext.Resolve<IMaterialTypeService>();
        }

        #endregion

        [HttpGet]
        [Route("GetMaterialType")]
        public ApiResponse<MaterialTypeMasterModel> GetMaterialType(int? materialTypeId = null)
        {
            return _iService.GetMaterialType(materialTypeId);
        }

        [HttpPost]
        [Route("SaveMaterialType")]
        public BaseApiResponse SaveMaterialType(MaterialTypeMasterModel model)
        {
            return _iService.SaveMaterialType(model);
        }

        [HttpPost]
        [Route("DeleteMaterialType")]
        public BaseApiResponse DeleteMaterialType(int materialTypeId)
        {
            return _iService.DeleteMaterialType(materialTypeId);
        }
    }
}
