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

namespace GDS.Services.SubProcess
{
   public class SubProcessService: ISubProcessService
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
        private readonly IGenericRepository<SubProcessModel> _repository;
        #endregion

        #region ctor
        public SubProcessService(IGenericRepository<SubProcessModel> repository)
        {
            _repository = repository;
        }
        #endregion

        public ApiResponse<SubProcessModel> GetSubProcess(int? ProcessId, int? SubProcessId, int? RegionId, int? UserId)
        {
            var response = new ApiResponse<SubProcessModel>();

            try
            {
                var ProcessIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProcessId ?? DBNull.Value
                };
                var SubProcessIdParam = new SqlParameter
                {
                    ParameterName = "SubProcessId",
                    DbType = DbType.Int32,
                    Value = (object)SubProcessId ?? DBNull.Value
                };

                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)RegionId ?? DBNull.Value
                };
                
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<SubProcessModel>("GetSubProcess", ProcessIdParam, SubProcessIdParam, RegionIdParam, UserIdParam).ToList();
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

        public ApiResponse<SubProcessModel> GetSubProcessListByStatus(int? ProcessId, int? SubProcessId, int? RegionId, int? UserId, bool? IsActive)
        {
            var response = new ApiResponse<SubProcessModel>();

            try
            {
                var ProcessIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProcessId ?? DBNull.Value
                };
                var SubProcessIdParam = new SqlParameter
                {
                    ParameterName = "SubProcessId",
                    DbType = DbType.Int32,
                    Value = (object)SubProcessId ?? DBNull.Value
                };

                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)RegionId ?? DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)IsActive ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<SubProcessModel>("GetSubProcess", ProcessIdParam, SubProcessIdParam, RegionIdParam, UserIdParam, IsActiveParam).ToList();
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

        public ApiResponse<ProcessDocument> GetProcessDocumentBySubProcessIdAndRegionId(int? SubProcessId, int? RegionId, int? UserId)
        {
            var response = new ApiResponse<ProcessDocument>();

            try
            {
                var SubProcessIdParam = new SqlParameter
                {
                    ParameterName = "SubProcessId",
                    DbType = DbType.Int32,
                    Value = (object)SubProcessId ?? DBNull.Value
                };
                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)RegionId ?? DBNull.Value
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ProcessDocument>("GetProcessDocumentBySubProcessIdAndRegionId", SubProcessIdParam, RegionIdParam, UserIdParam).ToList();
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


        public BaseApiResponse DeleteSubProcessFromRegion(int SubProcessId, int RegionId, int UserId)
        {

          var response = new BaseApiResponse();

            try
            {
                var SubProcessIdParam = new SqlParameter
                {
                    ParameterName = "SubProcessId",
                    DbType = DbType.Int32,
                    Value = (object)SubProcessId ?? DBNull.Value
                };
                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)RegionId ?? DBNull.Value
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("DeleteSubProcessFromRegion", SubProcessIdParam, RegionIdParam, UserIdParam).FirstOrDefault();
                response.Success = (result>0);
  
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;

       }

        public ApiResponse<SubProcessModel> SaveSubProcessDetail(int UserId, SubProcessModel SubProcessObj)
        {
            var response = new ApiResponse<SubProcessModel>();

            try
            {
               object[] paramList =
               {
                    new SqlParameter("SubProcessId",(object)SubProcessObj.SubProcessId ??(object)DBNull.Value)
                  , new SqlParameter("ProcessId",(object)SubProcessObj.ProcessId??(object)DBNull.Value)
                  , new SqlParameter("GlobalSubProcessId",(object)SubProcessObj.GlobalSubProcessId??(object)DBNull.Value)
                  , new SqlParameter("SubProcessCode",(object)SubProcessObj.SubProcessCode??(object)DBNull.Value)
                  , new SqlParameter("SubProcessName",(object)SubProcessObj.SubProcessName??(object)DBNull.Value)
                  , new SqlParameter("SubProcessModelPath",(object)SubProcessObj.SubProcessModelPath??(object)DBNull.Value)
                  , new SqlParameter("SubProcessDescription",(object)SubProcessObj.SubProcessDescription??(object)DBNull.Value)
                  , new SqlParameter("SubProcessOwner",(object)SubProcessObj.SubProcessOwner??(object)DBNull.Value)
                  , new SqlParameter("SubProcessInput",(object)SubProcessObj.SubProcessInput??(object)DBNull.Value)
                  , new SqlParameter("FundamentalOfProcess",(object)SubProcessObj.FundamentalOfProcess??(object)DBNull.Value)
                  , new SqlParameter("SubProcessOutput",(object)SubProcessObj.SubProcessOutput??(object)DBNull.Value)
                  , new SqlParameter("RegionId",(object)SubProcessObj.RegionId??(object)DBNull.Value)
                  , new SqlParameter("IsActive",(object)SubProcessObj.IsActive??(object)DBNull.Value)
                  , new SqlParameter("DisplayOrder",(object)SubProcessObj.DisplayOrder??(object)DBNull.Value)
                  , new SqlParameter("UserId",(object)UserId??(object)DBNull.Value)
                };

                var result = _repository.ExecuteSQL<SubProcessModel>("AddOrUpdateSubProcessDetail", paramList).ToList();
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
    }
}
