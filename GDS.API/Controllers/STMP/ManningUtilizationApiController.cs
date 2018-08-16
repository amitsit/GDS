using GDS.Common;
using GDS.Entities.STMP.ManningUtilization;
using GDS.Services.STMP.ManningUtilization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class ManningUtilizationApiController : ApiController
    {

        #region Initializtions

        private readonly IManningUtilizationService _IManningUtilizationService;

        public ManningUtilizationApiController()
        {
            _IManningUtilizationService = EngineContext.Resolve<IManningUtilizationService>();
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("GetManningUtilizationAllocation")]
        public ApiResponse<ManningUtilizationModel> GetManningUtilizationAllocation(PlantUtilizationInputParamModel model)
        {
            return _IManningUtilizationService.GetManningUtilizationAllocation(model);
        }

        [HttpPost]
        [Route("UpdateStdReliefDivisorOrStdQuotedWeekhours")]
        public BaseApiResponse UpdateStdReliefDivisorOrStdQuotedWeekhours(int PlantId, int UserId, ManningUtilizationModel ManningUtilizationObj)
        {
            return _IManningUtilizationService.UpdateStdReliefDivisorOrStdQuotedWeekhours(PlantId, UserId, ManningUtilizationObj);
        }

        #endregion

    }
}
