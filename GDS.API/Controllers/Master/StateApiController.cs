namespace GDS.API.Controllers.Master
{
    using Common;
    using Entities.Master;
    using Services.Master.State;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class StateApiController : ApiController
    {
        #region Initializtions
        private readonly IStateService _iStateService;

        public StateApiController()
        {
            _iStateService = EngineContext.Resolve<IStateService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetStateList")]
        public ApiResponse<StateMasterModel> GetStateList()
        {
            return this._iStateService.GetStateList();
        }

        [HttpPost]
        [Route("AddOrUpdateState")]
        public BaseApiResponse AddOrUpdateState(int UserId, StateMasterModel StateObj)
        {
            return this._iStateService.AddOrUpdateState(UserId, StateObj);
        }

        [HttpGet]
        [Route("GetStateDetail")]
        public ApiResponse<StateMasterModel> GetStateDetail(int StateID)
        {
            return this._iStateService.GetStateDetail(StateID);
        }

        [HttpGet]
        [Route("GetCountryList")]
        public ApiResponse<CountryMasterModel> GetCountryList()
        {
            return this._iStateService.GetCountryList();
        }

        [HttpPost]
        [Route("DeleteState")]
        public BaseApiResponse DeleteState(int StateID)
        {
            return this._iStateService.DeleteState(StateID);
        }

        #endregion
    }
}
