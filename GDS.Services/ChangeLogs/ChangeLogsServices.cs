﻿using GDS.Common;
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

                var result = _repository.ExecuteSQL<ChangeLogsModel>("GetChangeLogDetail", GuIdParam, UserIdParam).ToList();
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

       public BaseApiResponse SaveChangeLog(int? UserId, ChangeLogsModel ChangeLogObj)
        {
            var response = new BaseApiResponse();

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var GUIDParam = new SqlParameter
                {
                    ParameterName = "GUID",
                    DbType = DbType.String,
                    Value = (object)ChangeLogObj.GUID ?? DBNull.Value
                };


                var CodeParam = new SqlParameter
                {
                    ParameterName = "Code",
                    DbType = DbType.String,
                    Value = (object)ChangeLogObj.Code ?? DBNull.Value
                };

                var ProcessIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ChangeLogObj.ProcessId ?? DBNull.Value
                };

                var SubProcessIdParam = new SqlParameter
                {
                    ParameterName = "SubProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ChangeLogObj.SubProcessId ?? DBNull.Value
                };

                var DocumentIdParam = new SqlParameter
                {
                    ParameterName = "DocumentId",
                    DbType = DbType.Int32,
                    Value = (object)ChangeLogObj.DocumentId ?? DBNull.Value
                };

                var DescriptionParam = new SqlParameter
                {
                    ParameterName = "Description",
                    DbType = DbType.String,
                    Value = (object)ChangeLogObj.Description ?? DBNull.Value
                };

                var ActionParam = new SqlParameter
                {
                    ParameterName = "Action",
                    DbType = DbType.String,
                    Value = (object)ChangeLogObj.Action ?? DBNull.Value
                };

                var CreatedDateParam = new SqlParameter
                {
                    ParameterName = "CreatedDate",
                    DbType = DbType.DateTime,
                    Value = (object)ChangeLogObj.CreatedDate ?? DBNull.Value
                };

                var CreatedByParam = new SqlParameter
                {
                    ParameterName = "CreatedBy",
                    DbType = DbType.Int32,
                    Value = (object)ChangeLogObj.CreatedBy ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("AddOrUpdateChangeLog", UserIdParam, GUIDParam, CodeParam, ProcessIdParam, SubProcessIdParam, DocumentIdParam, DescriptionParam, ActionParam, CreatedDateParam, CreatedByParam).FirstOrDefault();
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
