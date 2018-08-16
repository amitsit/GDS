namespace GDS.Services.Master.State
{
    using Common;
    using Data.Repository;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    public class StateService : IStateService
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
        private readonly IGenericRepository<StateMasterModel> _repository;

        #endregion

        #region ctor


        public StateService(IGenericRepository<StateMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region methods
        public ApiResponse<StateMasterModel> GetStateList()
        {
            var response = new ApiResponse<StateMasterModel>();

            try
            {
                var StateIDParam = new SqlParameter
                {
                    ParameterName = "StateID",
                    DbType = DbType.String,
                    Value = String.Empty
                };
                var result = _repository.ExecuteSQL<StateMasterModel>("usp_mst_StateMaster_get", StateIDParam).ToList();
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
        public ApiResponse<StateMasterModel> GetStateDetail(int? stateid)
        {
            var response = new ApiResponse<StateMasterModel>();
            List<StateMasterModel> stateModelList = new List<StateMasterModel>();

            try
            {
                if (stateid == 0)
                {
                    StateMasterModel StateModel = new StateMasterModel();
                    stateModelList.Add(StateModel);
                }
                else
                {
                    var StateIDParam = new SqlParameter
                    {
                        ParameterName = "StateID",
                        DbType = DbType.Int32,
                        Value = (object)stateid ?? DBNull.Value
                    };
                    stateModelList = _repository.ExecuteSQL<StateMasterModel>("usp_mst_StateMaster_get", StateIDParam).ToList();
                }

                response.Success = true;
                response.Data = stateModelList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<CountryMasterModel> GetCountryList()
        {
            var response = new ApiResponse<CountryMasterModel>();

            try
            {
                var result = _repository.ExecuteSQL<CountryMasterModel>("usp_CountryMaster_get").ToList();
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
        public BaseApiResponse AddOrUpdateState(int userid, StateMasterModel StateObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var stateIDParam = new SqlParameter
                {
                    ParameterName = "StateID",
                    DbType = DbType.Int32,
                    Value = StateObj.StateID
                };
                var stateNameParam = new SqlParameter
                {
                    ParameterName = "StateName",
                    DbType = DbType.String,
                    Value = StateObj.StateName
                };
                var countryIDParam = new SqlParameter
                {
                    ParameterName = "CountryID",
                    DbType = DbType.Int32,
                    Value = StateObj.CountryID
                };
                var userIdParam = new SqlParameter
                {
                    ParameterName = "CreatedBy",
                    DbType = DbType.Int32,
                    Value = userid
                };
                var isActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)StateObj.IsActive != null ? StateObj.IsActive : (object)DBNull.Value
                };
                var result = 0;

                result = _repository.ExecuteSQL<int>("usp_mst_StateMaster_insert_update", stateIDParam, stateNameParam, countryIDParam, userIdParam, isActiveParam).FirstOrDefault();
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

        public BaseApiResponse DeleteState(int stateid)
        {
            var response = new BaseApiResponse();
            try
            {
                var stateIDParam = new SqlParameter
                {
                    ParameterName = "StateID",
                    DbType = DbType.Int32,
                    Value = stateid
                };
                var result = 0;

                result = _repository.ExecuteSQL<int>("usp_mst_StateMaster_delete", stateIDParam).FirstOrDefault();
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
