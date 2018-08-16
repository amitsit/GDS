using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.STMP.CustomerRequirement;
using GDS.Entities.STMP.InputData;
using GDS.Services.STMP.InputData;

namespace GDS.Services.STMP.CustomerRequirement
{
    public class CustomerRequirementService : ICustomerRequirementService
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
        private readonly IGenericRepository<CustomerRequirementModel> _repository;

        #endregion

        #region ctor


        public CustomerRequirementService(IGenericRepository<CustomerRequirementModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<CustomerRequirementModel> GetCustomerRequirement(int? loggedInUserId, int plantId, int? plantMonthYearId, string SearchValue)
        {
            var response = new ApiResponse<CustomerRequirementModel>();

            try
            {
                var loggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int64,
                    Value = (object)loggedInUserId ?? DBNull.Value
                };

                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int64,
                    Value = plantId
                };

                var plantMonthYearIdParam = new SqlParameter
                {
                    ParameterName = "PlantMonthYearId",
                    DbType = DbType.Int64,
                    Value = (object)plantMonthYearId ?? DBNull.Value
                };

                var searchValueParam = new SqlParameter
                {
                    ParameterName = "SearchValue",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(SearchValue) ? SearchValue : (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<CustomerRequirementModel>("usp_stmp_CustomerRequirement_GetCustomerRequirement",
                                loggedInUserIdParam, plantIdParam, plantMonthYearIdParam, searchValueParam).ToList();
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

        public ApiResponse<DatesList> Get7DayDatesIntervalForAYear(DateTime startDate)
        {
            var response = new ApiResponse<DatesList>();

            try
            {
                var startDateParam = new SqlParameter
                {
                    ParameterName = "StartDate",
                    DbType = DbType.DateTime,
                    Value = startDate
                };


                var result = _repository.ExecuteSQL<DatesList>("usp__utility_Get7DayDatesIntervalForAYear", startDateParam).ToList();
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

        public BaseApiResponse UpdateCustomerRequirementList(CustomerRequirementModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var CustomerRequirementIdParam = new SqlParameter
                {
                    ParameterName = "CustomerRequirementId",
                    DbType = DbType.Int64,
                    Value = (object)model.CustomerRequirementId
                };
                         
                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)model.PlantId ?? DBNull.Value
                };

                var MoldToolIdParam = new SqlParameter
                {
                    ParameterName = "MoldToolId",
                    DbType = DbType.String,
                    Value = (object)model.MoldToolId ?? DBNull.Value
                };

                var ProgramIdParam = new SqlParameter
                {
                    ParameterName = "ProgramId",
                    DbType = DbType.String,
                    Value = (object)model.ProgramId ?? DBNull.Value
                };

                var TakeParam = new SqlParameter
                {
                    ParameterName = "Take",
                    DbType = DbType.Double,
                    Value = (object)model.Take ?? DBNull.Value
                };

                var Week1Param = new SqlParameter
                {
                    ParameterName = "Week1",
                    DbType = DbType.Int32,
                    Value = (object)model.Week1 ?? DBNull.Value
                };

                var Week2Param = new SqlParameter
                {
                    ParameterName = "Week2",
                    DbType = DbType.Int32,
                    Value = (object)model.Week2 ?? DBNull.Value
                };
                var Week3Param = new SqlParameter
                {
                    ParameterName = "Week3",
                    DbType = DbType.Int32,
                    Value = (object)model.Week3 ?? DBNull.Value
                };
                var Week4Param = new SqlParameter
                {
                    ParameterName = "Week4",
                    DbType = DbType.Int32,
                    Value = (object)model.Week4 ?? DBNull.Value
                };
                var Week5Param = new SqlParameter
                {
                    ParameterName = "Week5",
                    DbType = DbType.Int32,
                    Value = (object)model.Week5 ?? DBNull.Value
                };
                var Week6Param = new SqlParameter
                {
                    ParameterName = "Week6",
                    DbType = DbType.Int32,
                    Value = (object)model.Week6 ?? DBNull.Value
                };
                var Week7Param = new SqlParameter
                {
                    ParameterName = "Week7",
                    DbType = DbType.Int32,
                    Value = (object)model.Week7 ?? DBNull.Value
                };
                var Week8Param = new SqlParameter
                {
                    ParameterName = "Week8",
                    DbType = DbType.Int32,
                    Value = (object)model.Week8 ?? DBNull.Value
                };
                var Week9Param = new SqlParameter
                {
                    ParameterName = "Week9",
                    DbType = DbType.Int32,
                    Value = (object)model.Week9 ?? DBNull.Value
                };
                var Week10Param = new SqlParameter
                {
                    ParameterName = "Week10",
                    DbType = DbType.Int32,
                    Value = (object)model.Week10 ?? DBNull.Value
                };
                var Week11Param = new SqlParameter
                {
                    ParameterName = "Week11",
                    DbType = DbType.Int32,
                    Value = (object)model.Week11 ?? DBNull.Value
                };
                var Week12Param = new SqlParameter
                {
                    ParameterName = "Week12",
                    DbType = DbType.Int32,
                    Value = (object)model.Week12 ?? DBNull.Value
                };


                var result = _repository.ExecuteSQL<long>("usp_CustomerRequirementList_Update", CustomerRequirementIdParam, PlantIdParam, MoldToolIdParam, ProgramIdParam, TakeParam, Week1Param, Week2Param, Week3Param, Week4Param, Week5Param, Week6Param,
                                                                                         Week7Param, Week8Param, Week9Param, Week10Param, Week11Param, Week12Param).FirstOrDefault();
                response.Success = true;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public BaseApiResponse UploadCustomerRequirementFile(string datatableToxml, int UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var datatableToxmlParam = new SqlParameter
                {
                    ParameterName = "datatableToxml",
                    DbType = DbType.String,
                    Value = (object)datatableToxml ?? (object)DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_customerRequirement_insertFromFile_Xlsx", datatableToxmlParam, UserIdParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
                response.InsertedId = -2;
            }

            return response;
        }




        #endregion
    }
}