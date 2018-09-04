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

namespace GDS.Services.ChangeLogs
{
    public class ChangeLogsServices : IChangeLogsServices
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
        private readonly IGenericRepository<ChangeLogsModel> _repository;
        #endregion

        #region ctor
        public ChangeLogsServices(IGenericRepository<ChangeLogsModel> repository)
        {
            _repository = repository;
        }
        #endregion

        public ApiResponse<ChangeLogsModel> GetChangeLogs(int? UserId)
        {
            var response = new ApiResponse<ChangeLogsModel>();

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                //var UserIdParam = new SqlParameter
                //{
                //    ParameterName = "UserId",
                //    DbType = DbType.Int32,
                //    Value = (object)UserId ?? DBNull.Value
                //};

                var result = _repository.ExecuteSQL<ChangeLogsModel>("GetChangeLog", UserIdParam).ToList();
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

        public ApiResponse<ChangeLogsModel> GetChangeLogsDetail(string GUID, int? UserId)
        {
            var response = new ApiResponse<ChangeLogsModel>();

            try
            {
                var GuIdParam = new SqlParameter
                {
                    ParameterName = "ContactId",
                    DbType = DbType.String,
                    Value = (object)GUID ?? DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ChangeLogsModel>("GetChangeLog", GuIdParam, UserIdParam).ToList();
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



        public BaseApiResponse DeleteChangeLog(string GUID, int? UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var GuIdParam = new SqlParameter
                {
                    ParameterName = "GUID",
                    DbType = DbType.String,
                    Value = (object)GUID ?? DBNull.Value
                };


                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };


                var result = _repository.ExecuteSQL<int>("DeleteChangeLog", GuIdParam, UserIdParam).FirstOrDefault();
                response.Success = (result > 0);

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
