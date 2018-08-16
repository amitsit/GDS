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

namespace GDS.Services.Master.Region
{
     public class RegionService : IRegionService
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
        private readonly IGenericRepository<RegionMasterModel> _repository;

        #endregion

        #region ctor


        public RegionService(IGenericRepository<RegionMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<RegionMasterModel> GetRegionList()
        {
            var response = new ApiResponse<RegionMasterModel>();

            try
            {
                var result = _repository.ExecuteSQL<RegionMasterModel>("usp_RegionMaster_get").ToList();
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


        public ApiResponse<RegionMasterModel> GetRegionDetail(int RegionID)
        {
            var response = new ApiResponse<RegionMasterModel>();
            List<RegionMasterModel> RegionModelList = new List<RegionMasterModel>();
            RegionMasterModel RegionModel = new RegionMasterModel();
            RegionModelList.Add(RegionModel);
            try
            {
                var regionIDParam = new SqlParameter
                {
                    ParameterName = "p_RegionID",
                    DbType = DbType.Int32,
                    Value = RegionID
                };

                var result = _repository.ExecuteSQL<RegionMasterModel>("usp_RegionMaster_get", regionIDParam).ToList();

                response.Success = true;
                if(RegionID == 0)
                    response.Data = RegionModelList;
                else
                    response.Data = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
            //try
            //{
            //    var regionIDParam = new SqlParameter
            //    {
            //        ParameterName = "p_RegionID",
            //        DbType = DbType.Int32,
            //        Value = RegionID
            //    };

            //    var result = _repository.ExecuteSQL<RegionMasterModel>("usp_RegionMaster_get", regionIDParam).ToList();
            //    response.Success = true;
            //    response.Data = result;
            //}
            //catch (Exception ex)
            //{
            //    _logger.Error(ex);
            //    response.Message.Add(ex.Message);
            //}

            //return response;
        }


        public BaseApiResponse AddOrUpdateRegion(int UserId, RegionMasterModel RegionObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var RegionIDParam = new SqlParameter
                {
                    ParameterName = "p_RegionID",
                    DbType = DbType.Int32,
                    Value = (object)RegionObj.RegionID
                };
                var UpdatedByParam = new SqlParameter
                {
                    ParameterName = "p_UpdatedBy",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var UpdatedDateParam = new SqlParameter
                {
                    ParameterName = "p_UpdatedDate",
                    DbType = DbType.DateTime,
                    Value = DateTime.Now
                };

                var RegionNameParam = new SqlParameter
                {
                    ParameterName = "p_RegionName",
                    DbType = DbType.String,
                    Value = (object)RegionObj.RegionName
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "p_IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)RegionObj.IsActive != null ? RegionObj.IsActive : (object)DBNull.Value
                };


                var result = 0;
                if (RegionObj.RegionID > 0)
                {
                    result = _repository.ExecuteSQL<int>("usp_RegionMaster_update", RegionNameParam, IsActiveParam,UpdatedByParam, UpdatedDateParam, RegionIDParam).FirstOrDefault();
                }
                else
                {
                    result = _repository.ExecuteSQL<int>("usp_RegionMaster_insert", RegionNameParam, IsActiveParam, UpdatedByParam, UpdatedDateParam, RegionIDParam).FirstOrDefault();
                }


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

        public BaseApiResponse DeleteRegion(long RegionID)
        {
            var response = new BaseApiResponse();

            try
            {
                var RegionIDParam = new SqlParameter
                {
                    ParameterName = "p_RegionID",
                    DbType = DbType.Int64,
                    Value = RegionID
                };

                var result = _repository.ExecuteSQL<int>("usp_RegionMaster_delete", RegionIDParam).FirstOrDefault();
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
