using GDS.Entities.Master.IACCycleGoalModel;

namespace GDS.Services.Master.IACCycleGoal
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Common;
    using Entities;
    using Data.Repository;
    using Entities.Master;
    using System.Collections.Generic;

    public class IACCycleGoalService : IIACCycleGoalService
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
        private readonly IGenericRepository<IACCycleGoalModel> _repository;

        #endregion

        #region ctor
        
        public IACCycleGoalService(IGenericRepository<IACCycleGoalModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<TonnageRangeModel> GetTonnageRange()
        {
            var response = new ApiResponse<TonnageRangeModel>();

            try
            {
                var result = _repository.ExecuteSQL<TonnageRangeModel>("usp_mst_TonnageRangeMaster_GetTonnageRangeMaster").ToList();
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


        public ApiResponse<IACCycleGoalModel> GetIACCycleGoalList()
        {
            var response = new ApiResponse<IACCycleGoalModel>();

            try
            {
                var result = _repository.ExecuteSQL<IACCycleGoalModel>("usp_mst_IACCycleGoal_get").ToList();
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

        public ApiResponse<IACCycleGoalModel> GetIACCycleGoalDetail(int IACCycleGoalId)
        {
            var response = new ApiResponse<IACCycleGoalModel>();

            List<IACCycleGoalModel> IACCycleGoalList = new List<IACCycleGoalModel>();

            try
            {
                if (IACCycleGoalId == 0)
                {

                    IACCycleGoalModel IACCycleGoalModel = new IACCycleGoalModel();
                    IACCycleGoalList.Add(IACCycleGoalModel);
                }
                else
                {
                    var iACCycleGoalIdParam = new SqlParameter
                    {
                        ParameterName = "IACCycleGoalId",
                        DbType = DbType.Int32,
                        Value = IACCycleGoalId
                    };

                    IACCycleGoalList = _repository.ExecuteSQL<IACCycleGoalModel>("usp_mst_IACCycleGoal_getDetailById", iACCycleGoalIdParam).ToList();
                }

                response.Success = true;
                response.Data = IACCycleGoalList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse AddOrUpdateIACCycleGoalData(int UserId, IACCycleGoalModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                var IACCycleGoalIdParam = new SqlParameter
                {
                    ParameterName = "p_IACCycleGoalId",
                    DbType = DbType.Int32,
                    Value = (object)model.IACCycleGoalId
                };

                //var PlantIdParam = new SqlParameter
                //{
                //    ParameterName = "p_PlantId",
                //    DbType = DbType.Int32,
                //    Value = (object)model.PlantId != null ? (object)model.PlantId : (object)DBNull.Value
                //};


                //var StartRangeParam = new SqlParameter
                //{
                //    ParameterName = "p_StartRange",
                //    DbType = DbType.Int32,
                //    Value = (object)model.StartRange
                //};

                //var EndRangeParam = new SqlParameter
                //{
                //    ParameterName = "p_EndRange",
                //    DbType = DbType.Int32,
                //    Value = (object)model.EndRange
                //};

                var tonnageRangeIdParam = new SqlParameter
                {
                    ParameterName = "TonnageRangeId",
                    DbType = DbType.Int32,
                    Value = model.TonnageRangeId
                };

                var IACBICParam = new SqlParameter
                {
                    ParameterName = "p_IACBIC",
                    DbType = DbType.Int32,
                    Value = (object)model.IACBIC
                };

                var WorldClassParam = new SqlParameter
                {
                    ParameterName = "p_WorldClass",
                    DbType = DbType.Int32,
                    Value = (object)model.WorldClass
                };

                var AvgLaborPerPressSizeParam = new SqlParameter
                {
                    ParameterName = "p_AvgLaborPerPressSize",
                    DbType = DbType.Double,
                    Value = (object)model.AvgLaborPerPressSize
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = 0;
                if (model.IACCycleGoalId > 0)
                {
                    result = _repository.ExecuteSQL<int>("usp_mst_IACCycleGoal_update", IACCycleGoalIdParam //,PlantIdParam
                                                        //,StartRangeParam, EndRangeParam
                                                        , tonnageRangeIdParam
                                                        , IACBICParam, WorldClassParam, AvgLaborPerPressSizeParam, UserIdParam).FirstOrDefault();
                }
                else
                {
                    result = _repository.ExecuteSQL<int>("usp_mst_IACCycleGoal_insert" //, PlantIdParam
                                                        //, StartRangeParam, EndRangeParam
                                                        ,tonnageRangeIdParam
                                                        , IACBICParam, WorldClassParam, AvgLaborPerPressSizeParam, UserIdParam).FirstOrDefault();
                }


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

        public BaseApiResponse DeleteIACCycleGoalData(int IACCycleGoalId)
        {
            var response = new BaseApiResponse();

            try
            {
                var iACCycleGoalIdParam = new SqlParameter
                {
                    ParameterName = "IACCycleGoalId",
                    DbType = DbType.Int32,
                    Value = IACCycleGoalId
                };

                var result = _repository.ExecuteSQL<int>("usp_mst_IACCycleGoal_delete", iACCycleGoalIdParam).FirstOrDefault();
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
