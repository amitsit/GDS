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

namespace GDS.Services.Master.Role
{
  public class RoleService: IRoleService
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
        private readonly IGenericRepository<RoleModel> _repository;

        #endregion

        #region ctor


        public RoleService(IGenericRepository<RoleModel> repository)
        {
            _repository = repository;
        }

        #endregion


        #region Methods
        public ApiResponse<RoleModel> GetRoleList(int RoleId, int UserId)
        {
            var response = new ApiResponse<RoleModel>();

            try
            {
                var RoleIdParam = new SqlParameter
                {
                    ParameterName = "p_RoleId",
                    DbType = DbType.Int32,
                    Value = RoleId
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };
                var result = _repository.ExecuteSQL<RoleModel>("usp_RoleMaster_get", RoleIdParam, UserIdParam).ToList();
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

       public BaseApiResponse AddOrUpdateRole(int UserId, RoleModel RoleObj)
        {
            var response = new BaseApiResponse();

            try
            {
                var RoleIdParam = new SqlParameter
                {
                    ParameterName = "p_RoleId",
                    DbType = DbType.Int32,
                    Value =(object)RoleObj.RoleId
                };
                var RoleNameParam = new SqlParameter
                {
                    ParameterName = "p_RoleName",
                    DbType = DbType.String,
                    Value = (object)RoleObj.RoleName
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "p_IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)RoleObj.IsActive
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_RoleMaster_insert_update", RoleIdParam, RoleNameParam, IsActiveParam, UserIdParam).FirstOrDefault();
                response.Success =  result > 0;
                response.InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse RemoveRole(int RoleId, int UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var RoleIdParam = new SqlParameter
                {
                    ParameterName = "p_RoleId",
                    DbType = DbType.Int32,
                    Value = (object)RoleId
                };
               
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_RoleMaster_Delete", RoleIdParam,UserIdParam).FirstOrDefault();
                response.Success = result > 0;
                response.InsertedId = RoleId;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public ApiResponse<RoleRightsModel> GetRoleRights(int RoleId, int UserId)
        {
            var response = new ApiResponse<RoleRightsModel>();

            try
            {
                var RoleIdParam = new SqlParameter
                {
                    ParameterName = "p_RoleId",
                    DbType = DbType.Int32,
                    Value = RoleId
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };
                var result = _repository.ExecuteSQL<RoleRightsModel>("usp_RoleRightsMaster_get", RoleIdParam, UserIdParam).ToList();
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

        public BaseApiResponse AddOrUpdateRoleConfiguration(int UserId, List<RoleRightsModel> RoleRightsCollection)
        {
            var response = new BaseApiResponse();
            string getxmlstr = GDS.Common.ConvertToXml<RoleRightsModel>.GetXMLString(RoleRightsCollection);
            try
            {
                var RoleRightsCollectionParam = new SqlParameter
                {
                    ParameterName = "p_RoleRightsCollection",
                    DbType = DbType.String,
                    Value = getxmlstr
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("usp_RoleRights_insert_update", RoleRightsCollectionParam, UserIdParam).FirstOrDefault();

                response.Success = result>0;
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
