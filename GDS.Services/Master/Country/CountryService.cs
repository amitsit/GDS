

namespace GDS.Services.Master.Country
{
    using Common;
    using Data.Repository;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountryService : ICountryService
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
        private readonly IGenericRepository<CountryMasterModel> _repository;

        #endregion

        #region ctor


        public CountryService(IGenericRepository<CountryMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        public ApiResponse<CountryMasterModel> GetCountyList(int? CountryId, int? RegionId)
        {
            var response = new ApiResponse<CountryMasterModel>();

            try
            {
                var countryIdParam = new SqlParameter
                {
                    ParameterName = "CountryId",
                    DbType = DbType.Int32,
                    Value = (object)CountryId ?? DBNull.Value
                };

                var regionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)RegionId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<CountryMasterModel>("usp_CountryMaster_get", countryIdParam, regionIdParam).ToList();
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

        public ApiResponse<CountryMasterModel> GetCountryDetail(int CountryID)
        {
            var response = new ApiResponse<CountryMasterModel>();

            try
            {
                var countryIDParam = new SqlParameter
                {
                    ParameterName = "p_CountryID",
                    DbType = DbType.Int32,
                    Value = (object)CountryID
                };
                var result = _repository.ExecuteSQL<CountryMasterModel>("usp_CountryMaster_get", countryIDParam).ToList();
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

        public ApiResponse<RegionMasterModel> GetRegionList()
        {
            var response = new ApiResponse<RegionMasterModel>();

            try
            {
                var result = _repository.ExecuteSQL<RegionMasterModel>("usp_RegionMaster_get").ToList();
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

        public BaseApiResponse AddOrUpdateCountry(int UserId, CountryMasterModel CountryObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var countryIDParam = new SqlParameter
                {
                    ParameterName = "p_CountryID",
                    DbType = DbType.Int32,
                    Value = (object)CountryObj.CountryID
                };
                var CountryNameParam = new SqlParameter
                {
                    ParameterName = "p_CountryName",
                    DbType = DbType.String,
                    Value = (object)CountryObj.CountryName
                };
                var RegionIDParam = new SqlParameter
                {
                    ParameterName = "p_SelectedRegion",
                    DbType = DbType.String,
                    Value = (object)CountryObj.SelectedRegion
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };
                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "p_IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)CountryObj.IsActive != null ? CountryObj.IsActive : (object)DBNull.Value
                };
                var result = 0;
                if (CountryObj.CountryID > 0)
                {
                    result = _repository.ExecuteSQL<int>("usp_CountryMaster_update", countryIDParam, CountryNameParam, RegionIDParam, UserIdParam, IsActiveParam).FirstOrDefault();
                }
                else
                {
                    result = _repository.ExecuteSQL<int>("usp_CountryMaster_insert", countryIDParam, CountryNameParam, RegionIDParam, UserIdParam, IsActiveParam).FirstOrDefault();
                }


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

        public BaseApiResponse DeleteCountry(int countryId)
        {
            var response = new BaseApiResponse();
            try
            {
                var countryIdParam = new SqlParameter
                {
                    ParameterName = "CountryID",
                    DbType = DbType.Int32,
                    Value = countryId
                };


                var result = _repository.ExecuteSQL<int>("usp_CountryMaster_delete", countryIdParam).FirstOrDefault();
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

    }
}
