

namespace GDS.Services.Master.TLNSavingReport
{
    using Common;
    using Data.Repository;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;


    public class TLNSavingReportService : ITLNSavingReportService
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
        private readonly IGenericRepository<TLNSavingReportMasterModel> _repository;

        #endregion

        #region ctor


        public TLNSavingReportService(IGenericRepository<TLNSavingReportMasterModel> repository)
        {
            _repository = repository;
        }

        public ApiResponse<TLNSavingReportMasterModel> GetTLNSavingReportDetail(int TLNSavingReportingId)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<TLNSavingReportMasterModel> GetTLNSavingReportList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        public ApiResponse<TLNSavingReportMasterModel> GetTLNSavingReportData(int PlantId, int YearNumber)
        {
            var response = new ApiResponse<TLNSavingReportMasterModel>();

            try
            {
                var inputPlantId = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int32,
                    Value = (object)PlantId ?? DBNull.Value
                };

                var yearnumberParam = new SqlParameter
                {
                    ParameterName = "YearNumber",
                    DbType = DbType.Int32,
                    Value = YearNumber
                };


                var result = _repository.ExecuteSQL<TLNSavingReportMasterModel>("usp_stmp_TLNSavingReport_get", inputPlantId, yearnumberParam).ToList();
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




        public BaseApiResponse SaveTLNSavingReportData(List<TLNSavingReportMasterModel> TLNSavingReportDataCollection, int PlantId, int YearNumber, int CreatedBy)
        {
            var response = new BaseApiResponse();

            try
            {
                #region Parameters
                string getxmlstr = GDS.Common.ConvertToXml<TLNSavingReportMasterModel>.GetXMLString(TLNSavingReportDataCollection);

                var TLNSavingReportDataCollectionXML = new SqlParameter
                {
                    ParameterName = "TLNSavingReportDataCollection",
                    DbType = DbType.String,
                    Value = getxmlstr
                };

                var plantidParam = new SqlParameter
                {
                    ParameterName = "PlantId",
                    DbType = DbType.Int16,
                    Value = PlantId
                };

                var yearnumberParam = new SqlParameter
                {
                    ParameterName = "YearNumber",
                    DbType = DbType.Int32,
                    Value = YearNumber
                };

                var createdbyparam = new SqlParameter
                {
                    ParameterName = "CreatedBy",
                    DbType = DbType.Int16,
                    Value = CreatedBy
                };


                #endregion

                var result = _repository.ExecuteSQL<int>("usp_stmp_TLNSavingReport_insert", TLNSavingReportDataCollectionXML, plantidParam, yearnumberParam, createdbyparam).FirstOrDefault();
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











