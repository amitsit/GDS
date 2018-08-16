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

namespace GDS.Services.Master.PlantLaborCost
{
    public class PlantLaborCostService : IPlantLaborCostService
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
        private readonly IGenericRepository<PlantLaborCostModel> _repository;

        #endregion

        #region ctor


        public PlantLaborCostService(IGenericRepository<PlantLaborCostModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<PlantLaborCostModel> GetPlantLaborCost(long? PlantLaborCostId = null)
        {
            var response = new ApiResponse<PlantLaborCostModel>();

            try
            {
                var plantLaborCostIdParam = new SqlParameter
                {
                    ParameterName = "PlantLaborCostId",
                    DbType = DbType.Int32,
                    Value = (object)PlantLaborCostId ?? DBNull.Value
                };

                response.Data = _repository.ExecuteSQL<PlantLaborCostModel>("usp_PlantLaborCostMaster_Get", plantLaborCostIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SavePlantLaborCost(PlantLaborCostModel plantLaborCostObject)
        {
            var response = new BaseApiResponse();
            try
            {

                object[] paramList =
              {
                    new SqlParameter("PlantLaborCostId",(object)plantLaborCostObject.PlantLaborCostId?? DBNull.Value),
                    new SqlParameter("PlantId",(object)plantLaborCostObject.PlantId?? DBNull.Value),
                    new SqlParameter("CategoryId",(object)plantLaborCostObject.CategoryId?? DBNull.Value),
                    new SqlParameter("Name",(object)plantLaborCostObject.Name ?? DBNull.Value),
                    new SqlParameter("Cost",(object)plantLaborCostObject.Cost ?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",plantLaborCostObject.LoggedInUserId)
                };

                var result = _repository.ExecuteSQL<long>("usp_PlantLaborCostMaster_Save", paramList).FirstOrDefault();

                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public BaseApiResponse DeletePlantLaborCost(long PlantLaborCostId)
        {
            var response = new BaseApiResponse();

            try
            {
                var PlantLaborCostIdParam = new SqlParameter
                {
                    ParameterName = "PlantLaborCostId",
                    DbType = DbType.Int32,
                    Value = PlantLaborCostId
                };

                var result = _repository.ExecuteSQL<long>("usp_PlantLaborCostMaster_Delete", PlantLaborCostIdParam).FirstOrDefault();
                response.Success = result > 0;
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
