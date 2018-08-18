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
    }
}
