using System;
using GDS.Common;
using GDS.Entities.Master;
using GDS.Entities.STMP.CustomerRequirement;
using GDS.Entities.STMP.InputData;
using System.Data;

namespace GDS.Services.STMP.CustomerRequirement
{
    public interface ICustomerRequirementService
    {
        ApiResponse<CustomerRequirementModel> GetCustomerRequirement(int? loggedInUserId, int plantId, int? plantMonthYearId, string SearchValue);

        ApiResponse<DatesList> Get7DayDatesIntervalForAYear(DateTime startDate);

        BaseApiResponse UpdateCustomerRequirementList(CustomerRequirementModel model);

        BaseApiResponse UploadCustomerRequirementFile(string datatableToxml, int UserId);

    }
}
