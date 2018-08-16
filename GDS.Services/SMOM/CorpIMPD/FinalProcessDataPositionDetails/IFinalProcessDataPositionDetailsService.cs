using GDS.Common;
using GDS.Entities.SMOM.CorpIMPD;
using System.Collections.Generic;
using GDS.Entities.SMOM.InitialDataConversionSetup;

namespace GDS.Services.SMOM.CorpIMPD.FinalProcessDataPositionDetails
{
    public interface IFinalProcessDataPositionDetailsService
    {
        ApiResponse<FinalProcessDataPositionDetailsModel> GetFinalProcessDataPositionDetails(InitDataInputDataModel model);

        BaseApiResponse SaveFinalProcessDataPositionDetails(long initDataGeneralInfoId, int loggedInUserId, int lengthUnitId,
            List<FinalProcessDataPositionDetailsModel> listFinalProcessDataPositionDetailsMode);
    }
}
