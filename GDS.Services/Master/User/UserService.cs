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

namespace GDS.Services.Master.User
{
    public class UserService : IUserService
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
        private readonly IGenericRepository<UserMasterModel> _repository;

        #endregion

        #region ctor


        public UserService(IGenericRepository<UserMasterModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public ApiResponse<UserMasterModel> GetUserDetail(int? userId)
        {
            var response = new ApiResponse<UserMasterModel>();

            try
            {
                var userIDParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = userId
                };

                var result = _repository.ExecuteSQL<UserMasterModel>("usp_UserMaster_get", userIDParam).ToList();

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

        public ApiResponse<UserMasterModel> GetLoginUserDetails(string networkId)
        {
            var response = new ApiResponse<UserMasterModel>();

            try
            {
                var networkIdParam = new SqlParameter
                {
                    ParameterName = "networkId",
                    DbType = DbType.String,
                    Value = networkId
                };

                var result = _repository.ExecuteSQL<UserMasterModel>("usp_UserMaster_getLoginUserDetails", networkIdParam).ToList();

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

        public ApiResponse<RoleRightsPermissionModel> GetLoginUserRoleRights(int? UserId)
        {
            var response = new ApiResponse<RoleRightsPermissionModel>();

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<RoleRightsPermissionModel>("usp_UserPermission_get", UserIdParam).ToList();

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

        public BaseApiResponse SaveUserDetail(UserMasterModel UserObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var UserIDParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserObj.UserId
                };
                var UserNameParam = new SqlParameter
                {
                    ParameterName = "UserName",
                    DbType = DbType.String,
                    Value = (object)UserObj.UserName??(object) DBNull.Value
                };
                var FirstNameParam = new SqlParameter
                {
                    ParameterName = "p_FirstName",
                    DbType = DbType.String,
                    Value = (object)UserObj.FirstName
                };

                var LastNameParam = new SqlParameter
                {
                    ParameterName = "p_LastName",
                    DbType = DbType.String,
                    Value = (object)UserObj.LastName
                };

                var EmailParam = new SqlParameter
                {
                    ParameterName = "p_Email",
                    DbType = DbType.String,
                    Value = (object)UserObj.Email
                };

                //var SelectedPlantParam = new SqlParameter
                //{
                //    ParameterName = "p_SelectedPlant",
                //    DbType = DbType.String,
                //    Value = !string.IsNullOrWhiteSpace(UserObj.SelectedPlant) ? UserObj.SelectedPlant : (object)DBNull.Value
                //};
                var SelectedRegionParam = new SqlParameter
                {
                    ParameterName = "RegionIdCsv",
                    DbType = DbType.String,
                    Value = (object)UserObj.RegionIdCsv ?? (object)DBNull.Value
                };

                var SelectedPlantParam = new SqlParameter
                {
                    ParameterName = "PlantIdCsv",
                    DbType = DbType.String,
                    Value = (object)UserObj.PlantIdCsv?? (object)DBNull.Value
                };

                var SelectedRolesParam = new SqlParameter
                {
                    ParameterName = "p_SelectedRoles",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(UserObj.SelectedRoles) ? UserObj.SelectedRoles : (object)DBNull.Value
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "p_IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)UserObj.IsActive != null ? UserObj.IsActive : (object)DBNull.Value
                };

                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "p_LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)UserObj.LoggedInUserId
                };

                var NetworkUserIdParam = new SqlParameter
                {
                    ParameterName = "NetworkUserId",
                    DbType = DbType.String,
                    Value = (object)UserObj.NetworkUserId?? (object)DBNull.Value
                };

                var result = "";

                    result = _repository.ExecuteSQL<string>("usp_UserMaster_update", UserIDParam, UserNameParam, FirstNameParam, LastNameParam, EmailParam, SelectedRegionParam, SelectedPlantParam, SelectedRolesParam, IsActiveParam, LoggedInUserIdParam, NetworkUserIdParam).FirstOrDefault();

                if (result=="1")
                {
                    response.Success = true;
                }else
                {
                    response.Success = false;
                    response.Message.Add(result);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;

        }


        public ApiResponse<RegionMasterModel> GetRegionsByUserId(int? UserId, int? LoggedInUserId)
        {
            var response = new ApiResponse<RegionMasterModel>();

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId?? (object)DBNull.Value
                };
                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)LoggedInUserId ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<RegionMasterModel>("GetRegionsByUserId", UserIdParam, LoggedInUserIdParam).ToList();

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

        public ApiResponse<PlantMasterModel> GetPlantByRegionList(string Regions, int? UserId, int? LoggedInUserId)
        {
            var response = new ApiResponse<PlantMasterModel>();

            try
            {
                var RegionsParam = new SqlParameter
                {
                    ParameterName = "Regions",
                    DbType = DbType.String,
                    Value = (object)Regions ?? (object)DBNull.Value
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? (object)DBNull.Value
                };
                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)LoggedInUserId ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<PlantMasterModel>("GetPlantByRegionList", RegionsParam, UserIdParam, LoggedInUserIdParam).ToList();

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


        public ApiResponse<UserMasterModel> LoginUser(string Id, string Password)
        {
            var response = new ApiResponse<UserMasterModel>();

            try
            {
                var IdParam = new SqlParameter
                {
                    ParameterName = "Id",
                    DbType = DbType.String,
                    Value = Id
                };

                var PasswordParam = new SqlParameter
                {
                    ParameterName = "Password",
                    DbType = DbType.String,
                    Value = Password
                };

                var result = _repository.ExecuteSQL<UserMasterModel>("LoginUser", IdParam,PasswordParam).ToList();

         
                if (result.Count>0)
                {
                    if (result[0].AuthenticationFlag>0)
                    {
                        response.Success = false;
                    }else
                    {
                        response.Success = true;
                    }
                }

              
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
