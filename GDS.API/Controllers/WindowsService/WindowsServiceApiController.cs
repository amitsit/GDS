using System.Collections.Generic;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.WindowsService;
using GDS.Services.WindowsServices;

namespace GDS.API.Controllers.WindowsService
{
    [RoutePrefix("api")]
    public class WindowsServiceApiController : ApiController
    {
        private readonly IWindowsService _iService;

        public WindowsServiceApiController()
        {
            _iService = EngineContext.Resolve<IWindowsService>();
        }

        [HttpGet]
        [Route("InsertGradeCardHistoryRecord")]
        public BaseApiResponse InsertGradeCardHistoryRecord()
        {
            return _iService.InsertGradeCardHistoryRecord();
        }

        [HttpGet]
        [Route("GetAreaIdForPlantForShopLogix")]
        public ApiResponse<ShopLogixPlantListModel> GetAreaIdForPlantForShopLogix()
        {
            return _iService.GetAreaIdForPlantForShopLogix();
        }

        [HttpPost]
        [Route("UpdateOEEFromShopLogix")]
        public BaseApiResponse UpdateOEEFromShopLogix(List<UpdateOeeInDailyRecapInputModel> listUpdateOeeInDailyRecapInputModel)
        {
            return _iService.UpdateOEEFromShopLogix(listUpdateOeeInDailyRecapInputModel);
        }

        [HttpPost]
        [Route("SaveQADDataFromService")]
        public BaseApiResponse SaveQADDataFromService(List<SaveQADFromServiceInputModel> listSaveQADFromServiceInputModel)
        {
            return _iService.SaveQADDataFromService(listSaveQADFromServiceInputModel);
        }

        

    }
}
