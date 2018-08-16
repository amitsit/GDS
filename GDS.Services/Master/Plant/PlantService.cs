using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GDS.Services.Master.Plant
{
    public class PlantService : IPlantService
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
        private readonly IGenericRepository<PlantMasterModel> _repository;

        #endregion

        #region ctor


        public PlantService(IGenericRepository<PlantMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<PlantMasterModel> GetPlantDetail(int plantId)
        {
            var response = new ApiResponse<PlantMasterModel>();

            List<PlantMasterModel> planMasterModelList = new List<PlantMasterModel>();
            PlantMasterModel planMasterModel = new PlantMasterModel();
            planMasterModelList.Add(planMasterModel);

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value =(object)plantId ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<PlantMasterModel>("usp_GetPlantFromPlantMaster", plantIdParam).ToList();
                if (plantId == 0)
                {
                    response.Data = planMasterModelList;
                }
                else
                {
                    response.Data = result;
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SavePlant(PlantMasterModel plantObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantID",
                    DbType = DbType.Int32,
                    Value = plantObj.PlantID
                };
                var plantNameParam = new SqlParameter
                {
                    ParameterName = "PlantName",
                    DbType = DbType.String,
                    Value = plantObj.PlantName
                };
                var specificationPlantNameParam = new SqlParameter
                {
                    ParameterName = "PlantName_PressSpecification",
                    DbType = DbType.String,
                    Value = plantObj.PlantName_PressSpecification
                };

                var qadPlantNameParam = new SqlParameter
                {
                    ParameterName = "PlantName_QAD",
                    DbType = DbType.String,
                    Value =(object) plantObj.PlantName_QAD ?? DBNull.Value
                };
                var regionIdParam = new SqlParameter
                {
                    ParameterName = "RegionID",
                    DbType = DbType.Int32,
                    Value = plantObj.RegionID
                };
                var countryIdParam = new SqlParameter
                {
                    ParameterName = "CountryID",
                    DbType = DbType.Int32,
                    Value = plantObj.CountryID
                };
                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = plantObj.LoggedInUserId
                };

                var unitSystemIdParam = new SqlParameter
                {
                    ParameterName = "UnitSystemId",
                    DbType = DbType.Int32,
                    Value = plantObj.UnitSystemId
                };

                var lengthUnitParam = new SqlParameter
                {
                    ParameterName = "LengthUnit",
                    DbType = DbType.Int32,
                    Value = plantObj.LengthUnit
                };

                var pressureUnitParam = new SqlParameter
                {
                    ParameterName = "PressureUnit",
                    DbType = DbType.Int32,
                    Value = plantObj.PressureUnit
                };

                var headCountParam = new SqlParameter
                {
                    ParameterName = "HeadCount",
                    DbType = DbType.Decimal,
                    Value = (object)plantObj.HeadCount ?? DBNull.Value
                };

                var fringeWageRateParam = new SqlParameter
                {
                    ParameterName = "FringeWageRate",
                    DbType = DbType.Double,
                    Value = (object)plantObj.FringeWageRate ?? DBNull.Value
                };

                var hourlyWageRateParam = new SqlParameter
                {
                    ParameterName = "HourlyWageRate",
                    DbType = DbType.Double,
                    Value = (object)plantObj.HourlyWageRate ?? DBNull.Value
                };

                var stdPerfomanceGoalParam = new SqlParameter
                {
                    ParameterName = "StdPerfomanceGoal",
                    DbType = DbType.Double,
                    Value = plantObj.StdPerfomanceGoal
                };

                var allPerformanceGoalParam = new SqlParameter
                {
                    ParameterName = "AllPerformanceGoal",
                    DbType = DbType.Double,
                    Value = plantObj.AllPerformanceGoal
                };

                var locationParam = new SqlParameter
                {
                    ParameterName = "Location",
                    DbType = DbType.String,
                    Value = plantObj.Location
                };

                var moldingManningParam = new SqlParameter
                {
                    ParameterName = "MoldingManning",
                    DbType = DbType.Double,
                    Value = (object)plantObj.MoldingManning ?? DBNull.Value
                };

                var defaultUTLZPercentageParam = new SqlParameter
                {
                    ParameterName = "DefaultUTLZPercentage",
                    DbType = DbType.Double,
                    Value = (object)plantObj.DefaultUTLZPercentage ?? DBNull.Value
                };


                var isActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = plantObj.IsActive
                };

                var injectionMoldingIdParam = new SqlParameter
                {
                    ParameterName = "InjectionMoldingAreaId ",
                    DbType = DbType.String,
                    Value = (object)plantObj.InjectionMoldingAreaId ?? DBNull.Value
                };

                var plantcolorParam = new SqlParameter
                {
                    ParameterName = "PlantColor",
                    DbType = DbType.String,
                    Value = (object)plantObj.PlantColor ?? DBNull.Value
                };

                var stdReliefDivisorParam = new SqlParameter
                {
                    ParameterName = "StdReliefDivisor",
                    DbType = DbType.Double,
                    Value = (object)plantObj.StdReliefDivisor ?? DBNull.Value
                };

                var stdQuotedWeekParam = new SqlParameter
                {
                    ParameterName = "StdQuotedWeek",
                    DbType = DbType.Double,
                    Value = (object)plantObj.StdQuotedWeek ?? DBNull.Value
                };
                var saasIdParam = new SqlParameter
                {
                    ParameterName = "SaasId",
                    DbType = DbType.Int32,
                    Value = (object)plantObj.SaasId ?? DBNull.Value
                };


                var result = _repository.ExecuteSQL<int>("usp_PlantMaster_SavePlantMaster",
                                plantIdParam, plantNameParam, specificationPlantNameParam, qadPlantNameParam, regionIdParam, countryIdParam,
                                locationParam, unitSystemIdParam, lengthUnitParam, pressureUnitParam, headCountParam,
                                fringeWageRateParam, hourlyWageRateParam, stdPerfomanceGoalParam, allPerformanceGoalParam,
                                moldingManningParam, defaultUTLZPercentageParam, stdReliefDivisorParam, stdQuotedWeekParam,
                                userIdParam, isActiveParam, injectionMoldingIdParam, plantcolorParam, saasIdParam).FirstOrDefault();


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

        public BaseApiResponse DeletePlant(long plantId)
        {
            var response = new BaseApiResponse();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int64,
                    Value = plantId
                };

                var result = _repository.ExecuteSQL<int>("usp_PlantMaster_delete", plantIdParam).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<PlantMasterModel> GetPlantListMaster(int? PlantId, int UserId)
        {
            var response = new ApiResponse<PlantMasterModel>();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value =(object) PlantId??(object)DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<PlantMasterModel>("usp_GetPlantFromPlantMaster", plantIdParam, UserIdParam).ToList();
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
