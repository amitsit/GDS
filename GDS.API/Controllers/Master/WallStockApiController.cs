using System.Web.Http;
using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.WallStock;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class WallStockApiController : ApiController
    {
        #region Initializtions

        private readonly IWallStockService _iService;

        public WallStockApiController()
        {
            _iService = EngineContext.Resolve<IWallStockService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetWallStock")]
        public ApiResponse<WallStockModel> GetWallStock(int? wallStockId = null)
        {
            return _iService.GetWallStock(wallStockId);
        }

        [HttpPost]
        [Route("SaveWallStock")]
        public BaseApiResponse SaveWallStock(WallStockModel model)
        {
            return _iService.SaveWallStock(model);
        }

        [HttpPost]
        [Route("DeleteWallStock")]
        public BaseApiResponse DeleteWallStock(int wallStockId)
        {
            return _iService.DeleteWallStock(wallStockId);
        }

        [HttpGet]
        [Route("GetMaterialTypeList")]
        public ApiResponse<MaterialTypeMasterModel> GetMaterialTypeList(int wallStockId = 0)
        {
            return _iService.GetMaterialTypeList(wallStockId);
        }

        [HttpGet]
        [Route("GetWallStockCTPartRangeList")]
        public ApiResponse<WallStockCTPartRange> GetWallStockCTPartRangeList()
        {
            return _iService.GetWallStockCTPartRangeList();
        }

        #endregion
    }
}
