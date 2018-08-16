using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.CapitalPlanBenifits;

namespace GDS.Services.STMP.MainDashboard
{
    public class MainDashboardService : IMainDashboardService
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
        private readonly IDBAccess<CapitalPlanBenifitsModel> _repositoryAdo;

        #endregion

        #region ctor

        public MainDashboardService(IDBAccess<CapitalPlanBenifitsModel> repository)
        {
            _repositoryAdo = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<DashboardPlantSelection> GetDashboardPlantSelectionData(int regionId, int UserId)
        {
            var response = new ApiResponse<DashboardPlantSelection>();

            try
            {
                SqlParameter[] paramList = { new SqlParameter("RegionId", regionId), new SqlParameter("UserId", UserId) };

                var ds = _repositoryAdo.QuerySQL("usp_stmp_GetDashboardPlantSelectionData", paramList);

                if (ds == null || ds.Tables.Count <= 0)
                    throw new Exception("No data found");
                
                response.Data = Utility.ConvertDataTable<DashboardPlantSelection>(ds.Tables[0]);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        
        public ApiResponse<CapitalPlanBenifitsModel> GetMainDashBoardData(CapitalPlanBenifitsInputModel model)
        {
            var response = new ApiResponse<CapitalPlanBenifitsModel>();

            try
            {
                SqlParameter[] paramList =
                {
                    new SqlParameter("PlantIdString",(object) model.PlantIdString ?? DBNull.Value),
                    new SqlParameter("CycleTimeSelection",(object)model.CycleTimeSelection ?? DBNull.Value),
                    new SqlParameter("OEE",(object)model.OEE ?? DBNull.Value),
                    new SqlParameter("UserId",(object)model.LoggedInUserId ?? DBNull.Value),
                    new SqlParameter("IsPlantSpecific",model.IsPlantSpecific),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("MaxUtilizationTarget",model.MaxUtilizationTarget),
                    new SqlParameter("Global_StdPerfomanceGoal",model.Global_StdPerfomanceGoal),
                    new SqlParameter("Global_AllPerformanceGoal",model.Global_AllPerformanceGoal)
                };

                var ds = _repositoryAdo.QuerySQL("usp_stmp_GetMainDashBoardData", paramList);

                if (ds == null || ds.Tables.Count <= 0)
                    throw new Exception("No data found");

                response.Success = true;
                response.Data = new List<CapitalPlanBenifitsModel>
                {
                    new CapitalPlanBenifitsModel
                    {
                        CapitalPlanTable = Utility.ConvertDataTable<CapitalPlanTable>(ds.Tables[0]),
                        CategoryStates = (ds.Tables.Count > 1) ? Utility.ConvertDataTable<CategoryStates>(ds.Tables[1]) : new List<CategoryStates>() 
                       // DashboardPlantSelection = Utility.ConvertDataTable<DashboardPlantSelection>(ds.Tables[2])
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        
        public ApiResponse<CapitalPlanBenifitsModel> GetDashboardPerformances(CapitalPlanBenifitsInputModel model)
        {
            var response = new ApiResponse<CapitalPlanBenifitsModel>();

            try
            {
                SqlParameter[] paramList =
                {
                    new SqlParameter("PlantIdString",(object) model.PlantIdString ?? DBNull.Value),
                    new SqlParameter("CycleTimeSelection",(object)model.CycleTimeSelection ?? DBNull.Value),
                    new SqlParameter("OEE",(object)model.OEE ?? DBNull.Value),
                    new SqlParameter("UserId",(object)model.LoggedInUserId ?? DBNull.Value),
                    new SqlParameter("LengthUnitId", model.LengthUnitId),
                    new SqlParameter("PressureUnitId",model.PressureUnitId),
                    new SqlParameter("IsPlantSpecific",model.IsPlantSpecific),
                    new SqlParameter("WeekString",model.WeekString),
                    new SqlParameter("Global_StdPerfomanceGoal",(object)model.Global_StdPerfomanceGoal?? DBNull.Value),
                    new SqlParameter("Global_AllPerformanceGoal",(object)model.Global_AllPerformanceGoal?? DBNull.Value)
                };

                var ds = _repositoryAdo.QuerySQL("usp_stmp_GetDashboardPerformances", paramList);

                if (ds == null || ds.Tables.Count <= 0)
                    throw new Exception("No data found");

                response.Success = true;
                response.Data = new List<CapitalPlanBenifitsModel>
                {
                    new CapitalPlanBenifitsModel
                    {
                        CapitalPlanTable = Utility.ConvertDataTable<CapitalPlanTable>(ds.Tables[0]),
                        CategoryStates = (ds.Tables.Count > 1) ? Utility.ConvertDataTable<CategoryStates>(ds.Tables[1]) : new List<CategoryStates>() 
                       // DashboardPlantSelection = Utility.ConvertDataTable<DashboardPlantSelection>(ds.Tables[2])
                    }
                };
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
