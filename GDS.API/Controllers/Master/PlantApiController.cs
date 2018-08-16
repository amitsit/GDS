using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.Plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class PlantApiController : ApiController
    {
        #region Initializtions
        private readonly IPlantService _iPlantService;

        public PlantApiController()
        {
            this._iPlantService = EngineContext.Resolve<IPlantService>();
        }
        #endregion


        [HttpGet]
        [Route("GetPlantDetail")]
        public ApiResponse<PlantMasterModel> GetPlantDetail(int PlantID)
        {
            return this._iPlantService.GetPlantDetail(PlantID);
        }

        [HttpPost]
        [Route("SavePlant")]
        public BaseApiResponse SavePlant(PlantMasterModel plantObj)
        {
            return this._iPlantService.SavePlant(plantObj);
        }

        [HttpPost]
        [Route("DeletePlant")]
        public BaseApiResponse DeletePlant(long PlantID)
        {
            return _iPlantService.DeletePlant(PlantID);
        }

        [HttpGet]
        [Route("GetPlantListMaster")]
        public ApiResponse<PlantMasterModel> GetPlantListMaster(int? PlantId,int UserId)
        {
            return this._iPlantService.GetPlantListMaster(PlantId, UserId);
        }

    }
}
