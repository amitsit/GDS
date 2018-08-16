using GDS.Common;
using GDS.Entities.STMP.MROData;
using GDS.Services.STMP.MROData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class MRODataApiController : ApiController
    {
        private readonly IMRODataService _iMRODataService;

        public MRODataApiController()
        {
            _iMRODataService = EngineContext.Resolve<IMRODataService>();
        }


        #region Methods
        [HttpGet]
        [Route("GetMROData")]
        public ApiResponse<MRODataModel> GetMROData(int PlantId)
        {
            return _iMRODataService.GetMROData(PlantId);
        }


        [HttpPost]
        [Route("SaveMROData")]
        public BaseApiResponse SaveMROData(MRODataModel mRODataModel)
        {
            return _iMRODataService.SaveMROData(mRODataModel);
        }


        #endregion
    }
}
