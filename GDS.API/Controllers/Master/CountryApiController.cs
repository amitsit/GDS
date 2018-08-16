

namespace GDS.API.Controllers.Master
{
    using Common;
    using Entities.Master;
    using GDS.Services.Master;
    using Services.Master.Country;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class CountryApiController : ApiController
    {
        #region Initializtions
        private readonly ICountryService _iCountryService;

        public CountryApiController()
        {
            this._iCountryService = EngineContext.Resolve<ICountryService>();
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("GetCountyList")]
        public ApiResponse<CountryMasterModel> GetCountyList(int? CountryId = null, int? RegionId = null)
        {
            return this._iCountryService.GetCountyList(CountryId, RegionId);
        }

        [HttpGet]
        [Route("GetCountryDetail")]
        public ApiResponse<CountryMasterModel> GetCountryDetail(int CountryID)
        {
            return this._iCountryService.GetCountryDetail(CountryID);
        }

        [HttpGet]
        [Route("GetRegionList")]
        public ApiResponse<RegionMasterModel> GetRegionList()
        {
            return this._iCountryService.GetRegionList();
        }

        [HttpPost]
        [Route("AddOrUpdateCountry")]
        public BaseApiResponse AddOrUpdateCountry(int UserId, CountryMasterModel CountryObj)
        {
            return this._iCountryService.AddOrUpdateCountry(UserId, CountryObj);
        }

        [HttpGet]
        [Route("DeleteCountry")]
        public BaseApiResponse DeleteCountry(int countryId)
        {
            return _iCountryService.DeleteCountry(countryId);
        }

        #endregion
    }
}
