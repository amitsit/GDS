using GDS.Common;
using GDS.Entities.IMIP;
using GDS.Services.IMIP.ImprovementPlanAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GDS.API.Controllers.IMIP
{
    [RoutePrefix("api")]
    public class ImprovementActionPlanApiController : ApiController
    {
        #region Constants
        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Initializtions
        private readonly IImprovementPlanActionService _iImprovementPlanActionService;

        public ImprovementActionPlanApiController()
        {
            _iImprovementPlanActionService = EngineContext.Resolve<IImprovementPlanActionService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetImprovementPlanActionList")]
        public ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionList(long bicVerificationDocumentId)
        {
            return _iImprovementPlanActionService.GetImprovementPlanActionList(bicVerificationDocumentId);
        }

        [HttpGet]
        [Route("GetImprovementPlanActionById")]
        public ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionById(long improvementPlanActionId)
        {
            return _iImprovementPlanActionService.GetImprovementPlanActionById(improvementPlanActionId);
        }

        [HttpPost]
        [Route("SaveOrUpdateImprovementActionPlan")]
        public BaseApiResponse SaveOrUpdateImprovementActionPlan(ImprovementPlanActionModel model)
        {
            return _iImprovementPlanActionService.SaveOrUpdateImprovementActionPlan(model);
        }

        [HttpGet]
        [Route("DeleteImprovementPlanAction")]
        public BaseApiResponse DeleteImprovementPlanAction(long PlanActionId,int UserId)
        {
            return _iImprovementPlanActionService.DeleteImprovementPlanAction(PlanActionId, UserId);
        }

        

        #endregion
    }
}
