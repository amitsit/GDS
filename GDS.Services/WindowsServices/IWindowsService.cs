using System.Collections.Generic;
using GDS.Common;
using GDS.Entities.WindowsService;

namespace GDS.Services.WindowsServices
{
    public interface IWindowsService
    {
        BaseApiResponse InsertGradeCardHistoryRecord();

        ApiResponse<ShopLogixPlantListModel> GetAreaIdForPlantForShopLogix();

        BaseApiResponse UpdateOEEFromShopLogix(List<UpdateOeeInDailyRecapInputModel> listUpdateOeeInDailyRecapInputModel);

        BaseApiResponse SaveQADDataFromService(List<SaveQADFromServiceInputModel> listSaveQADFromServiceInputModel);
    }
}
