using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.SMOM.CorpIMPD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.CorpIMPD
{
    public class CorpIMPDService : ICorpIMPDService
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
        private readonly IGenericRepository<CorpIMPDModel> _repository;

        #endregion

        #region ctor


        public CorpIMPDService(IGenericRepository<CorpIMPDModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<MaterialModel> GetCorpIMPDMaterialData(int MaterialTypeId)
        {
            var response = new ApiResponse<MaterialModel>();

            try
            {
                object[] paramList =
               {
                    new SqlParameter("MaterialTypeId",(object)MaterialTypeId),
                };

                var result = _repository.ExecuteSQL<MaterialModel>("usp_smom_CorpIMPD_MaterialData_get", paramList).ToList();
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


        public BaseApiResponse InsertOrUpdateCorpIMPD(CorpIMPDModel model)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
            {
                    new SqlParameter("MachineInformationId",(object)model.MachineInformationId),
                    new SqlParameter("CoverPageId",(object)model.CoverPageId),
                    new SqlParameter("MoldNumber",(object)model.MoldNumber??DBNull.Value),
                    new SqlParameter("PartDescription",(object)model.PartDescription??DBNull.Value),
                    new SqlParameter("PlantId",(object)model.PlantId??DBNull.Value),
                    new SqlParameter("PressNumber",(object)model.PressNumber??DBNull.Value),
                    new SqlParameter("MaterialTypeId",(object)model.MaterialTypeId),
                    new SqlParameter("NominalWallThickness",(object)model.NominalWallThickness??DBNull.Value),
                    new SqlParameter("GateWidth",(object)model.GateWidth??DBNull.Value),
                    new SqlParameter("GateDepth",(object)model.GateDepth??DBNull.Value),
                    new SqlParameter("GateLand",(object)model.GateLand??DBNull.Value),
                    new SqlParameter("GateDiameter",(object)model.GateDiameter??DBNull.Value),
                    new SqlParameter("NoOfHotRunnerZones",(object)model.NoOfHotRunnerZones??DBNull.Value),
                    new SqlParameter("HotRunnerTempSetPoint",(object)model.HotRunnerTempSetPoint??DBNull.Value),
                    new SqlParameter("NoOfValveGates",(object)model.NoOfValveGates??DBNull.Value),
                    new SqlParameter("IACMoldNumber",(object)model.IACMoldNumber??DBNull.Value),
                    new SqlParameter("NoOfCavities",(object)model.NoOfCavities??DBNull.Value),
                    new SqlParameter("NoOfGatesorCavity",(object)model.NoOfGatesorCavity??DBNull.Value),
                    new SqlParameter("NozzleLength",(object)model.NozzleLength??DBNull.Value),
                    new SqlParameter("NozzleOrifice",(object)model.NozzleOrifice??DBNull.Value),
                    new SqlParameter("ThermolatorStationary",(object)model.ThermolatorStationary??DBNull.Value),
                    new SqlParameter("ThermolatorMoving",(object)model.ThermolatorMoving??DBNull.Value),
                    new SqlParameter("ThermolatorSpeakerOrLifter",(object)model.ThermolatorSpeakerOrLifter??DBNull.Value),
                    new SqlParameter("TonnageSetPoint",(object)model.TonnageSetPoint??DBNull.Value),
                    new SqlParameter("LoggedInUserId",(object)model.LoggedInUserId??DBNull.Value)
                };

                var result = _repository.ExecuteSQL<long>("usp_smom_CorpIMPD_save", paramList).FirstOrDefault();
                response.Success = true;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }


        public ApiResponse<CorpIMPDModel> GetCorpIMPDDetail(int CoverPageId)
        {
            var response = new ApiResponse<CorpIMPDModel>();

            try
            {
                object[] paramList =
               {
                    new SqlParameter("CoverPageId",(object)CoverPageId),
                };

                var result = _repository.ExecuteSQL<CorpIMPDModel>("usp_smom_CorpIMPD_get", paramList).ToList();
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
