using GDS.Common;
using GDS.Data;
using GDS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Entities.STMP.LaborPlantSpecific;
using GDS.Services.STMP.LaborPlantSpecific;

namespace GDS.Services.STMP.LaborPlant
{
    public class LaborPlantSpecificService : ILaborPlantSpecificService
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
        private readonly IGenericRepository<LaborPlantSpecificModel> _repository;

        #endregion

        #region ctor

        public LaborPlantSpecificService(IGenericRepository<LaborPlantSpecificModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<LaborPlantSpecificModel> GetLaborPlantSpecificDetail(LaborPlantSpecificInputDataModel model)
        {
            var response = new ApiResponse<LaborPlantSpecificModel>();

            try
            {
                LaborPlantSpecificModel responseModel = new LaborPlantSpecificModel();
                SqlParameter[] paramList =
                {
                    new SqlParameter("PlantIdString",(object)model.PlantIdString?? DBNull.Value),
                    new SqlParameter("CycleTimeSelection",!string.IsNullOrWhiteSpace(model.CycleTimeSelection)?model.CycleTimeSelection : (object)DBNull.Value),
                    new SqlParameter("OEE",!string.IsNullOrWhiteSpace(model.OEE)?model.OEE : (object)DBNull.Value),
                    new SqlParameter("UserId",model.LoggedInUserId),
                    new SqlParameter("IsPlantSpecific",true),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("MaxUtilizationTarget",model.MaxUtilizationTarget),
                    new SqlParameter("Global_StdPerfomanceGoal",model.Global_StdPerfomanceGoal),
                    new SqlParameter("Global_AllPerformanceGoal",model.Global_AllPerformanceGoal)
                };

                DBAccess objDBAccess = new DBAccess();
                DataSet ds = objDBAccess.QuerySQL("usp_stmp_GetMainDashBoardData", paramList);
                responseModel.LaborPlantTable3 = Utility.ConvertDataTable<LaborPlantTable3>(ds.Tables[0]);
                var resultList = new List<LaborPlantSpecificModel>();
                resultList.Add(responseModel);
                response.Data = resultList;
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
