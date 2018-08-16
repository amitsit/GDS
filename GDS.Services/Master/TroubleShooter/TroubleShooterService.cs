using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GDS.Services.Master.TroubleShooter
{
    public class TroubleShooterService : ITroubleShooterService
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
        private readonly IGenericRepository<TroubleShooterModel> _repository;

        #endregion


        #region ctor
        public TroubleShooterService(IGenericRepository<TroubleShooterModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region methods
        public ApiResponse<TroubleShooterModel> GetTroubleShooterList(long TroubleShooterId)
        {
            var response = new ApiResponse<TroubleShooterModel>();

            try
            {

                var troubleShooterIdParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterId",
                    DbType = DbType.Int64,
                    Value = (object)TroubleShooterId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<TroubleShooterModel>("usp_MST_Troubleshooter_get", troubleShooterIdParam).ToList();
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

        public ApiResponse<TroubleShooterModel> GetTroubleShooterDetail(long TroubleShooterId)
        {
            var response = new ApiResponse<TroubleShooterModel>();

            try
            {

                var troubleShooterIdParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterId",
                    DbType = DbType.Int64,
                    Value = (object)TroubleShooterId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<TroubleShooterModel>("usp_MST_Troubleshooter_get", troubleShooterIdParam).ToList();
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

        public BaseApiResponse AddOrUpdateTroubleShooter(TroubleShooterModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var troubleShooterIdParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterId",
                    DbType = DbType.Int64,
                    Value = model.TroubleShooterId
                };

                var troubleShooterButtonNameParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterButtonName",
                    DbType = DbType.String,
                    Value = model.TroubleShooterButtonName
                };
                var troubleShooterDescriptionParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterDescription",
                    DbType = DbType.String,
                    Value = model.TroubleShooterDescription
                };
                var languageCdParam = new SqlParameter
                {
                    ParameterName = "LanguageCd",
                    DbType = DbType.String,
                    Value = model.LanguageCd
                };
                var PageNameParam = new SqlParameter
                {
                    ParameterName = "PageName",
                    DbType = DbType.String,
                    Value = model.PageName
                };
                var userIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = model.UserId
                };

                var result = 0;
                result = _repository.ExecuteSQL<int>("usp_MST_Troubleshooter_insert_update", troubleShooterIdParam, troubleShooterButtonNameParam,
                    troubleShooterDescriptionParam, languageCdParam, PageNameParam, userIdParam).FirstOrDefault();

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

        public BaseApiResponse DeleteTroubleShooter(long TroubleShooterId)
        {
            var response = new BaseApiResponse();
            try
            {
                var troubleShooterIdParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterId",
                    DbType = DbType.Int64,
                    Value = TroubleShooterId
                };
                var result = 0;

                result = _repository.ExecuteSQL<int>("usp_MST_Troubleshooter_delete", troubleShooterIdParam).FirstOrDefault();
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

        public ApiResponse<TroubleShooterModel> GetPageHelp(string PageName,string LanguageCd)
        {
            var response = new ApiResponse<TroubleShooterModel>();

            try
            {
                var PageNameParamParam = new SqlParameter
                {
                    ParameterName = "PageName",
                    DbType = DbType.String,
                    Value = PageName
                };
                var LanguageCdParamParam = new SqlParameter
                {
                    ParameterName = "LanguageCd",
                    DbType = DbType.String,
                    Value = LanguageCd
                };


                var result = _repository.ExecuteSQL<TroubleShooterModel>("usp_smom_TroubleShooterGuidePageHelp_get", PageNameParamParam, LanguageCdParamParam).ToList();
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

        public ApiResponse<TroubleShooterModel> GetPageHelpContent(long TroubleShooterId)
        {
            var response = new ApiResponse<TroubleShooterModel>();

            try
            {
                var troubleShooterIdParam = new SqlParameter
                {
                    ParameterName = "TroubleShooterId",
                    DbType = DbType.Double,
                    Value = TroubleShooterId
                };


                var result = _repository.ExecuteSQL<TroubleShooterModel>("usp_smom_TroubleShooterPageHelpContent_get", troubleShooterIdParam).ToList();
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

        public ApiResponse<TroubleShooterModel> GetPageHelpDetail(string PageName, string LanguageCd)
        {
            var response = new ApiResponse<TroubleShooterModel>();

            try
            {
                var PageNameParam = new SqlParameter
                {
                    ParameterName = "PageName",
                    DbType = DbType.String,
                    Value = PageName
                };

                var LanguageCdParam = new SqlParameter
                {
                    ParameterName = "LanguageCd",
                    DbType = DbType.String,
                    Value = LanguageCd
                };


                var result = _repository.ExecuteSQL<TroubleShooterModel>("usp_smom_TroubleShooter_getPageHelpDetail", PageNameParam, LanguageCdParam).ToList();
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
