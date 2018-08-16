using GDS.Common;
using GDS.Entities.IMIP;
using GDS.Entities.Master;
using GDS.Entities.SMOM.CheckRingStudyWeight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CheckRingStudyWeight
{
    public interface ICheckRingStudyWeightService
    {
        ApiResponse<CheckRingStudyWeightModel> GetCheckRingStudyWeightList(long CoverPageId);
        BaseApiResponse UpdateCheckRingStudyWeight(int userid, long? checkringstudyid, double? amountOfDeCompress, long CoverPageId, byte? validationStatusCode, List<CheckRingStudyWeightModel> checkRingStudyWeightList);
    }
}
