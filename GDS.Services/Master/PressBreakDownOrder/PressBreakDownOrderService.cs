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

namespace GDS.Services.Master.PressBreakDownOrder
{
    public class PressBreakDownOrderService : IPressBreakDownOrderService
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
        private readonly IGenericRepository<PressBreakDownOrderModel> _repository;

        #endregion

        #region ctor


        public PressBreakDownOrderService(IGenericRepository<PressBreakDownOrderModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods


        public ApiResponse<PressBreakDownOrderModel> GetPressBreakDownOrderData(int PlantId)
        {
            var response = new ApiResponse<PressBreakDownOrderModel>();

            try
            {
                var plantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId ?? DBNull.Value
                };

                response.Data = _repository.ExecuteSQL<PressBreakDownOrderModel>("usp_PressBreakDownOrder_Get", plantIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SavePressBreakDownOrderData(int UserId, List<PressBreakDownOrderModel> PressBreakDownOrderData)
        {
            var response = new BaseApiResponse();

            string PressBreakDownOrderDataXml = GDS.Common.ConvertToXml<PressBreakDownOrderModel>.GetXMLString(PressBreakDownOrderData);

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId ?? DBNull.Value
                };
                var PressBreakDownOrderDataXmlParam = new SqlParameter
                {
                    ParameterName = "PressBreakDownOrderDataXml",
                    DbType = DbType.String,
                    Value = (object)PressBreakDownOrderDataXml ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("usp_PressBreakDownOrder_SetOrderNumber", UserIdParam, PressBreakDownOrderDataXmlParam).FirstOrDefault();
                if(result>0)
                {
                    response.Success = true;
                }
               
                return response;

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
