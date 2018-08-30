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


namespace GDS.Services.ContactUs
{
    public class ContactUsService : IContactUsService
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
        private readonly IGenericRepository<ContactUsModel> _repository;
        #endregion

        #region ctor
        public ContactUsService(IGenericRepository<ContactUsModel> repository)
        {
            _repository = repository;
        }
        #endregion

        public ApiResponse<ContactUsModel> GetContactUs(int? ContactId,  int? UserId)
        {
            var response = new ApiResponse<ContactUsModel>();

            try
            {
                var ContactIdParam = new SqlParameter
                {
                    ParameterName = "ContactId",
                    DbType = DbType.Int32,
                    Value = (object)ContactId ?? DBNull.Value
                };
              
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ContactUsModel>("GetContactUs", ContactIdParam,  UserIdParam).ToList();
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

        public ApiResponse<ContactUsModel> GetContactListByStatus(int? MenuId, int? UserId, bool? IsActive)
        {
            var response = new ApiResponse<ContactUsModel>();

            try
            {
                var MenuIdParam = new SqlParameter
                {
                    ParameterName = "MenuId",
                    DbType = DbType.Int32,
                    Value = (object)MenuId ?? DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)IsActive ?? DBNull.Value
                };


                var result = _repository.ExecuteSQL<ContactUsModel>("GetContactListByStatus", MenuIdParam, UserIdParam, IsActiveParam).ToList();
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

        public ApiResponse<ContactUsModel> GetContactUsDetail(int? ContactId, int? UserId)
        {
            var response = new ApiResponse<ContactUsModel>();

            try
            {
                var ContactIdParam = new SqlParameter
                {
                    ParameterName = "ContactId",
                    DbType = DbType.Int32,
                    Value = (object)ContactId ?? DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<ContactUsModel>("GetContactUs", ContactIdParam, UserIdParam).ToList();
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


        public BaseApiResponse SaveContactDetail(int? UserId, ContactUsModel ContactObj)
        {
            var response = new BaseApiResponse();

            try
            {
                var ContactIdParam = new SqlParameter
                {
                    ParameterName = "ContactId",
                    DbType = DbType.Int32,
                    Value = (object)ContactObj.ContactId ?? DBNull.Value
                };

                var ContactDetailParam = new SqlParameter
                {
                    ParameterName = "ContactDetail",
                    DbType = DbType.String,
                    Value = (object)ContactObj.ContactDetail ?? DBNull.Value
                };

                var RegionIdParam = new SqlParameter
                {
                    ParameterName = "RegionId",
                    DbType = DbType.Int32,
                    Value = (object)ContactObj.RegionId ?? DBNull.Value
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)ContactObj.IsActive != null ? ContactObj.IsActive : (object)DBNull.Value
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

                //var DisplayOrderParam = new SqlParameter
                //{
                //    ParameterName = "DisplayOrder",
                //    DbType = DbType.Int16,
                //    Value = (Object)ProceeObj.DisplayOrder != null ? ProceeObj.DisplayOrder : (object)DBNull.Value
                //};
                //var RegionIdParam = new SqlParameter
                //{
                //    ParameterName = "SelectedRegion",
                //    DbType = DbType.String,
                //    Value = (object)ProceeObj.SelectedRegion ?? DBNull.Value
                //};



                var result = _repository.ExecuteSQL<int>("AddOrUpdateContactDetail", ContactIdParam, ContactDetailParam, RegionIdParam, IsActiveParam, UserIdParam).FirstOrDefault();
                if (result > 0)
                {
                    response.Success = true;
                    response.InsertedId = result;
                }

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteContact(int? ContactId, int? UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var ContactIdParam = new SqlParameter
                {
                    ParameterName = "ContactId",
                    DbType = DbType.Int32,
                    Value = (object)ContactId ?? DBNull.Value
                };

               
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };

               
                var result = _repository.ExecuteSQL<int>("DeleteContact", ContactIdParam,UserIdParam).FirstOrDefault();
                response.Success = (result > 0);

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
