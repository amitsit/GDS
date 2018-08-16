using GDS.Common;
using GDS.Entities.Master;

namespace GDS.Services.Master.WallStock
{
    public interface IWallStockService
    {
        ApiResponse<WallStockModel> GetWallStock(int? wallStockId);

        BaseApiResponse SaveWallStock(WallStockModel model);

        BaseApiResponse DeleteWallStock(int wallStockId);

        ApiResponse<MaterialTypeMasterModel> GetMaterialTypeList(int wallStockId);

        ApiResponse<WallStockCTPartRange> GetWallStockCTPartRangeList();
    }
}
