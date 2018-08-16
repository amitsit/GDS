using GDS.Common;
using GDS.Entities.STMP.DailyRecapRap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.STMP.DailyRecapRap_PressParameters
{
    public interface IDailyRecapRap_PressParametersService
    {
        ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPressParameters(int plantId, int userId, Int64 plantMonthYearId);

        BaseApiResponse UpdateDailyRecapRepPressParameters(int plantId, int userId, long plantMonthYearId, List<STMP_DailyRecapRap_PressParametersModel> dailyRecapRapPressParametersList);
        ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPlantMasterDetail();
    }
}
