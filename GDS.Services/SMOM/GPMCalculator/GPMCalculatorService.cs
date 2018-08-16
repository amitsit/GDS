using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.GPMCalculator;

namespace GDS.Services.SMOM.GPMCalculator
{
    class GPMCalculatorService : IGPMCalculatorService
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
        private readonly IGenericRepository<GPMCalculatorModel> _repository;

        #endregion

        #region ctor

        public GPMCalculatorService(IGenericRepository<GPMCalculatorModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<GPMCalculatorModel> GetGPMCalculatorDetails(Int16 lengthUnitId, Int16 pressureUnitId, long coverPageId)
        {
            var response = new ApiResponse<GPMCalculatorModel>();
            try
            {
                var CoverPageId = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = coverPageId
                };
                var LengthUnitId = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };
                var PressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = pressureUnitId
                };
                var result = _repository.ExecuteSQL<GPMCalculatorModel>("usp_smom_GPMCalculatorDetails_get", CoverPageId, LengthUnitId, PressureUnitId).ToList();

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

        public BaseApiResponse InsertUpdateGPMCalculator(short lengthUnitId, short pressureUnitId, GPMCalculatorModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("CoverPageId",model.CoverPageId),
                    new SqlParameter("MaterialTypeId",model.MaterialTypeId),
                    new SqlParameter("MaterialId",model.MaterialId),
                    new SqlParameter("MeltTemp",(object)model.MeltTemp?? DBNull.Value),
                    new SqlParameter("PartEjectTemp",(object)model.PartEjectTemp?? DBNull.Value),
                    new SqlParameter("WaterTemp",model.WaterTemp),
                    new SqlParameter("AllowableTempRise",(object)model.AllowableTempRise?? DBNull.Value),
                    new SqlParameter("CycleTime",(object)model.CycleTime?? DBNull.Value),
                    new SqlParameter("ShotWeight",(object)model.ShotWeight?? DBNull.Value),
                    new SqlParameter("PartThickness",(object)model.PartThickness?? DBNull.Value),
                    new SqlParameter("LoggedInUserId",model.LoggedInUserId),
                    new SqlParameter("LengthUnitId", lengthUnitId),
                    new SqlParameter("PressureUnitId", pressureUnitId)
                };

                var result = _repository.ExecuteSQL<Int64>("usp_smom_GPMCalculator_insert_update", paramList).FirstOrDefault();
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
    }

    #endregion
}
