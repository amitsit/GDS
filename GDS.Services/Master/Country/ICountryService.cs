

namespace GDS.Services.Master.Country
{
    using Common;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICountryService
    {
        ApiResponse<CountryMasterModel> GetCountyList(int? CountryId, int? RegionId);

        ApiResponse<CountryMasterModel> GetCountryDetail(int CountryID);

        ApiResponse<RegionMasterModel> GetRegionList();

        BaseApiResponse AddOrUpdateCountry(int InternalId, CountryMasterModel CountryObj);

        BaseApiResponse DeleteCountry(int countryId);
    }
}
