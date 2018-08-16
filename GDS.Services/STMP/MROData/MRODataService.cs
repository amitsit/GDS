using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.STMP.MROData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.STMP.MROData
{
    public class MRODataService : IMRODataService
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
        private readonly IGenericRepository<MRODataModel> _repository;

        #endregion


        #region constructor
        public MRODataService(IGenericRepository<MRODataModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        #region Get MRO Data

        public ApiResponse<MRODataModel> GetMROData(int PlantId)
        {
            var response = new ApiResponse<MRODataModel>();

            MRODataModel mRODataModel = new MRODataModel();
            IList<MRODataModel> list = new List<MRODataModel>();
            try
            {

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId
                };

                var result = _repository.ExecuteSQL<MRODataList>("usp_stmp_MROData_get", PlantIdParam).ToList();
                mRODataModel.MRODataList = result;
                list.Add(mRODataModel);
                response.Success = true;
                response.Data = list;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion

        #region Save MRO Data

        public BaseApiResponse SaveMROData(MRODataModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                string MRODataXML = GDS.Common.ConvertToXml<MRODataList>.GetXMLString(model.MRODataList);

                var MRODataXMLDataModelCollectionXMLParam = new SqlParameter
                {
                    ParameterName = "MRODataModelCollectionXML",

                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(MRODataXML) ? MRODataXML : (object)DBNull.Value
                };

                var CreatedByParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = (object)model.LoggedInUserId
                };

                var PlantIdParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)model.PlantId
                };

                var result = _repository.ExecuteSQL<long>("usp_stmp_MROData_Save", MRODataXMLDataModelCollectionXMLParam, CreatedByParam, PlantIdParam).FirstOrDefault();
                response.lng_InsertedId = result;
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

        #endregion
    }
}
