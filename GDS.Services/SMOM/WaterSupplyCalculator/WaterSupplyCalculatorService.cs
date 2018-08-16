using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.WaterSupplyCalculator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.WaterSupplyCalculator
{
    public class WaterSupplyCalculatorService : IWaterSupplyCalculatorService
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
        private readonly IGenericRepository<WaterSupplyCalculatorModel> _repository;

        #endregion

        #region ctor


        public WaterSupplyCalculatorService(IGenericRepository<WaterSupplyCalculatorModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<WaterSupplyCalculatorModel> GetWaterSupplyDetail(long CoverPageId, int UserId, int lengthUnitId, int pressureUnitId)
        {
            var response = new ApiResponse<WaterSupplyCalculatorModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = CoverPageId
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int32,
                    Value = lengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int32,
                    Value = pressureUnitId
                };

                var result = _repository.ExecuteSQL<WaterSupplyCalculatorModel>("usp_smom_WaterFlowCalculator_get", CoverPageIdParam, UserIdParam, PressureUnitIdParam, LengthUnitIdParam).ToList();
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


        public BaseApiResponse UpdateWaterSupplyDetail(int lengthUnitId, int pressureUnitId, WaterSupplyCalculatorModel CalculatorModel)
        {
            var response = new BaseApiResponse();
            try
            {
                var WaterSupplyIdParam = new SqlParameter
                {
                    ParameterName = "WaterSupplyCalculatorId",
                    DbType = DbType.Int64,
                    Value = (object)CalculatorModel.WaterSupplyCalculatorId ?? DBNull.Value
                };
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CalculatorModel.CoverPageId ?? DBNull.Value
                };

                var SupplyLineParam = new SqlParameter
                {
                    ParameterName = "SupplyLine",
                    DbType = DbType.Double,
                    Value = (object)CalculatorModel.SupplyLine ?? DBNull.Value
                };

                var ToolFittingParam = new SqlParameter
                {
                    ParameterName = "ToolFitting",
                    DbType = DbType.Double,
                    Value = (object)CalculatorModel.ToolFitting ?? DBNull.Value
                };

                var CircuitsPerThermolatorParam = new SqlParameter
                {
                    ParameterName = "CircuitsPerThermolator",
                    DbType = DbType.Double,
                    Value = (object)CalculatorModel.CircuitsPerThermolator ?? DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)CalculatorModel.UserId ?? DBNull.Value
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int32,
                    Value = lengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int32,
                    Value = pressureUnitId
                };

                var validationStatusCodeParam = new SqlParameter
                {
                    ParameterName = "ValidationStatusCode",
                    DbType = DbType.Int16,
                    Value = (object)CalculatorModel.ValidationStatusCode ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<long>("usp_smom_WaterSupplyCalculator_InsertUpdate", WaterSupplyIdParam, CoverPageIdParam, SupplyLineParam, ToolFittingParam, CircuitsPerThermolatorParam, UserIdParam, PressureUnitIdParam, LengthUnitIdParam, validationStatusCodeParam).FirstOrDefault();
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
