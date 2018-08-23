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

namespace GDS.Services.Process
{
    public class ProcessService: IProcessService
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
        private readonly IGenericRepository<ProcessModel> _repository;

        #endregion



        #region ctor


        public ProcessService(IGenericRepository<ProcessModel> repository)
        {
            _repository = repository;
        }

        #endregion



        public ApiResponse<ProcessModel> GetProcesses(int? MenuId)
        {
            var response = new ApiResponse<ProcessModel>();

            try
            {
                var MenuIdParam = new SqlParameter
                {
                    ParameterName = "MenuId",
                    DbType = DbType.Int32,
                    Value = (object)MenuId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ProcessModel>("GetProcessByMenuId", MenuIdParam).ToList();
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

        public ApiResponse<SubProcessModel> GetSubProcesses(int? ProcessId)
        {
            var response = new ApiResponse<SubProcessModel>();

            try
            {
                var MenuIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProcessId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<SubProcessModel>("GetSubProcessesByProcessId", MenuIdParam).ToList();
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
        public ApiResponse<ProcessModel> GetProcessOrSubProcessListByProcessId(int? MenuId, int? ProcessId, int? UserId)
        {
            
            var response = new ApiResponse<ProcessModel>();

            try
            {
                var MenuIdParam = new SqlParameter
                {
                    ParameterName = "MenuId",
                    DbType = DbType.Int32,
                    Value = (object)MenuId ?? DBNull.Value
                };
                var ProcessIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProcessId ?? DBNull.Value
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ProcessModel>("GetProcessByProcessId", MenuIdParam, ProcessIdParam, UserIdParam).ToList();


                var Process_Id = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProcessId ?? DBNull.Value
                };
                var User_Id = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };


                var SubProcessList = _repository.ExecuteSQL<SubProcessModel>("GetSubProcessByProcessId", Process_Id, User_Id).ToList();

                if (result != null)
                {
                    result[0].SubProcessList = SubProcessList;
                }


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

       public BaseApiResponse SaveProcessDetail(int? UserId, ProcessModel ProceeObj)
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

                var MenuIdParam = new SqlParameter
                {
                    ParameterName = "MenuId",
                    DbType = DbType.Int32,
                    Value = (object)ProceeObj.MenuId?? DBNull.Value
                };
                var ProcessIdParam = new SqlParameter
                {
                    ParameterName = "ProcessId",
                    DbType = DbType.Int32,
                    Value = (object)ProceeObj.ProcessId ?? DBNull.Value
                };
                var ProcessNameParam = new SqlParameter
                {
                    ParameterName = "ProcessName",
                    DbType = DbType.String,
                    Value = (object)ProceeObj.ProcessName ?? DBNull.Value
                };
                var ProcessDescParam = new SqlParameter
                {
                    ParameterName = "ProcessDesc",
                    DbType = DbType.String,
                    Value = (object)ProceeObj.ProcessDesc ?? DBNull.Value
                };
               
                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)ProceeObj.IsActive != null ? ProceeObj.IsActive : (object)DBNull.Value
                };

                var DisplayOrderParam = new SqlParameter
                {
                    ParameterName = "DisplayOrder",
                    DbType = DbType.Int16,
                    Value = (Object)ProceeObj.DisplayOrder != null ? ProceeObj.DisplayOrder : (object)DBNull.Value
                };
                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "SelectedRegion",
                    DbType = DbType.String,
                    Value = (object)ProceeObj.SelectedRegion ?? DBNull.Value
                };
                


                var result = _repository.ExecuteSQL<int>("AddorUpdateProcessDetaile", UserIdParam, MenuIdParam, ProcessIdParam, ProcessNameParam, ProcessDescParam, IsActiveParam, DisplayOrderParam, RegionIdParam).FirstOrDefault();
                if (result > 0)
                {
                    response.Success = true;
                }

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
