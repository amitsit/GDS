using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.Master.BICCycleKeyElement
{
    public class BICCycleKeyElementService : IBICCycleKeyElementService
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
        private readonly IGenericRepository<BICCycleKeyElementModel> _repository;

        #endregion

        #region ctor

        public BICCycleKeyElementService(IGenericRepository<BICCycleKeyElementModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementList()
        {
            var response = new ApiResponse<BICCycleKeyElementModel>();

            try
            {
                var result = _repository.ExecuteSQL<BICCycleKeyElementModel>("usp_MST_BICCycleKeyElement_get").ToList();
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

        public ApiResponse<BICCycleKeyElementModel> GetBICCycleKeyElementDetail(int BICCycleKeyElementID)
        {
            var response = new ApiResponse<BICCycleKeyElementModel>();

            try
            {
                var iACCycleGoalIdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyEmementID",
                    DbType = DbType.Int64,
                    Value = BICCycleKeyElementID
                };

                var result = _repository.ExecuteSQL<BICCycleKeyElementModel>("usp_MST_BICCycleKeyElement_getDetailById", iACCycleGoalIdParam).ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseApiResponse AddOrUpdateBICCycleKeyElement(int UserId, BICCycleKeyElementModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var BICCycleKeyElementIdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyEmementID",
                    DbType = DbType.Int64,
                    Value = (object)model.BICCycleKeyElementID
                };

                //var PlantIdParam = new SqlParameter
                //{
                //    ParameterName = "PlantId",
                //    DbType = DbType.Int32,
                //    Value = (object)model.PlantId ?? DBNull.Value
                //};

                var PlantMonthYearIdParam = new SqlParameter
                {
                    ParameterName = "PlantMonthYearId",
                    DbType = DbType.Int64,
                    Value = (object)model.PlantMonthYearId ?? DBNull.Value
                };

                var ElementNameParam = new SqlParameter
                {
                    ParameterName = "ElementName",
                    DbType = DbType.String,
                    Value = (object)model.ElementName
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)model.IsActive ?? DBNull.Value
                };
                var SortOrderParam = new SqlParameter
                {
                    ParameterName = "SortOrder",
                    DbType = DbType.Int64,
                    Value = (object)model.SortOrder ?? DBNull.Value
                };


                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_MST_BICCycleKeyElement_insert_update", BICCycleKeyElementIdParam //, PlantIdParam
                                                        , PlantMonthYearIdParam,ElementNameParam,IsActiveParam, SortOrderParam, UserIdParam).FirstOrDefault();
               


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

        public BaseApiResponse DeleteBICCycleKeyElement(int BICCycleKeyElementID)
        {
            var response = new BaseApiResponse();

            try
            {
                var BICCycleKeyEmementIdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyElementID",
                    DbType = DbType.Int64,
                    Value = BICCycleKeyElementID
                };

                var result = _repository.ExecuteSQL<int>("usp_MST_BICCycleKeyElement_delete", BICCycleKeyEmementIdParam).FirstOrDefault();
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

        public ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardList()
        {
            var response = new ApiResponse<BICCycleKeyElementStandardModel>();

            try
            {
                var result = _repository.ExecuteSQL<BICCycleKeyElementStandardModel>("usp_MST_BICCycleKeyElementStandard_get").ToList();
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

        public ApiResponse<BICCycleKeyElementStandardModel> GetBICCycleKeyElementStandardDetail(int BICCycleKeyElementStandardID)
        {
            var response = new ApiResponse<BICCycleKeyElementStandardModel>();
            try
            {
                var bICCycleKeyElementStdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyElementStandardID",
                    DbType = DbType.Int64,
                    Value = BICCycleKeyElementStandardID
                };

                var result = _repository.ExecuteSQL<BICCycleKeyElementStandardModel>("usp_mst_BICCycleKeyElementStandard_getDetailById", bICCycleKeyElementStdParam).ToList();
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

        public BaseApiResponse AddOrUpdateBICCycleKeyElementStandard(int UserId, BICCycleKeyElementStandardModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var bICCycleKeyElementStdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyElementStandardID",
                    DbType = DbType.Int64,
                    Value = model.BICCycleKeyElementStandardID
                };

                var bICCycleKeyElementIdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyEmementID",
                    DbType = DbType.Int32,
                    Value = model.BICCycleKeyElementID
                };

                //var tonnageFromParam = new SqlParameter
                //{
                //    ParameterName = "TonnageFrom",
                //    DbType = DbType.Int32,
                //    Value = model.TonnageFrom
                //};

                //var tonnageToParam = new SqlParameter
                //{
                //    ParameterName = "TonnageTo",
                //    DbType = DbType.Int32,
                //    Value = model.TonnageTo
                //};

                var tonnageRangeIdParam = new SqlParameter
                {
                    ParameterName = "TonnageRangeId",
                    DbType = DbType.Int32,
                    Value = model.TonnageRangeId
                };

                var wcParam = new SqlParameter
                {
                    ParameterName = "WC",
                    DbType = DbType.Double,
                    Value = (object)model.WC ?? DBNull.Value 
                };

                var valueParam = new SqlParameter
                {
                    ParameterName = "Value",
                    DbType = DbType.Decimal,
                    Value = model.Value
                };

                var isActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = model.IsActive
                };

                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_mst_BICCycleKeyElementStandard_insert_update", bICCycleKeyElementStdParam, bICCycleKeyElementIdParam
                                                        //, tonnageFromParam, tonnageToParam
                                                        ,tonnageRangeIdParam
                                                        , wcParam, valueParam, isActiveParam, userIdParam).FirstOrDefault();



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

        public BaseApiResponse DeleteBICCycleKeyElementStandard(int BICCycleKeyElementStandardID)
        {
            var response = new BaseApiResponse();

            try
            {
                var bICCycleKeyElementStdParam = new SqlParameter
                {
                    ParameterName = "BICCycleKeyElementStandardID",
                    DbType = DbType.Int64,
                    Value = BICCycleKeyElementStandardID
                };

                var result = _repository.ExecuteSQL<int>("usp_mst_BICCycleKeyElementStandard_delete", bICCycleKeyElementStdParam).FirstOrDefault();
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

        #endregion
    }
}
