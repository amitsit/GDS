using GDS.Common;
using GDS.Services.STMP.LaborPlant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Entities.STMP.LaborPlantSpecific;
using GDS.Services.STMP.LaborPlantSpecific;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class LaborPlantSpecificApiController : ApiController
    {
        #region Initializtions

        private readonly ILaborPlantSpecificService _iLaborPlantSpecificService;

        public LaborPlantSpecificApiController()
        {
            _iLaborPlantSpecificService = EngineContext.Resolve<ILaborPlantSpecificService>();
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("GetLaborPlantSpecificDetail")]
        public ApiResponse<LaborPlantSpecificModel> GetLaborPlantSpecificDetail(LaborPlantSpecificInputDataModel model)
        {
            return _iLaborPlantSpecificService.GetLaborPlantSpecificDetail(model);
        }

        #endregion
    }
}
