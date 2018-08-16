using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GDS.Common;
using GDS.Services.Master.UtilityConfiguration;
using GDS.Entities.Master;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class UtilityConfigurationApiController : ApiController
    {
        #region Initializtions

        private readonly IUtilityConfigurationService _iIUtilityConfigurationService;

        public UtilityConfigurationApiController()
        {
            _iIUtilityConfigurationService = EngineContext.Resolve<IUtilityConfigurationService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetPlantConfigurationDetail")]
        public ApiResponse<UtilityConfigurationModel> GetPlantConfigurationDetail(int PlantId)
        {
            return this._iIUtilityConfigurationService.GetPlantConfigurationDetail(PlantId);
        }

        [HttpPost]
        [Route("UpdatePlantConfiguration")]
        public BaseApiResponse UpdatePlantConfiguration(int UserId, List<UtilityConfigurationModel> UtilityPlantDataCollection)
        {
            return this._iIUtilityConfigurationService.UpdatePlantConfiguration( UserId, UtilityPlantDataCollection);
        }

        #endregion

    }
}