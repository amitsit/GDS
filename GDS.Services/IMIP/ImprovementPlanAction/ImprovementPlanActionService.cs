using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.IMIP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.IMIP.ImprovementPlanAction
{
    public class ImprovementPlanActionService : IImprovementPlanActionService
    {
        #region Constants
        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Fields
        /// <summary>
        /// Declare The provider repository object for perform operation on Provider repository
        /// </summary>
        private readonly IGenericRepository<ImprovementPlanActionModel> _repository;
        #endregion

        #region ctor
        public ImprovementPlanActionService(IGenericRepository<ImprovementPlanActionModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        public ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionList(long bicVerificationDocumentId)
        {
            var response = new ApiResponse<ImprovementPlanActionModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("BICVerificationDocumentId",(object)bicVerificationDocumentId?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<ImprovementPlanActionModel>(
                                "usp_imip_ImprovementPlanAction_get", paramList).ToList();

                response.Success = true;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public ApiResponse<ImprovementPlanActionModel> GetImprovementPlanActionById(long improvementPlanActionId)
        {
            var response = new ApiResponse<ImprovementPlanActionModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlanActionId",(object)improvementPlanActionId?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<ImprovementPlanActionModel>(
                                "usp_imip_ImprovementPlanAction_getById", paramList).FirstOrDefault();


                if (result != null)
                {
                    response.Success = true;
                    response.Data = new List<ImprovementPlanActionModel>();
                    response.Data.Add(result);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public BaseApiResponse SaveOrUpdateImprovementActionPlan(ImprovementPlanActionModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlanActionId",(object)model.PlanActionId),
                    new SqlParameter("BICVerificationDocumentId",(object)model.BICVerificationDocumentId),
                    new SqlParameter("TaskDescription",(object)model.TaskDescription?? DBNull.Value),
                    new SqlParameter("PromiseDate",(object)model.PromiseDate?? DBNull.Value),
                    new SqlParameter("ClosedDate",(object)model.ClosedDate?? DBNull.Value),
                    new SqlParameter("Comments",(object)model.Comments?? DBNull.Value),
                    new SqlParameter("Champion",(object)model.Champion?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId)
                };

                var result = _repository.ExecuteSQL<long>(
                                "usp_imip_ImprovementPlanAction_save", paramList).FirstOrDefault();

                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public BaseApiResponse DeleteImprovementPlanAction(long PlanActionId, int UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlanActionId",(object)PlanActionId),
                    new SqlParameter("LoggedInUserId",(object)UserId)
                };

                var result = _repository.ExecuteSQL<int>(
                                "usp_imip_DeleteImprovementPlanAction", paramList).FirstOrDefault();

                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        #endregion
    }
}
