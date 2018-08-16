using GDS.Common;
using GDS.Entities.IMIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.IMIP.ImprovementPlanAction
{
    public interface IImprovementPlanActionService
    {
        ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionList(long bicVerificationDocumentId);
        ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionById(long improvementPlanActionId);
        BaseApiResponse SaveOrUpdateImprovementActionPlan(ImprovementPlanActionModel model);
        BaseApiResponse DeleteImprovementPlanAction(long PlanActionId, int UserId);

        
    }
}
