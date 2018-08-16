namespace GDS.Services.Master.Material
{
    using Common;
    using Data.Repository;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MaterialService: IMaterialService
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
        private readonly IGenericRepository<MaterialModel> _repository;

        #endregion

        #region ctor


        public MaterialService(IGenericRepository<MaterialModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<MaterialModel> GetMaterialList(int MaterialId=0)
        {
            var response = new ApiResponse<MaterialModel>();

            try
            {
                var MaterialIdParam = new SqlParameter
                {
                    ParameterName = "MaterialId",
                    DbType = DbType.Int32,
                    Value =(object) MaterialId
                };

                var result = _repository.ExecuteSQL<MaterialModel>("usp_MaterialList_get", MaterialIdParam).ToList();
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


        #endregion
    }
}
