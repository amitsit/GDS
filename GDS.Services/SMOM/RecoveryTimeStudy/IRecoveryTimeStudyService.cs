using GDS.Common;
using GDS.Entities.SMOM.RecoveryTimeStudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.RecoveryTimeStudy
{
    public interface IRecoveryTimeStudyService
    {
        BaseApiResponse InsertUpdateRecoveryTimeStudy(Int16 PressureUnitId, Int16 LengthUnitId, RecoveryTimeStudyModel model);
        ApiResponse<RecoveryTimeStudyModel> GetRecoveryTimeStudy(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId);
        ApiResponse<RecoveryTimeStudyModel> GetRecoveryAdditinalParameters(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId);
        BaseApiResponse SaveRecoveryAdditinalParametersList(RecoveryTimeStudyModel model);
    }
}
