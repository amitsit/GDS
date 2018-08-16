using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;

namespace GDS.Services.Master.WallStock
{
    public class WallStockService : IWallStockService
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
        private readonly IGenericRepository<WallStockModel> _repository;

        #endregion

        #region ctor


        public WallStockService(IGenericRepository<WallStockModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<WallStockModel> GetWallStock(int? wallStockId)
        {
            var response = new ApiResponse<WallStockModel>();

            try
            {
                var wallStockIdParam = new SqlParameter
                {
                    ParameterName = "WallStockId",
                    DbType = DbType.Int32,
                    Value = (object)wallStockId ?? DBNull.Value
                };

                response.Data = _repository.ExecuteSQL<WallStockModel>("usp_WallStockMaster_GetWallStock", wallStockIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveWallStock(WallStockModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters

                var wallStockIdParam = new SqlParameter
                {
                    ParameterName = "WallStockId",
                    DbType = DbType.Int32,
                    Value = model.WallStockId
                };

                var materialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = model.MaterialTypeId
                };
                 
                var wallStockCtPartRangeId = new SqlParameter
                {
                    ParameterName = "WallStockCTPartRangeId",
                    DbType = DbType.Int32,
                    Value = model.WallStockCTPartRangeId
                };

                //var toRange = new SqlParameter
                //{
                //    ParameterName = "ToRange",
                //    DbType = DbType.Decimal,
                //    Value = (object)model.ToRange ?? DBNull.Value
                //};

                var value = new SqlParameter
                {
                    ParameterName = "Value",
                    DbType = DbType.Decimal,
                    Value = model.Value
                };
                var loggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = model.LoggedInUserId
                };

                #endregion

                var result = _repository.ExecuteSQL<int>("usp_WallStockMaster_SaveWallStock"
                            , wallStockIdParam, materialTypeIdParam, wallStockCtPartRangeId,  value,loggedInUserIdParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteWallStock(int wallStockId)
        {
            var response = new BaseApiResponse();

            try
            {
                var wallStockIdParam = new SqlParameter
                {
                    ParameterName = "WallStockId",
                    DbType = DbType.Int32,
                    Value = wallStockId
                };

                var result = _repository.ExecuteSQL<int>("usp_WallStockMaster_DeleteWallStock", wallStockIdParam).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<MaterialTypeMasterModel> GetMaterialTypeList(int wallStockId)
        {
            var response = new ApiResponse<MaterialTypeMasterModel>();

            try
            {
                var wallStockIdParam = new SqlParameter
                {
                    ParameterName = "WallStockId",
                    DbType = DbType.Int32,
                    Value = wallStockId
                };

                var result = _repository.ExecuteSQL<MaterialTypeMasterModel>("usp_WallStockMaster_GetMaterialTypeList", wallStockIdParam).ToList();
                response.Success = true ;
                response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<WallStockCTPartRange> GetWallStockCTPartRangeList()
        {
            var response = new ApiResponse<WallStockCTPartRange>();

            try
            {
                var result = _repository.ExecuteSQL<WallStockCTPartRange>("usp_WallStockCTPartRange_get").ToList();
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