namespace GDS.Services.STMP.DailyRecapRap_PressParameters
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Common;
    using Entities;
    using Data.Repository;
    using GDS.Entities.STMP.DailyRecapRap;
    using System.Collections.Generic;
    public class DailyRecapRap_PressParametersService : IDailyRecapRap_PressParametersService
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
        private readonly IGenericRepository<STMP_DailyRecapRap_PressParametersModel> _repository;

        #endregion

        #region ctor


        public DailyRecapRap_PressParametersService(IGenericRepository<STMP_DailyRecapRap_PressParametersModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPressParameters(int plantId, int userId, long plantMonthYearId)
        {
            var response = new ApiResponse<STMP_DailyRecapRap_PressParametersModel>();

            try
            {
                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var useridParam = new SqlParameter
                {
                    ParameterName = "LoginUserId",
                    DbType = DbType.Int32,
                    Value = userId
                };
                var plantMonthYearidParam = new SqlParameter
                {
                    ParameterName = "plantMonthYearId",
                    DbType = DbType.Int64,
                    Value = plantMonthYearId
                };

                var result = _repository.ExecuteSQL<STMP_DailyRecapRap_PressParametersModel>("usp_stmp_STMP_DailyRecapRep_PressParameters_get",
                                plantidParam, useridParam, plantMonthYearidParam).ToList();
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

        public BaseApiResponse UpdateDailyRecapRepPressParameters(int plantId, int userId, long plantMonthYearId, List<STMP_DailyRecapRap_PressParametersModel> dailyRecapRapPressParametersList)
        {
            var response = new BaseApiResponse();
            try
            {
                string getxmlstr = ConvertToXml<STMP_DailyRecapRap_PressParametersModel>.GetXMLString(dailyRecapRapPressParametersList);

                var dailyRecapRapPressParametersListXML = new SqlParameter
                {
                    ParameterName = "dailyRecapRapPressParametersList",
                    DbType = DbType.String,
                    Value = getxmlstr
                };

                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var useridParam = new SqlParameter
                {
                    ParameterName = "LoginUserId",
                    DbType = DbType.Int32,
                    Value = userId
                };
                var plantMonthYearidParam = new SqlParameter
                {
                    ParameterName = "PlantMonthYearId",
                    DbType = DbType.Int64,
                    Value = plantMonthYearId
                };
                
                
             var  result = _repository.ExecuteSQL<int>("usp_stmp_STMP_DailyRecapRep_PressParameters_update",
                  dailyRecapRapPressParametersListXML, plantidParam, useridParam, plantMonthYearidParam).FirstOrDefault();

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
        public ApiResponse<STMP_DailyRecapRap_PressParametersModel> GetDailyRecapRapPlantMasterDetail()
        {
            var response = new ApiResponse<STMP_DailyRecapRap_PressParametersModel>();

            try
            {
                var result = _repository.ExecuteSQL<STMP_DailyRecapRap_PressParametersModel>("usp_stmp_DailyRecapRap_PlantMasterDetail_get").ToList();
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

        #endregion
    }
}
