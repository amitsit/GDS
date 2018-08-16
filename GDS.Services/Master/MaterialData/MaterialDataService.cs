using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.MaterialData
{
    public class MaterialDataService : IMaterialDataService
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
        public MaterialDataService(IGenericRepository<MaterialModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<MaterialModel> GetMaterialData(int? materialTypeId, string searchFilter)
        {
            var response = new ApiResponse<MaterialModel>();
            try
            {
                object[] paramList =
                         {
                         new SqlParameter("MaterialTypeId",(object)materialTypeId ??DBNull.Value),
                         new SqlParameter("SearchFilter",(object)searchFilter ??DBNull.Value),
                     };

                var result = _repository.ExecuteSQL<MaterialModel>("usp_MaterialData_get", paramList).ToList();
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

        public BaseApiResponse InsertOrUpdateMaterial(MaterialModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
          {
                    new SqlParameter("MaterialId",(object)model.MaterialId??0),
                    new SqlParameter("SupplierName",(!string.IsNullOrWhiteSpace(model.SupplierName)? model.SupplierName:(object)DBNull.Value)),
                    new SqlParameter("MaterialCode",(!string.IsNullOrWhiteSpace(model.MaterialCode)? model.MaterialCode:(object)DBNull.Value)),
                    new SqlParameter("MaterialTypeId",(object)model.MaterialTypeId??DBNull.Value),
                    new SqlParameter("MeltLow",(object)model.MeltLow??DBNull.Value),
                    new SqlParameter("MeltHigh",(object)model.MeltHigh??DBNull.Value),
                    new SqlParameter("MoldTempLow",(object)model.MoldTempLow??DBNull.Value),
                    new SqlParameter("MoldTempHigh",(object)model.MoldTempHigh??DBNull.Value),
                    new SqlParameter("MeltFlowIndex",(object)model.MeltFlowIndex??DBNull.Value),
                    new SqlParameter("Shrinkage",(object)model.Shrinkage??DBNull.Value),
                    new SqlParameter("HDT",(object)model.HDT??DBNull.Value),
                    new SqlParameter("ThermalDiff",(object)model.ThermalDiff??DBNull.Value),
                    new SqlParameter("SpecificGravity",(object)model.SpecificGravity??DBNull.Value),
                    new SqlParameter("MaxShearRate",(object)model.MaxShearRate??DBNull.Value),
                    new SqlParameter("OptimumPeripheralSpeed",(object)model.OptimumPeripheralSpeed??DBNull.Value),
                    new SqlParameter("DensityAtProcessTemperature",(object)model.DensityAtProcessTemperature??DBNull.Value),
                    new SqlParameter("DryingTempLow",(object)model.DryingTempLow??DBNull.Value),
                    new SqlParameter("DryingTempHigh",(object)model.DryingTempHigh??DBNull.Value),
                    new SqlParameter("DryingTimeLow",(object)model.DryingTimeLow??DBNull.Value),
                    new SqlParameter("DryingTimeHigh",(object)model.DryingTimeHigh??DBNull.Value),
                    new SqlParameter("ThermalConductivityLow",(object)model.ThermalConductivityLow??DBNull.Value),
                    new SqlParameter("ThermalConductivityHigh",(object)model.ThermalConductivityHigh??DBNull.Value),
                    new SqlParameter("SpecificHeat",(object)model.SpecificHeat??DBNull.Value),
                    new SqlParameter("Density",(object)model.Density??DBNull.Value),
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId??DBNull.Value)
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_Material_InsertOrUpdate", paramList).FirstOrDefault();

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


        public BaseApiResponse DeleteMaterial(int materialId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
           {
                         new SqlParameter("MaterialId",(object)materialId),
                     };


                var result = _repository.ExecuteSQL<int>("usp_smom_Material_Delete", paramList).FirstOrDefault();
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
