using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.ReplacementSavings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GDS.Services.STMP.ReplacementSavings
{
    public class ReplacementSavingService : IReplacementSavingService
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
        private readonly IGenericRepository<ReplacementSavingsModel> _repository;

        #endregion

        #region constructor
        public ReplacementSavingService(IGenericRepository<ReplacementSavingsModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        
        public ApiResponse<ReplacementSavingsModel> GetReplacementSavings(ReplacementSavingsInputModel model)
        {
            var response = new ApiResponse<ReplacementSavingsModel>();
            
            try
            {
                object[] paramList =
                {
                    //new SqlParameter("AssumedShiftsperMachine",model.AssumedShiftsperMachine),
                    //new SqlParameter("IsMachineIdle",model.IsMachineIdle),
                    new SqlParameter("IsavingsNewMachineCost",model.IsavingsNewMachineCost),
                    new SqlParameter("IsPlantWeigtedWageBlank",model.IsPlantWeigtedWageBlank),
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId ?? (object)DBNull.Value),
                };

                var result = _repository.ExecuteSQL<ReplacementSavingsModel>("usp_stmp_ReplacementSavings_Get", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveReplacementSavings(List<ReplacementSavingsModel>  model,int loggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var replacementSavingDataXml = ConvertToXml<ReplacementSavingsModel>.GetXMLString(model);

                object[] paramList =
                {
                    new SqlParameter("ReplacementSavingsModelCollectionXML",replacementSavingDataXml),
                    new SqlParameter("LoggedInUserId",loggedInUserId)
                };

                var result = _repository.ExecuteSQL<int>("usp_stmp_ReplacementSavings_SaveReplacementSavings", paramList).FirstOrDefault();
                response.lng_InsertedId = result;
                response.Success = true;
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
