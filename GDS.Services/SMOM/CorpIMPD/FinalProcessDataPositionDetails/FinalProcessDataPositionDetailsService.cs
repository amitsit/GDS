using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.IMIP;
using GDS.Entities.SMOM.CorpIMPD;
using GDS.Entities.SMOM.InitialDataConversionSetup;

namespace GDS.Services.SMOM.CorpIMPD.FinalProcessDataPositionDetails
{
    public class FinalProcessDataPositionDetailsService : IFinalProcessDataPositionDetailsService
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
        private readonly IGenericRepository<FinalProcessDataPositionDetailsModel> _repository;

        #endregion

        #region ctor


        public FinalProcessDataPositionDetailsService(IGenericRepository<FinalProcessDataPositionDetailsModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<FinalProcessDataPositionDetailsModel> GetFinalProcessDataPositionDetails(InitDataInputDataModel model)
        {
            var response = new ApiResponse<FinalProcessDataPositionDetailsModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",model.InitDataGeneralInfoId),
                    new SqlParameter("MoldFlowSetupHeaderId",model.MoldFlowSetupHeaderId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                };

                response.Data = _repository.ExecuteSQL<FinalProcessDataPositionDetailsModel>(
                    "usp_smom_FinalProcessDataPositionDetails_GetFinalProcessDataPositionDetails", paramList).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public BaseApiResponse SaveFinalProcessDataPositionDetails(long initDataGeneralInfoId, int loggedInUserId,int lengthUnitId, List<FinalProcessDataPositionDetailsModel> listFinalProcessDataPositionDetailsMode)
        {
            var response = new BaseApiResponse();

            try
            {
                var possitionDetailsXml = ConvertToXml<FinalProcessDataPositionDetailsModel>.GetXMLString(listFinalProcessDataPositionDetailsMode);

                object[] paramList =
                {
                    new SqlParameter("InitDataGeneralInfoId",initDataGeneralInfoId),
                    new SqlParameter("LoggedInUserId",loggedInUserId),
                    new SqlParameter("LengthUnitId", lengthUnitId),
                    new SqlParameter("PossitionDetailsXml",possitionDetailsXml),
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_FinalProcessDataPositionDetails_SaveFinalProcessDataPositionDetails", paramList).FirstOrDefault();
                response.Success = result > 0;
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
