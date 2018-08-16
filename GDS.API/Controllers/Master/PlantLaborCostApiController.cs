using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.PlantLaborCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class PlantLaborCostApiController : ApiController
    {
        #region Initializtions
        private readonly IPlantLaborCostService _iPlantLaborCostService;

        public PlantLaborCostApiController()
        {
            this._iPlantLaborCostService = EngineContext.Resolve<IPlantLaborCostService>();
        }
        #endregion


        #region Methods

        [HttpGet]
        [Route("GetPlantLaborCost")]
        public ApiResponse<PlantLaborCostModel> GetPlantLaborCost(long? PlantLaborCostId = null)
        {
            return _iPlantLaborCostService.GetPlantLaborCost(PlantLaborCostId);
        }


        [HttpPost]
        [Route("SavePlantLaborCost")]
        public BaseApiResponse SavePlantLaborCost(PlantLaborCostModel model)
        {
            return this._iPlantLaborCostService.SavePlantLaborCost(model);
        }

        [HttpPost]
        [Route("DeletePlantLaborCost")]
        public BaseApiResponse DeletePlantLaborCost(long PlantLaborCostId)
        {
            return this._iPlantLaborCostService.DeletePlantLaborCost(PlantLaborCostId);
        }

        #endregion
    }
}
