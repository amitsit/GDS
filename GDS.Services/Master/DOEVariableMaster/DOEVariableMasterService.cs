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

namespace GDS.Services.Master.DOEVariableMaster
{
    public class DOEVariableMasterService : IDOEVariableMasterService
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
        private readonly IGenericRepository<DOEVariableMasterModel> _repository;

        #endregion

        #region ctor


        public DOEVariableMasterService(IGenericRepository<DOEVariableMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        //Type DropDown
        public ApiResponse<DOEVariableMasterModel> GetDOEVariableType()
        {
            var response = new ApiResponse<DOEVariableMasterModel>();
            try
            {

                var result = _repository.ExecuteSQL<DOEVariableMasterModel>("usp_DOEVariableMaster_GetType").ToList();

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


        public ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterById(int VariableId)
        {
            var response = new ApiResponse<DOEVariableMasterModel>();
            IList<DOEVariableMasterModel> list = new List<DOEVariableMasterModel>();
            try
            {
                var variableIdParam = new SqlParameter
                {
                    ParameterName = "VariableId",
                    DbType = DbType.Int32,
                    Value =(object)VariableId
                };
                var result = _repository.ExecuteSQL<DOEVariableMasterModel>("usp_DOEVariableMaster_GetById", variableIdParam).ToList();
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

        //Datatable List
        public ApiResponse<DOEVariableMasterModel> GetDOEVariableMasterList()
        {
            var response = new ApiResponse<DOEVariableMasterModel>();
            IList<DOEVariableMasterModel> list = new List<DOEVariableMasterModel>();
            try
            {
                var result = _repository.ExecuteSQL<DOEVariableMasterModel>("usp_DOEVariableMaster_List").ToList();
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

        //SaveVariablemaster
        public BaseApiResponse SaveDOEVariableMaster(DOEVariableMasterModel dOEVariableModel)
        {

            var response = new BaseApiResponse();
            try
            {
                var variableIdParam = new SqlParameter
                {
                    ParameterName = "VariableId",
                    DbType = DbType.Int32,
                    Value = dOEVariableModel.VariableId
                };
                var variableNameParam = new SqlParameter
                {
                    ParameterName = "VariableName",
                    DbType = DbType.String,
                    Value = dOEVariableModel.VariableName
                };

                var typeParam = new SqlParameter
                {
                    ParameterName = "Type",
                    DbType = DbType.String,
                    Value = dOEVariableModel.Type
                };

                var createdbyParam = new SqlParameter
                {
                    ParameterName = "CreatedBy",
                    DbType = DbType.Int16,
                    Value = dOEVariableModel.LoggedInUserId
                };

                var isActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = dOEVariableModel.IsActive
                };

                


                var result = _repository.ExecuteSQL<int>("usp_DOE_VariableMaster_InsertUpdate",
                                variableIdParam, variableNameParam, typeParam, createdbyParam, isActiveParam).FirstOrDefault();

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
