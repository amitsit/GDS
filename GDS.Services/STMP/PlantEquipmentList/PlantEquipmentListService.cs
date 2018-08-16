namespace GDS.Services.STMP.PlantEquipmentList
{
    using GDS.Entities.STMP.PlantEquipmentList;
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using Common;
    using Entities;
    using Data.Repository;
    using System.IO;
    using System.Collections.Generic;
    using System.Data;

    public class PlantEquipmentListService : IPlantEquipmentListService
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
        private readonly IGenericRepository<STMPPlantEquipmentListModel> _repository;

        #endregion

        #region ctor


        public PlantEquipmentListService(IGenericRepository<STMPPlantEquipmentListModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public BaseApiResponse InsertPlanEquipmentListMaster(DataTable dtPlantEquipmentList)
        {
            var response = new BaseApiResponse();
            try
            {
                var ut_PlantEquipmentListParam = new SqlParameter
                {
                    ParameterName = "ut_PlantEquipmentList",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.ut_PlantEquipmentList",
                    Value = dtPlantEquipmentList
                };
                var result = _repository.ExecuteSQL<int>("usp_stmp_PlantEquipmentListMaster_insert", ut_PlantEquipmentListParam).ToList();
                var id = result.FirstOrDefault();

                if (result != null && result.Any())
                {
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse InsertPlanEquipmentList(int plantId)
        {
            var response = new ApiResponse<STMPPlantEquipmentListModel>();

            try
            {
                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };

                var result = _repository.ExecuteSQL<STMPPlantEquipmentListModel>("usp_stmp_PlantEquipmentList_insert", plantidParam).ToList();

                response.Data = result.ToList();
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

        public BaseApiResponse InsertPlanEquipmentListMaster(int UserId, List<STMPPlantEquipmentListMasterModel> dataObjects)
        {
            var response = new BaseApiResponse();

            try
            {
                var PlantEquipmentTableParam = new SqlParameter
                {
                    ParameterName = "ut_PlantEquipmentList",
                    SqlDbType = SqlDbType.Structured,
                    Value = (object)dataObjects.AsEnumerable<STMPPlantEquipmentListMasterModel>() ?? (object)DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    SqlDbType = SqlDbType.Int,
                    Value = UserId
                };



                var result = _repository.ExecuteSQL<int>("usp_stmp_PlantEquipmentList_insertFromFile", PlantEquipmentTableParam, UserIdParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<STMPPlantEquipmentListModel> GetPlantEquipmentList(int? plantId,long? plantEquipmentListId)
        {
            var response = new ApiResponse<STMPPlantEquipmentListModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId",(object)plantId ?? DBNull.Value),
                    new SqlParameter("PlantEquipmentListId",(object)plantEquipmentListId?? DBNull.Value)
                };
                
                var result = _repository.ExecuteSQL<STMPPlantEquipmentListModel>("usp_stmp_PlantEquipmentList_get", paramList).ToList();

                response.Data = result.ToList();
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

        /// <summary>
        /// Viram Keshwala
        /// 12 JAN 2018
        /// Gets the Plant equipment list for dropdown
        /// </summary>
        /// <param name="plantId"></param>
        /// <param name="bicVerificationDocumentId"></param>
        /// <param name="coverPageId"></param>
        /// <returns></returns>
        public ApiResponse<PlantEquipmentForDDLModel> GetPlantEquipmentListForDDL(int plantId, long bicVerificationDocumentId, long coverPageId)
        {
            var response = new ApiResponse<PlantEquipmentForDDLModel>();

            try
            {
                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = plantId
                };

                var bicVerificationDocumentIdParam = new SqlParameter
                {
                    ParameterName = "BICVerificationDocumentId",
                    DbType = DbType.Int64,
                    Value = bicVerificationDocumentId
                };

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = coverPageId
                };


                response.Data = _repository.ExecuteSQL<PlantEquipmentForDDLModel>(
                                "usp_stmp_usp_stmp_PlantEquipmentList_GetPlantEquipmentListForDDL",
                                plantidParam, bicVerificationDocumentIdParam, coverPageIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse UploadPlantEquipmentFile(DataTable dtResult, int UserId)
        {
            var response = new BaseApiResponse();

            try
            {
                var PlantEquipmentTableParam = new SqlParameter
                {
                    ParameterName = "ut_PlantEquipment",
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.ut_PlantEquipmentList",
                    Value = (object)dtResult ?? (object)DBNull.Value
                };

                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    SqlDbType = SqlDbType.Int,
                    Value = UserId
                };



                var result = _repository.ExecuteSQL<int>("usp_stmp_PlantEquipmentList_insertFromFile", PlantEquipmentTableParam, UserIdParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public BaseApiResponse InsertOrUpdatePlantEquipmentList(PlantEquipmentMasterModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
          {
                    new SqlParameter("PlantEquipmentListId",(object)model.PlantEquipmentListId??0),
                    new SqlParameter("PlantId",(object)model.PlantId??DBNull.Value),
                    new SqlParameter("PressNumber",(!string.IsNullOrWhiteSpace(model.PressNumber)?model.PressNumber:(object)DBNull.Value)),
                    new SqlParameter("PressManufacturer",(!string.IsNullOrWhiteSpace(model.PressManufacturer)?model.PressManufacturer:(object)DBNull.Value)),
                    new SqlParameter("PressModel",(!string.IsNullOrWhiteSpace(model.PressModel)?model.PressModel:(object)DBNull.Value)),
                    new SqlParameter("PressSerial",(!string.IsNullOrWhiteSpace(model.PressSerial)?model.PressSerial:(object)DBNull.Value)),
                    new SqlParameter("Tonnage",(object)model.Tonnage??DBNull.Value),
                    new SqlParameter("PressYear",(!string.IsNullOrWhiteSpace(model.PressYear)?model.PressYear:(object)DBNull.Value)),
                    new SqlParameter("MaxPressure_PSI",(!string.IsNullOrWhiteSpace(model.MaxPressure_PSI)?model.MaxPressure_PSI:(object)DBNull.Value)),
                    new SqlParameter("Intensification",(!string.IsNullOrWhiteSpace(model.Intensification)?model.Intensification:(object)DBNull.Value)),
                    new SqlParameter("BarrelCapacity_OZ",(!string.IsNullOrWhiteSpace(model.BarrelCapacity_OZ)?model.BarrelCapacity_OZ:(object)DBNull.Value)),
                    new SqlParameter("ScrewDiameter_IN",(!string.IsNullOrWhiteSpace(model.ScrewDiameter_IN)?model.ScrewDiameter_IN:(object)DBNull.Value)),
                    new SqlParameter("MaxInjectionStroke_IN",(!string.IsNullOrWhiteSpace(model.MaxInjectionStroke_IN)?model.MaxInjectionStroke_IN:(object)DBNull.Value)),
                    new SqlParameter("MaxInjectionSpeed_IN",(!string.IsNullOrWhiteSpace(model.MaxInjectionSpeed_IN)? model.MaxInjectionSpeed_IN:(object)DBNull.Value)),
                    new SqlParameter("TieBarHorizontal",(!string.IsNullOrWhiteSpace(model.TieBarHorizontal)? model.TieBarHorizontal:(object)DBNull.Value)),
                    new SqlParameter("TieBarVertical",(!string.IsNullOrWhiteSpace(model.TieBarVertical)? model.TieBarVertical:(object)DBNull.Value)),
                    new SqlParameter("PlatenHXV",(!string.IsNullOrWhiteSpace(model.PlatenHXV)? model.PlatenHXV:(object)DBNull.Value)),                   
                    new SqlParameter("DieHeight",(!string.IsNullOrWhiteSpace(model.DieHeight)? model.DieHeight:(object)DBNull.Value)),
                    new SqlParameter("DayLight",(!string.IsNullOrWhiteSpace(model.DayLight)? model.DayLight:(object)DBNull.Value)),
                    new SqlParameter("ClampStyle",(!string.IsNullOrWhiteSpace(model.ClampStyle)? model.ClampStyle:(object)DBNull.Value)),
                    new SqlParameter("Robot",(!string.IsNullOrWhiteSpace(model.Robot)? model.Robot:(object)DBNull.Value)),
                    new SqlParameter("RobotYear",(!string.IsNullOrWhiteSpace(model.RobotYear)? model.RobotYear:(object)DBNull.Value)),
                    new SqlParameter("RobotModel",(!string.IsNullOrWhiteSpace(model.RobotModel)? model.RobotModel:(object)DBNull.Value)),
                    new SqlParameter("RobotSerial",(!string.IsNullOrWhiteSpace(model.RobotSerial)? model.RobotSerial:(object)DBNull.Value)),
                    new SqlParameter("QMCMethod",(!string.IsNullOrWhiteSpace(model.QMCMethod)? model.QMCMethod:(object)DBNull.Value)),
                    new SqlParameter("ShopLogixPressNumber",(!string.IsNullOrWhiteSpace(model.ShopLogixPressNumber)? model.ShopLogixPressNumber:(object)DBNull.Value)),
                    new SqlParameter("IsActiveInAMP",(object)model.IsActiveInAMP??DBNull.Value),
                  
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId??DBNull.Value)
                };

                var result = _repository.ExecuteSQL<long>("usp_stmp_PlantEquipmentList_InsertOrUpdate", paramList).FirstOrDefault();

                response.Success = result > 0;
                response.lng_InsertedId = result;
                if (!response.Success)
                    response.Message.Add(result == -1 ? "Duplicate entry." : "Could not save.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeletePlantEquipment(int PlantEquipmentListId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
           {
                         new SqlParameter("PlantEquipmentListId",(object)PlantEquipmentListId),
                     };


                var result = _repository.ExecuteSQL<int>("usp_stmp_PlantEquipment_Delete", paramList).FirstOrDefault();
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
        
        public ApiResponse<PlantEquipmentMasterModel> GetPlantEquipmentServerPagination(int plantId, int pageIndex, int pageSize,string SearchColumnName , string searchFor, string orderByColumn, bool orderByAscDirection)
        {
            var response = new ApiResponse<PlantEquipmentMasterModel>();

            try
            {
                object[] paramList =
            {
                         new SqlParameter("PlantId",(object)plantId),
                         new SqlParameter("PageIndex",(object)pageIndex),
                         new SqlParameter("PageSize",(object)pageSize),
                         new SqlParameter("SearchColumnName",!string.IsNullOrWhiteSpace(SearchColumnName) ?SearchColumnName:(object)DBNull.Value),
                         new SqlParameter("SearchFor",!string.IsNullOrWhiteSpace(searchFor) ?searchFor:(object)DBNull.Value),
                         new SqlParameter("OrderByColumn",!string.IsNullOrWhiteSpace(orderByColumn) ?orderByColumn:(object)DBNull.Value),
                         new SqlParameter("OrderByDirection",orderByAscDirection),
                     };

                var result = _repository.ExecuteSQL<PlantEquipmentMasterModel>("usp_stmp_GetPlantEquipmentServerPagination_get", paramList).ToList();

                response.Data = result.ToList();
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


        public ApiResponse<PlantEquipmentColumnListModel> GetPlantEquipmentColumnList()
        {
            var response = new ApiResponse<PlantEquipmentColumnListModel>();

            try
            {
                var result = _repository.ExecuteSQL<PlantEquipmentColumnListModel>("usp_stmp_PlantEquipmentList_GetColumnList").ToList();

                response.Data = result.ToList();
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
