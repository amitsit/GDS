using System;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using System.Data.SqlClient;
using System.Data;
using GDS.Entities.SMOM.LinearityResults;

namespace GDS.Services.SMOM.LinearityResults
{
    class LinearityResultsService : ILinearityResultsService
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
        private readonly IGenericRepository<LinearityResultsModel> _repository;
        #endregion

        #region ctor
        public LinearityResultsService(IGenericRepository<LinearityResultsModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        public ApiResponse<LinearityResultsModel> GetLinearityResults(int plantId, int plantEquipmentListId, short lengthUnitId, long coverPageId)
        {
            var response = new ApiResponse<LinearityResultsModel>();
            try
            {
                var PlantId = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var PlantEquipmentListId = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = plantEquipmentListId
                };
                var LengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var CoverPageId = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = coverPageId
                };

                var result = _repository.ExecuteSQL<LinearityResultsModel>("usp_smom_LinearityResults_get", PlantId, PlantEquipmentListId,  CoverPageId, LengthUnitId).ToList();
               
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

        public BaseApiResponse UpdataMachineLinearityValidationStatusCode(long coverPageId, byte? validationStatusCode)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("CoverPageId",coverPageId),
                    new SqlParameter("ValidationStatusCode",validationStatusCode),
                };

                var result =
                    _repository.ExecuteSQL<int>(
                        "usp_smom_MachineLinearityPositionSetting_UpdataMachineLinearityValidationStatusCode", paramList)
                        .FirstOrDefault();

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
 