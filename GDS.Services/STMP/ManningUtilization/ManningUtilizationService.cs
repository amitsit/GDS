using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.ManningUtilization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDS.Data;
using System.Configuration;
using GDS.Entities.STMP.CapacityChart;

namespace GDS.Services.STMP.ManningUtilization
{
   public class ManningUtilizationService: IManningUtilizationService
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
        private readonly IGenericRepository<ManningUtilizationModel> _repository;

        #endregion

        #region ctor


        public ManningUtilizationService(IGenericRepository<ManningUtilizationModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<ManningUtilizationModel> GetManningUtilizationAllocation(PlantUtilizationInputParamModel model)
        {
            var response = new ApiResponse<ManningUtilizationModel>();

            try
            {
                SqlParameter[] paramList =
               {
                    new SqlParameter("ScenarioHeaderId",(object) model.ScenarioHeaderId ?? DBNull.Value),
                    new SqlParameter("PlantId",model.PlantId),
                    new SqlParameter("CycleTimeSelection",model.CycleTimeSelection),
                    new SqlParameter("OEE",model.OEE),
                    new SqlParameter("STDCYC",model.STDCYC),
                    //new SqlParameter("UserId",model.UserId),
                    new SqlParameter("LengthUnitId",model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("MoldingManning",(object)model.MoldingManning ?? DBNull.Value),
                    new SqlParameter("FringeWageRate",(object)model.FringeWageRate ?? DBNull.Value),
                    new SqlParameter("HourlyWageRate",(object)model.HourlyWageRate ?? DBNull.Value),
                    new SqlParameter("StdReliefDivisor",(object)model.StdReliefDivisor ?? DBNull.Value),
                    new SqlParameter("StdQuotedWeek",(object)model.StdQuotedWeek ?? DBNull.Value),
                    new SqlParameter("Global_StdPerfomanceGoal",(object)model.Global_StdPerfomanceGoal?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal?? DBNull.Value)
                };

                var ctx = new DBAccess();
                var ds = ctx.QuerySQL("usp_ManningAndUtilization_get", paramList);

                var listTable1 = Utility.ConvertDataTable<ManningUtilizationTable1>(ds.Tables[0]);
                var listTable2 = Utility.ConvertDataTable<ManningUtilizationTable2>(ds.Tables[1]);
                var listTable3 = Utility.ConvertDataTable<ManningUtilizationTable3>(ds.Tables[2]);

                var list = new ManningUtilizationModel
                {
                    ManningUtilizationTable1 = listTable1,
                    ManningUtilizationTable2 = listTable2,
                    ManningUtilizationTable3 = listTable3
                };

                IList<ManningUtilizationModel> resultList = new List<ManningUtilizationModel>();
                resultList.Add(list);
                response.Data = resultList;
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse UpdateStdReliefDivisorOrStdQuotedWeekhours(int PlantId, int UserId, ManningUtilizationModel ManningUtilizationObj)
        {
            var response = new BaseApiResponse();

            try
            {
                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = PlantId
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var result = _repository.ExecuteSQL<int>("", plantidParam, UserIdParam).ToList();
         
                response.Success = true;
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
