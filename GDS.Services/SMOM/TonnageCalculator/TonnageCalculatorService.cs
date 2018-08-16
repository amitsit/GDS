
namespace GDS.Services.SMOM.TonnageCalculator
{
    using Common;
    using Entities.Master;
    using GDS.Data.Repository;
    using GDS.Entities.SMOM.TonnageCalculator;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public  class TonnageCalculatorService: ITonnageCalculatorService
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
        private readonly IGenericRepository<TonnageCalculatorModel> _repository;
        #endregion

        #region ctor


        public TonnageCalculatorService(IGenericRepository<TonnageCalculatorModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<TonnageCalculatorModel> GetTonnageCalculatorDetails(long CoverPageId, Int16 lengthUnitId, Int16 pressureUnitId)
        {
            var response = new ApiResponse<TonnageCalculatorModel>();
            List<TonnageCalculatorModel> TonnageCalculatorList = new List<TonnageCalculatorModel>();
            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId ?? DBNull.Value
                };

                var lengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "lengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)lengthUnitId ?? DBNull.Value
                };

                var pressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "pressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)pressureUnitId ?? DBNull.Value
                };

                 TonnageCalculatorList = _repository.ExecuteSQL<TonnageCalculatorModel>("usp_smom_TonnageCalculator_get", CoverPageIdParam, lengthUnitIdParam, pressureUnitIdParam).ToList();
                if (TonnageCalculatorList.Count==0)
                {                  
                    TonnageCalculatorModel TonnageCalculatorObj = new TonnageCalculatorModel();
                    TonnageCalculatorObj.TonnageCalculatorCavityList = new List<TonnageCalculatorCavityModel>();
                    //Set Left and Right Cavity List
                    for(int i = 0; i < 2; i++)
                    {
                        TonnageCalculatorObj.TonnageCalculatorCavityList.Add(
                                                     new TonnageCalculatorCavityModel() { Left_OR_Right=(i==0)?"L":"R"}
                                        );
                    }

                    TonnageCalculatorList.Add(TonnageCalculatorObj);
                }
                else
                {
                    var TonnageCalculatorIdParam = new SqlParameter
                    {
                        ParameterName = "TonnageCalculatorId",
                        DbType = DbType.Int64,
                        Value = (object)TonnageCalculatorList[0].TonnageCalculatorId ?? DBNull.Value
                    };

                    var LengthUnitIdParam = new SqlParameter
                    {
                        ParameterName = "lengthUnitId",
                        DbType = DbType.Int16,
                        Value = (object)lengthUnitId ?? DBNull.Value
                    };

                    var PressureUnitIdParam = new SqlParameter
                    {
                        ParameterName = "pressureUnitId",
                        DbType = DbType.Int16,
                        Value = (object)pressureUnitId ?? DBNull.Value
                    };

                    TonnageCalculatorList[0].TonnageCalculatorCavityList = _repository.ExecuteSQL<TonnageCalculatorCavityModel>("usp_smom_TonnageCalculatorCavity_get", TonnageCalculatorIdParam, LengthUnitIdParam, PressureUnitIdParam).ToList();
                }

                response.Success = true;
                response.Data = TonnageCalculatorList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveTonnageCalculator(long CoverPageId, int UserId, Int16 LengthUnitId, Int16 PressureUnitId, TonnageCalculatorModel TonnageCalculatorObj)
        {
            var response = new BaseApiResponse();
           
            try
            {
                string TonnageCalculatorCavityListXml = GDS.Common.ConvertToXml<TonnageCalculatorCavityModel>.GetXMLString(TonnageCalculatorObj.TonnageCalculatorCavityList);

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? (object) DBNull.Value
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)LengthUnitId ?? (object)DBNull.Value
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)PressureUnitId ?? (object)DBNull.Value
                };

                var TonnageCalculatorIdParam = new SqlParameter
                {
                    ParameterName = "TonnageCalculatorId",
                    DbType = DbType.Int64,
                    Value = (object)TonnageCalculatorObj.TonnageCalculatorId ?? (object)DBNull.Value
                };

                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId ?? (object)DBNull.Value
                };

                var MaterialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = (object)TonnageCalculatorObj.MaterialTypeId ?? (object)DBNull.Value
                };

                var WallStockIdParam = new SqlParameter
                {
                    ParameterName = "WallStockId",
                    DbType = DbType.Int32,
                    Value = (object)TonnageCalculatorObj.WallStockId ?? (object)DBNull.Value
                };

                var ApproxRunnerSize_AVG_horizontalParam = new SqlParameter
                {
                    ParameterName = "ApproxRunnerSize_AVG_horizontal",
                    DbType = DbType.Double,
                    Value = (object)TonnageCalculatorObj.ApproxRunnerSize_AVG_horizontal ??(object) DBNull.Value
                };

                var ApproxRunnerSize_AVG_verticalParam = new SqlParameter
                {
                    ParameterName = "ApproxRunnerSize_AVG_vertical",
                    DbType = DbType.Double,
                    Value = (object)TonnageCalculatorObj.ApproxRunnerSize_AVG_vertical ?? (object) DBNull.Value
                };

                var NumberOfRunnersParam = new SqlParameter
                {
                    ParameterName = "NumberOfRunners",
                    DbType = DbType.Double,
                    Value = (object)TonnageCalculatorObj.NumberOfRunners ?? (object)DBNull.Value
                };

                var TonnageCalculatorCavityListXmlParam = new SqlParameter
                {
                    ParameterName = "TonnageCalculatorCavityListXml",
                    DbType = DbType.String,
                    Value = (object)TonnageCalculatorCavityListXml ?? (object)DBNull.Value
                };

                

             var result = _repository.ExecuteSQL<int>("usp_smom_SaveTonnageCalculator_insert_Update", UserIdParam, LengthUnitIdParam, PressureUnitIdParam, TonnageCalculatorIdParam, CoverPageIdParam
                                                                 , MaterialTypeIdParam, WallStockIdParam, ApproxRunnerSize_AVG_horizontalParam
                                                                , ApproxRunnerSize_AVG_verticalParam, NumberOfRunnersParam, TonnageCalculatorCavityListXmlParam).FirstOrDefault();

                response.InsertedId = result;
                response.Success = (result>0);                
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<WallStockRangeModel> GetWallStockRange(int WallstockTypeId,int MaterialTypeId)
        {
            var response = new ApiResponse<WallStockRangeModel>();

            try
            {
                var WallstockTypeIdParam = new SqlParameter
                {
                    ParameterName = "WallstockTypeId",
                    DbType = DbType.Int32,
                    Value = (object)WallstockTypeId
                };

                var MaterialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = (object)MaterialTypeId
                };

                var result = _repository.ExecuteSQL<WallStockRangeModel>("usp_WallStockRangeByMaterialTypeId_get", WallstockTypeIdParam, MaterialTypeIdParam).ToList();
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

        #endregion

    }
}
