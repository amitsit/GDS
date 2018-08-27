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

        public ApiResponse<SubProcessModel> GetSubProcessListByStatus(int? ProcessId, int? RegionId, int? UserId, bool? IsActive)
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

                var result = _repository.ExecuteSQL<SubProcessModel>("GetSubProcessListByStatus", ProcessIdParam, RegionIdParam, UserIdParam, IsActiveParam).ToList();
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

    }
}
