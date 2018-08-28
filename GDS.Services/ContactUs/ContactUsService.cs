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
    }
}
