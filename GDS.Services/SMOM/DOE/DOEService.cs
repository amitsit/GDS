using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.DOE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.DOE
{
    public class DOEService : IDOEService
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
        private readonly IGenericRepository<DOEModel> _repository;
        #endregion

        #region ctor
        public DOEService(IGenericRepository<DOEModel> repository)
        {
            _repository = repository;
        }
        #endregion


        #region Methods

        public ApiResponse<DOEVariableList> DOEVariableList()
        {
            var response = new ApiResponse<DOEVariableList>();
            DOEVariableList DOEModel = new DOEVariableList();
           
            try
            {
                
                var result = _repository.ExecuteSQL<DOEVariableList>("usp_GetDOEVariableList").ToList();
                
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


        public ApiResponse<DOEModel> GetDOEList(long coverPageId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<DOEModel>();
            DOEModel DOEModel = new DOEModel();
            IList<DOEModel> list = new List<DOEModel>();
            try
            {
                var CoverPageId = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Double,
                    Value = coverPageId
                };

                var LengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };

                var PressureUnitId = new SqlParameter
                {
                    ParameterName = "pressureUnitId",
                    DbType = DbType.Int16,
                    Value = pressureUnitId
                };


                var result = _repository.ExecuteSQL<DOEList>("usp_DOE_get", CoverPageId, LengthUnitId, PressureUnitId).ToList();
                DOEModel.DOEList = result;
                response.Success = true;
                list.Add(DOEModel);
                response.Data = list;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public BaseApiResponse SaveDOEModelList(DOEModel model)
        {

            var response = new BaseApiResponse();
            
            try
            {
                
                var DOEDataXml = ConvertToXml<DOEList>.GetXMLString(model.DOEList);

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = model.CoverPageId
                };

                var DOEDataModelCollectionXMLParam = new SqlParameter
                {
                    ParameterName = "DOEDataModelCollectionXML",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(DOEDataXml) ? DOEDataXml : (object)DBNull.Value
                };

                var createdByParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = model.LoggedInUserId
                };

                var Variable1Param = new SqlParameter
                {
                    ParameterName = "Variable1",
                    DbType = DbType.Int32,
                    Value = model.Variable1
                };

                var Variable2Param = new SqlParameter
                {
                    ParameterName = "Variable2",
                    DbType = DbType.Int32,
                    Value = model.Variable2
                };

                var Variable3Param = new SqlParameter
                {
                    ParameterName = "Variable3",
                    DbType = DbType.Int32,
                    Value = model.Variable3
                };

                var Variable4Param = new SqlParameter
                {
                    ParameterName = "Variable4",
                    DbType = DbType.Int32,
                    Value = model.Variable4
                };


                var result = _repository.ExecuteSQL<long>("usp_DOE_InsertUpdate", DOEDataModelCollectionXMLParam, coverPageIdParam, createdByParam,Variable1Param,Variable2Param,Variable3Param,Variable4Param).FirstOrDefault();
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
