using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.IMIP;
using GDS.Entities.SMOM.CheckRingStudyWeight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CheckRingStudyWeight
{
    public class CheckRingStudyWeightService : ICheckRingStudyWeightService
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
        private readonly IGenericRepository<CheckRingStudyWeightModel> _repository;

        #endregion

        #region ctor

        public CheckRingStudyWeightService(IGenericRepository<CheckRingStudyWeightModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<CheckRingStudyWeightModel> GetCheckRingStudyWeightList(long coverPageId)
        {
            var response = new ApiResponse<CheckRingStudyWeightModel>();

            try
            {
                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = coverPageId
                };
             
                var result = _repository.ExecuteSQL<CheckRingStudyWeightModel>("usp_smom_CheckRingStudyWeight_get"
                    , coverPageIdParam).ToList();
                
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

        public BaseApiResponse UpdateCheckRingStudyWeight(int userid, long? checkringstudyid, double? amountOfDeCompress,long CoverPageId,byte? validationStatusCode, List<CheckRingStudyWeightModel> checkRingStudyWeightList)
        {
            var response = new BaseApiResponse();
            try
            {
                string getxmlstr = ConvertToXml<CheckRingStudyWeightModel>.GetXMLString(checkRingStudyWeightList);

                var checkRingStudyWeightListXML = new SqlParameter
                {
                    ParameterName = "checkRingStudyWeightList",
                    DbType = DbType.String,
                    Value = getxmlstr
                };

                var useridParam = new SqlParameter
                {
                    ParameterName = "LoginUserId",
                    DbType = DbType.Int32,
                    Value = userid
                };
                var checkringstudyidParam = new SqlParameter
                {
                    ParameterName = "CheckRingStudyId",
                    DbType = DbType.Int64,
                    Value = (object)checkringstudyid ?? DBNull.Value
                };
                var amountOfDeCompressParam = new SqlParameter
                {
                    ParameterName = "AmountOfDeCompress",
                    DbType = DbType.Double,
                    Value = (object)amountOfDeCompress ?? DBNull.Value
                };
                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = CoverPageId
                };


                var validationStatusCodeParam = new SqlParameter("ValidationStatusCode", (object)validationStatusCode?? DBNull.Value);

                var result = _repository.ExecuteSQL<long>("usp_smom_CheckRingStudyWeight_insert_update",
                     checkRingStudyWeightListXML, useridParam, checkringstudyidParam, amountOfDeCompressParam, coverPageIdParam, validationStatusCodeParam).FirstOrDefault();

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
