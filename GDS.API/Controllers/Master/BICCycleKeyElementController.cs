using GDS.Common;
using GDS.Entities.Master;
using GDS.Services.Master.BICCycleKeyElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class BICCycleKeyElementController : ApiController
    {
        #region Initializtions
        private readonly IBICCycleKeyElementService _BICCycleKeyElementService;

        public BICCycleKeyElementController()
        {
            this._BICCycleKeyElementService = EngineContext.Resolve<IBICCycleKeyElementService>();
        }
        #endregion


        #region Methods
        [HttpGet]
        [Route("GetBICCycleKeyElementList")]
        public ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementList()
        {
            return this._BICCycleKeyElementService.GetBICCycleKeyElementList();
        }


        [HttpGet]
        [Route("GetBICCycleKeyElementDetail")]
        public ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementDetail(int BICCycleKeyElementID)
        {
            return this._BICCycleKeyElementService.GetBICCycleKeyElementDetail(BICCycleKeyElementID);
        }

       

        [HttpPost]
        [Route("AddOrUpdateBICCycleKeyElement")]
        public BaseApiResponse AddOrUpdateBICCycleKeyElement(int UserId, BICCycleKeyElementModel model)
        {
            return this._BICCycleKeyElementService.AddOrUpdateBICCycleKeyElement(UserId, model);
        }

        [HttpPost]
        [Route("DeleteBICCycleKeyElement")]
        public BaseApiResponse DeleteBICCycleKeyElement(int BICCycleKeyElementID)
        {
            return this._BICCycleKeyElementService.DeleteBICCycleKeyElement(BICCycleKeyElementID);
        }


        [HttpGet]
        [Route("GetBICCycleKeyElementStandardList")]
        public ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardList()
        {
            return this._BICCycleKeyElementService.GetBICCycleKeyElementStandardList();
        }


        [HttpGet]
        [Route("GetBICCycleKeyElementStandardDetail")]
        public ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardDetail(int BICCycleKeyElementStandardID)
        {
            return this._BICCycleKeyElementService.GetBICCycleKeyElementStandardDetail(BICCycleKeyElementStandardID);
        }



        [HttpPost]
        [Route("AddOrUpdateBICCycleKeyElementStandard")]
        public BaseApiResponse AddOrUpdateBICCycleKeyElementStandard(int UserId, BICCycleKeyElementStandardModel model)
        {
            return this._BICCycleKeyElementService.AddOrUpdateBICCycleKeyElementStandard(UserId, model);
        }

        [HttpPost]
        [Route("DeleteBICCycleKeyElementStandard")]
        public BaseApiResponse DeleteBICCycleKeyElementStandard(int BICCycleKeyElementStandardID)
        {
            return this._BICCycleKeyElementService.DeleteBICCycleKeyElementStandard(BICCycleKeyElementStandardID);
        }
        #endregion
    }
}
