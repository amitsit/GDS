using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;

namespace GDS.Services.Master.MaterialType
{
    public class MaterialTypeService : IMaterialTypeService
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
        private readonly IGenericRepository<MaterialTypeMasterModel> _repository;
        
        #endregion

        #region ctor

        
        public MaterialTypeService(IGenericRepository<MaterialTypeMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<MaterialTypeMasterModel> GetMaterialType(int? materialTypeId)
        {
            var response = new ApiResponse<MaterialTypeMasterModel>();

            try
            {
                var materialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = (object)materialTypeId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<MaterialTypeMasterModel>("usp_MaterialTypeMaster_GetMaterialType", materialTypeIdParam).ToList();
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
        
        public BaseApiResponse SaveMaterialType(MaterialTypeMasterModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters

                var materialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = model.MaterialTypeId
                };

                var materialTypeCodeParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeCode",
                    DbType = DbType.String,
                    Value = model.MaterialTypeCode
                };

                var MaterialTypeDescriptionParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeDescription",
                    DbType = DbType.String,
                    Value = model.MaterialTypeDescription
                };

                var isActiveParam = new SqlParameter
                {
                    ParameterName = "IsActive",
                    DbType = DbType.Boolean,
                    Value = model.IsActive
                };

                var loggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = model.LoggedInUserId
                };

                #endregion

                var result = _repository.ExecuteSQL<int>("usp_MaterialTypeMaster_SaveMaterialType"
                            , materialTypeIdParam, materialTypeCodeParam, MaterialTypeDescriptionParam, isActiveParam, loggedInUserIdParam).FirstOrDefault();

                response.Success = result > 0;
                response.InsertedId = result;
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

        public BaseApiResponse DeleteMaterialType(int materialTypeId)
        {
            var response = new BaseApiResponse();

            try
            {
                var materialTypeIdParam = new SqlParameter
                {
                    ParameterName = "MaterialTypeId",
                    DbType = DbType.Int32,
                    Value = materialTypeId
                };

                var result = _repository.ExecuteSQL<int>("usp_MaterialTypeMaster_DeleteMaterialType", materialTypeIdParam).FirstOrDefault();
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

        #endregion
    }
}