using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.Master.IACCycleGoalModel;
using GDS.Services.Master.IACCycleGoal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.Master
{
    [RoutePrefix("api")]
    public class IACCycleGoalApiController : ApiController
    {
        #region Initializtions
        private readonly IACCycleGoalService _IACCycleGoalService;

        public IACCycleGoalApiController()
        {
            this._IACCycleGoalService = EngineContext.Resolve<IACCycleGoalService>();
        }
        #endregion


        #region Methods

        [HttpGet]
        [Route("GetTonnageRange")]
        public ApiResponse<TonnageRangeModel> GetTonnageRange()
        {
            return _IACCycleGoalService.GetTonnageRange();
        }

        [HttpGet]
        [Route("GetIACCycleGoalList")]
        public ApiResponse<IACCycleGoalModel> GetIACCycleGoalList()
        {
            return this._IACCycleGoalService.GetIACCycleGoalList();
        }

        [HttpGet]
        [Route("GetIACCycleGoalDetail")]
        public ApiResponse<IACCycleGoalModel> GetIACCycleGoalDetail(int IACCycleGoalId)
        {
            return this._IACCycleGoalService.GetIACCycleGoalDetail(IACCycleGoalId);
        }



        [HttpPost]
        [Route("AddOrUpdateIACCycleGoalData")]
        public BaseApiResponse AddOrUpdateIACCycleGoalData(int UserId, IACCycleGoalModel IACCCycleObj)
        {
            return this._IACCycleGoalService.AddOrUpdateIACCycleGoalData(UserId, IACCCycleObj);
        }


        [HttpPost]
        [Route("DeleteIACCycleGoalData")]
        public BaseApiResponse DeleteIACCycleGoalData(int IACCycleGoalId)
        {
            return this._IACCycleGoalService.DeleteIACCycleGoalData(IACCycleGoalId);
        }
        #endregion
    }
}