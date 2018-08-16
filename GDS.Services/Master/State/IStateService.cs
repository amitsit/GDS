namespace GDS.Services.Master.State
{
    using Common;
    using Data.Repository;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    public interface IStateService
    {
        ApiResponse<StateMasterModel> GetStateList();
        BaseApiResponse AddOrUpdateState(int userid, StateMasterModel StateObj);
        ApiResponse<StateMasterModel> GetStateDetail(int? stateid);
        ApiResponse<CountryMasterModel> GetCountryList();
        BaseApiResponse DeleteState(int stateid);
    }
}
