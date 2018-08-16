using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.STMP.InputData;
using GDS.Services.STMP.InputData;

namespace GDS.Services.Master.CTPartThicknessAddition
{
    public class CTPartThicknessAdditionService : ICTPartThicknessAdditionService
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
        private readonly IGenericRepository<CTPartThicknessAdditionModel> _repository;

        #endregion

        #region ctor


        public CTPartThicknessAdditionService(IGenericRepository<CTPartThicknessAdditionModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<CTPartThicknessAdditionModel> GetCTPartThicknessAddition(long? CTPartThicknessAdditionId)
        {
            var response = new ApiResponse<CTPartThicknessAdditionModel>();

            try
            {
                var cTPartThicknessAdditionIdParam = new SqlParameter
                {
                    ParameterName = "CTPartThicknessAdditionId",
                    DbType = DbType.Int64,
                    Value = (object)CTPartThicknessAdditionId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<CTPartThicknessAdditionModel>("usp_CTPartThicknessAddition_GetCTPartThicknessAddition", cTPartThicknessAdditionIdParam).ToList();
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

        public BaseApiResponse AddOrUpdateCTPartThicknessAdditionData(int UserId, CTPartThicknessAdditionModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var CTPartThicknessAdditionIdParam = new SqlParameter
                {
                    ParameterName = "CTPartThicknessAdditionId",
                    DbType = DbType.Int64,
                    Value = (object)model.CTPartThicknessAdditionId
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                //var PlantIdParam = new SqlParameter
                //{
                //    ParameterName = "PlantId",
                //    DbType = DbType.Int32,
                //    Value = (object)model.PlantId
                //};

                //var PlantMonthYearIdParam = new SqlParameter
                //{
                //    ParameterName = "PlantMonthYearId",
                //    DbType = DbType.Int32,
                //    Value = (object)model.PlantMonthYearId ?? DBNull.Value
                //};

                var FromRangeMMParam = new SqlParameter
                {
                    ParameterName = "FromRangeMM",
                    DbType = DbType.Decimal,
                    Value = (object)model.FromRangeMM
                };

                var ToRangeMMParam = new SqlParameter
                {
                    ParameterName = "ToRangeMM",
                    DbType = DbType.Decimal,
                    Value = (object)model.ToRangeMM
                };

                var CTValueParam = new SqlParameter
                {
                    ParameterName = "CTValue",
                    DbType = DbType.Int32,
                    Value = (object)model.CTValue
                };

                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = (object)model.IsActive
                };


                var result = 0;

                result = _repository.ExecuteSQL<int>("usp_CTPartThicknessAddition_SaveCTPartThicknessAddition",
                                                    CTPartThicknessAdditionIdParam, UserIdParam //, PlantIdParam, PlantMonthYearIdParam
                                                    , FromRangeMMParam, ToRangeMMParam, CTValueParam, IsActiveParam).FirstOrDefault();

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


        public BaseApiResponse DeleteCTPartThicknessAdditionData(long CTPartThicknessAdditionId)
        {
            var response = new BaseApiResponse();

            try
            {
                var cTPartThicknessAdditionIdParam = new SqlParameter
                {
                    ParameterName = "CTPartThicknessAdditionId",
                    DbType = DbType.Int64,
                    Value = CTPartThicknessAdditionId
                };

                var result = _repository.ExecuteSQL<int>("usp_CTPartThicknessAddition_DeleteCTPartThicknessAddition", cTPartThicknessAdditionIdParam).FirstOrDefault();
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