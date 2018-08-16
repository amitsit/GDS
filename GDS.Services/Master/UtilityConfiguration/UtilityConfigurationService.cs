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

namespace GDS.Services.Master.UtilityConfiguration
{
    public class UtilityConfigurationService : IUtilityConfigurationService
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
        private readonly IGenericRepository<UtilityConfigurationModel> _repository;

        #endregion

        #region ctor


        public UtilityConfigurationService(IGenericRepository<UtilityConfigurationModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<UtilityConfigurationModel> GetPlantConfigurationDetail(int PlantId )
        {
            var response = new ApiResponse<UtilityConfigurationModel>();

            try
            {
                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId
                };

                var result = _repository.ExecuteSQL<UtilityConfigurationModel>("usp_mst_UtilityPlantList_get", PlantIdParam).ToList();
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

        public BaseApiResponse UpdatePlantConfiguration(int UserId, List<UtilityConfigurationModel> UtilityPlantDataCollection)
        {
            var response = new BaseApiResponse();

            try
            {
                string getxmlstr = GDS.Common.ConvertToXml<UtilityConfigurationModel>.GetXMLString(UtilityPlantDataCollection);

                var UtilityPlantDataCollectionXML = new SqlParameter
                {
                    ParameterName = "UtilityPlantDataCollection",
                    DbType = DbType.String,
                    Value = getxmlstr
                };
               
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int16,
                    Value = (object)UserId
                };
                
                var result = _repository.ExecuteSQL<int>("[usp_mst_UtilityPlant_Update]", UtilityPlantDataCollectionXML,UserIdParam).FirstOrDefault();
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
