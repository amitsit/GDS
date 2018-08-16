using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.RheologyCurve;

namespace GDS.Services.SMOM.RheologyCurve
{
    class RheologyCurveService : IRheologyCurveService
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
        private readonly IGenericRepository<RheologyCurveModel> _repository;
        #endregion

        #region ctor
        public RheologyCurveService(IGenericRepository<RheologyCurveModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public ApiResponse<RheologyCurveModel> GetRheologyCurveDetails(int plantId, int plantEquipmentListId, short lengthUnitId, long coverPageId)
        {
            var response = new ApiResponse<RheologyCurveModel>();
            try
            {
                var PlantId = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };
                var PlantEquipmentListId = new SqlParameter
                {
                    ParameterName = "PlantEquipmentListId",
                    DbType = DbType.Int32,
                    Value = plantEquipmentListId
                };
                var LengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var CoverPageId = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = coverPageId
                };

                var result = _repository.ExecuteSQL<RheologyCurveModel>("usp_smom_RheologyCurve_get", PlantId, PlantEquipmentListId, CoverPageId, LengthUnitId).ToList();

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

        public BaseApiResponse SaveRheologyCurveDetails(RheologyCurvePostModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("RheologyCurveId",(object)model.RheologyCurveId?? DBNull.Value),
                    new SqlParameter("CoverPageId",(object)model.CoverPageId ?? DBNull.Value),
                    new SqlParameter("ProductionInjectionSpeed",(object)model.ProductionInjectionSpeed?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId ?? DBNull.Value)

                };

                var result = _repository.ExecuteSQL<int>("usp_smom_RheologyCurve_save", paramList).FirstOrDefault();
                response.InsertedId = result;
                response.Success = true;
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
