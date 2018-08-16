using System;
using System.Linq;
using GDS.Common;
using GDS.Entities.SMOM.CavityBalance;
using GDS.Data.Repository;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;

namespace GDS.Services.SMOM.CavityBalance
{
    public class CavityBalanceService : ICavityBalanceService
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
        private readonly IGenericRepository<CavityBalanceModel> _repository;
        #endregion

        #region ctor
        public CavityBalanceService(IGenericRepository<CavityBalanceModel> repository)
        {
            _repository = repository;
        }
        #endregion


        #region Methods
        public ApiResponse<CavityBalanceModel> GetCavitybalanceList(long coverPageId)
        {
            var response = new ApiResponse<CavityBalanceModel>();
            CavityBalanceModel cavityBalanceModel = new CavityBalanceModel();
            IList<CavityBalanceModel> list = new List<CavityBalanceModel>();
            try
            {
                var CoverPageId = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Double,
                    Value = coverPageId
                };
               
                var result = _repository.ExecuteSQL<CavityBalanceList>("usp_smom_CavityBalance", CoverPageId).ToList();

                cavityBalanceModel.CavityBalanceList = result;
                response.Success = true;
                list.Add(cavityBalanceModel);
                response.Data = list;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public BaseApiResponse SaveCavityBalanceDetail(CavityBalanceModel model, int CreatedBy)
        {
            
            var response = new BaseApiResponse();

            model.CavityBalanceList.RemoveAt(model.CavityBalanceList.Count - 1);
            model.CavityBalanceList.RemoveAt(model.CavityBalanceList.Count - 1);
            try
            {
                if (model.CavityBalanceList.Count > 20)
                    throw new Exception("Cannot add more than 20 entries.");

                var cavityBalanceDataXml = ConvertToXml<CavityBalanceList>.GetXMLString(model.CavityBalanceList);

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = model.CoverPageId
                };
                
                var waterFlowMiunteDataModelCollectionXmlParam = new SqlParameter
                {
                    ParameterName = "CavityBalanceDataModelCollectionXML",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(cavityBalanceDataXml) ? cavityBalanceDataXml : (object)DBNull.Value
                };

                var createdByParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = CreatedBy
                };


                var result = _repository.ExecuteSQL<long>("usp_smom_CavityBalance_Insert_Update", waterFlowMiunteDataModelCollectionXmlParam, coverPageIdParam, createdByParam).FirstOrDefault();
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
