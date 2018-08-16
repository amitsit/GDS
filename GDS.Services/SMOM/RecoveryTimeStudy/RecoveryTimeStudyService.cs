using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.RecoveryTimeStudy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.RecoveryTimeStudy
{
    public class RecoveryTimeStudyService : IRecoveryTimeStudyService
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
        private readonly IGenericRepository<RecoveryTimeStudyModel> _repository;
        #endregion

        #region ctor
        public RecoveryTimeStudyService(IGenericRepository<RecoveryTimeStudyModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<RecoveryTimeStudyModel> GetRecoveryTimeStudy(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId)
        {
            var response = new ApiResponse<RecoveryTimeStudyModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("CoverPageId",(object)CoverPageId?? DBNull.Value),
                    new SqlParameter("PressureUnitId",(object)PressureUnitId?? DBNull.Value),
                    new SqlParameter("LengthUnitId",(object)LengthUnitId?? DBNull.Value)
                                      
                };

                var result = _repository.ExecuteSQL<RecoveryTimeStudyModel>(
                                "usp_smom_RecoveryTimeStudy_get", paramList).ToList();

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

        public BaseApiResponse InsertUpdateRecoveryTimeStudy(Int16 PressureUnitId, Int16 LengthUnitId, RecoveryTimeStudyModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                 {
                    new SqlParameter("RecoveryTimeStudyId",model.RecoveryTimeStudyId)
                   ,new SqlParameter("CoverPageId",model.CoverPageId)
                   ,new SqlParameter("ShotSize",(object)model.ShotSize?? DBNull.Value)
                   ,new SqlParameter("ScrewRPM",(object)model.ScrewRPM?? DBNull.Value)
                   ,new SqlParameter("BackPressure",(object)model.BackPressure?? DBNull.Value)
                   ,new SqlParameter("ScrewRecoveryTime",(object)model.ScrewRecoveryTime?? DBNull.Value)
                   ,new SqlParameter("LoggedInUserId",model.LoggedInUserId)
                   ,new SqlParameter("PressureUnitId",PressureUnitId)
                   ,new SqlParameter("LengthUnitId",LengthUnitId)
                   ,new SqlParameter("ValidationStatusCode",model.ValidationStatusCode)
                };

                var result = _repository.ExecuteSQL<long>("usp_smom_RecoveryTimeStudy_save", paramList).FirstOrDefault();
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

        public ApiResponse<RecoveryTimeStudyModel> GetRecoveryAdditinalParameters(long CoverPageId, Int16 PressureUnitId, Int16 LengthUnitId)
        {
            var response = new ApiResponse<RecoveryTimeStudyModel>();
            RecoveryTimeStudyModel AdditionalModel = new RecoveryTimeStudyModel();
            IList<RecoveryTimeStudyModel> list = new List<RecoveryTimeStudyModel>();
            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId
                };
                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = LengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = PressureUnitId
                };



                var result = _repository.ExecuteSQL<RecoveryAdditionalParaList>("usp_SMOM_ScrewRecovery_AdditionalParameters_Get", CoverPageIdParam, LengthUnitIdParam, PressureUnitIdParam).ToList();
                AdditionalModel.AdditinalPrametersList = result;
                response.Success = true;
                list.Add(AdditionalModel);
                response.Data = list;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveRecoveryAdditinalParametersList(RecoveryTimeStudyModel model)
        {

            var response = new BaseApiResponse();

            try
            {

                string getxmlstr = ConvertToXml<RecoveryAdditionalParaList>.GetXMLString(model.AdditinalPrametersList);


                var RecoveryAdditionalModelCollectionXMLParam = new SqlParameter
                {
                    ParameterName = "RecoveryAdditionalModelCollectionXML",
                    DbType = DbType.String,
                    Value = getxmlstr
                };

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = model.CoverPageId
                };

                var createdByParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = model.LoggedInUserId
                };


                var result = _repository.ExecuteSQL<long>("usp_SMOM_ScrewRecovery_AdditionalParameters_InsertUpdate", RecoveryAdditionalModelCollectionXMLParam, coverPageIdParam, createdByParam).FirstOrDefault();
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
