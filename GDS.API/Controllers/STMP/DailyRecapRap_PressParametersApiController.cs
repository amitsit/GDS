using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Services.STMP.DailyRecapRap_PressParameters;
using GDS.Common;
using GDS.Entities.STMP.DailyRecapRap;
using log4net.Core;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class DailyRecapRap_PressParametersApiController : ApiController
    {
        #region Initializtions

        private readonly IDailyRecapRap_PressParametersService _iDailyRecapRap_PressParametersService;

        public DailyRecapRap_PressParametersApiController()
        {
            _iDailyRecapRap_PressParametersService = EngineContext.Resolve<IDailyRecapRap_PressParametersService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetDailyRecapRapPressParameters")]
        public ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPressParameters(int plantId, int userId, long plantMonthYearId)
        {
            return _iDailyRecapRap_PressParametersService.GetDailyRecapRapPressParameters(plantId, userId, plantMonthYearId);
        }

        [HttpPost]
        [Route("UpdateDailyRecapRepPressParameters")]
        public BaseApiResponse UpdateDailyRecapRepPressParameters(int plantId, int userId, long plantMonthYearId, List<STMP_DailyRecapRap_PressParametersModel> DailyRecapRapPressParametersList)
        {
            return _iDailyRecapRap_PressParametersService.UpdateDailyRecapRepPressParameters(plantId, userId, plantMonthYearId, DailyRecapRapPressParametersList);
        }

        [HttpGet]
        [Route("GetDailyRecapRapPlantMasterDetail")]
        public ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPlantMasterDetail()
        {
                return _iDailyRecapRap_PressParametersService.GetDailyRecapRapPlantMasterDetail();
        }
        #endregion
    }
}
