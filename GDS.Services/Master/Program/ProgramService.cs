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

namespace GDS.Services.Master.Program
{
    public class ProgramService : IProgramService
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
        private readonly IGenericRepository<ProgramMasterModel> _repository;

        #endregion

        #region ctor


        public ProgramService(IGenericRepository<ProgramMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        public ApiResponse<ProgramMasterModel> GetProgramList()
        {
            var response = new ApiResponse<ProgramMasterModel>();

            try
            {
                var result = _repository.ExecuteSQL<ProgramMasterModel>("usp_ProgramMaster_get").ToList();
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

        public ApiResponse<ProgramMasterModel> GetProgramDetail(int ProgramID)
        {
            var response = new ApiResponse<ProgramMasterModel>();

            List<ProgramMasterModel> ProgramModelList = new List<ProgramMasterModel>();
            ProgramMasterModel ProgramMasterModel = new ProgramMasterModel();
            ProgramModelList.Add(ProgramMasterModel);

            try
            {
                var programIDParam = new SqlParameter
                {
                    ParameterName = "p_ProgramID",
                    DbType = DbType.Int32,
                    Value = ProgramID
                };

                var result = _repository.ExecuteSQL<ProgramMasterModel>("usp_ProgramMaster_get", programIDParam).ToList();
                if (ProgramID == 0)
                {
                    response.Data = ProgramModelList;
                }
                else
                {
                    response.Data = result;
                }
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<PlantMasterModel> GetPlantList(int UserId)
        {
            var response = new ApiResponse<PlantMasterModel>();

            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value =(object) UserId??DBNull.Value
                };
                var result = _repository.ExecuteSQL<PlantMasterModel>("usp_PlantMaster_get", UserIdParam).ToList();
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

        public BaseApiResponse AddOrUpdateProgram(int UserId, ProgramMasterModel ProgramObj)
        {
            var response = new BaseApiResponse();
            try
            {
                var ProgramIDParam = new SqlParameter
                {
                    ParameterName = "p_ProgramID",
                    DbType = DbType.Int32,
                    Value = (object)ProgramObj.ProgramID
                };
                var ProgramNameParam = new SqlParameter
                {
                    ParameterName = "p_ProgramName",
                    DbType = DbType.String,
                    Value = (object)ProgramObj.ProgramName
                };
                var PlantIDParam = new SqlParameter
                {
                    ParameterName = "p_PlantID",
                    DbType = DbType.Int32,
                    Value =(object) ProgramObj.PlantID ?? (object)DBNull.Value 
                };
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "p_UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };
                var IsActiveParam = new SqlParameter
                {
                    ParameterName = "p_IsActive",
                    DbType = DbType.Boolean,
                    Value = (Object)ProgramObj.IsActive != null ? ProgramObj.IsActive : (object)DBNull.Value
                };

                var LCRParam = new SqlParameter
                {
                    ParameterName = "LCR",
                    DbType = DbType.Double,
                    Value = (Object)ProgramObj.LCR != null ? ProgramObj.LCR : (object)DBNull.Value
                };

                var MCRParam = new SqlParameter
                {
                    ParameterName = "MCR",
                    DbType = DbType.Double,
                    Value = (Object)ProgramObj.MCR != null ? ProgramObj.MCR : (object)DBNull.Value
                };

                var IHSParam = new SqlParameter
                {
                    ParameterName = "IHS",
                    DbType = DbType.Double,
                    Value = (Object)ProgramObj.IHS != null ? ProgramObj.IHS : (object)DBNull.Value
                };

                var startdateParam = new SqlParameter
                {
                    ParameterName = "StartDate",
                    DbType = DbType.DateTime,
                    Value = (Object)ProgramObj.StartDate ??DBNull.Value
                };

                var enddateParam = new SqlParameter
                {
                    ParameterName = "EndDate",
                    DbType = DbType.DateTime,
                    Value = (Object)ProgramObj.EndDate ?? DBNull.Value
                };



                var result = 0;
                if (ProgramObj.ProgramID > 0)
                {
                    result = _repository.ExecuteSQL<int>("usp_ProgramMaster_update", ProgramIDParam, ProgramNameParam, PlantIDParam, UserIdParam, IsActiveParam, LCRParam, MCRParam, IHSParam, startdateParam, enddateParam).FirstOrDefault();
                }
                else
                {
                    result = _repository.ExecuteSQL<int>("usp_ProgramMaster_insert", ProgramIDParam, ProgramNameParam, PlantIDParam, UserIdParam, IsActiveParam, LCRParam, MCRParam, IHSParam, startdateParam, enddateParam).FirstOrDefault();
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


        public BaseApiResponse DeleteProgram(long ProgramID)
        {
            var response = new BaseApiResponse();

            try
            {
                var ProgramIDParam = new SqlParameter
                {
                    ParameterName = "InputDataId",
                    DbType = DbType.Int64,
                    Value = ProgramID
                };

                var result = _repository.ExecuteSQL<int>("usp_ProgramMaster_delete", ProgramIDParam).FirstOrDefault();
                response.Success = result > 0;
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
