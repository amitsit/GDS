using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.PartAndMoldTemperatureMapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GDS.Services.SMOM.PartAndMoldTemperatureMapping
{
    public class PartAndMoldTemperatureMappingService : IPartAndMoldTemperatureMappingService
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
        private readonly IGenericRepository<PartAndMoldTemperatureMapModel> _repository;
        private readonly IGenericRepository<PartAndMoldTemperatureModel> _repositoryDetails;

        #endregion

        #region ctor

        public PartAndMoldTemperatureMappingService(IGenericRepository<PartAndMoldTemperatureMapModel> repository, IGenericRepository<PartAndMoldTemperatureModel> repositoryDetail)
        {
            _repository = repository;
            _repositoryDetails = repositoryDetail;
        }

        #endregion

        public ApiResponse<PartAndMoldTemperatureMapModel> GetPartAndMoldTemperatureMap(int coverPageId, short lengthUnitId,bool IsDOEData = false)
        {
            var response = new ApiResponse<PartAndMoldTemperatureMapModel>();

            try
            {
                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = coverPageId
                };

                var lengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };

                var IsDOEDataParam = new SqlParameter
                {
                    ParameterName = "IsDOEData",
                    DbType = DbType.Boolean,
                    Value = IsDOEData
                };

                var result = _repository.ExecuteSQL<PartAndMoldTemperatureModel>("usp_smom_PartAndMoldTemperature_get", lengthUnitIdParam, coverPageIdParam, IsDOEDataParam).ToList();
                var partAndMoldTemperatureModel = result.FirstOrDefault();

                PartAndMoldTemperatureMapModel objPartAndMoldTemperatureMapModel = new PartAndMoldTemperatureMapModel();
                if (partAndMoldTemperatureModel != null)
                {
                    var list = new List<PartAndMoldTemperatureMapModel>
                    {
                        new PartAndMoldTemperatureMapModel
                        {
                            PartAndMoldTemperatureMapId = partAndMoldTemperatureModel.PartAndMoldTemperatureMapId,
                            Notes = partAndMoldTemperatureModel.Notes,
                            PartAndMoldTemperatureDetail = result
                        }

                    };

                    response.Success = true;
                    response.Data = list;
                }
                else
                {
                    List<PartAndMoldTemperatureMapModel> lstMapModel = new List<PartAndMoldTemperatureMapModel>();
                    objPartAndMoldTemperatureMapModel.PartAndMoldTemperatureDetail = new List<PartAndMoldTemperatureModel>();
                    objPartAndMoldTemperatureMapModel.PartAndMoldTemperatureDetail.Add(new PartAndMoldTemperatureModel());
                    lstMapModel.Add(objPartAndMoldTemperatureMapModel);

                    response.Success = true;
                    response.Data = lstMapModel;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<PartAndMoldTemperatureModel> GetPartAndMoldTemperature(int PartAndMoldTemperatureMapId)
        {
            var response = new ApiResponse<PartAndMoldTemperatureModel>();

            try
            {
                var partAndMoldTemperatureMapIdParam = new SqlParameter
                {
                    ParameterName = "PartAndMoldTemperatureMapId",
                    DbType = DbType.Int32,
                    Value = PartAndMoldTemperatureMapId
                };

                var result = _repository.ExecuteSQL<PartAndMoldTemperatureModel>("usp_smom_PartAndMoldTemperature_get", partAndMoldTemperatureMapIdParam).ToList();
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

        public BaseApiResponse AddOrUpdatePartAndMoldTemperatureMapData(int UserId, short lengthUnitId, int coverPageId, PartAndMoldTemperatureMapModel PartAndMoldObj)
        {
            var response = new BaseApiResponse();

            DataTable PartAndMoldTemperature = new DataTable("PartAndMoldTemperatureList");
            PartAndMoldTemperature.Columns.Add("Type");
            PartAndMoldTemperature.Columns.Add("Description1");
            PartAndMoldTemperature.Columns.Add("Description2");
            PartAndMoldTemperature.Columns.Add("Description3");
            PartAndMoldTemperature.Columns.Add("Description4");
            PartAndMoldTemperature.Columns.Add("Temperature1");
            PartAndMoldTemperature.Columns.Add("Temperature2");
            PartAndMoldTemperature.Columns.Add("Temperature3");
            PartAndMoldTemperature.Columns.Add("Temperature4");
            PartAndMoldTemperature.Columns.Add("Temperature5");
            PartAndMoldTemperature.Columns.Add("Temperature6");


            foreach (var item in PartAndMoldObj.PartAndMoldTemperatureDetail)
            {
                DataRow dtRow = PartAndMoldTemperature.NewRow();

                dtRow["Type"] = (object)item.Type ?? DBNull.Value;
                dtRow["Description1"] = (object)item.Description1 ?? DBNull.Value;
                dtRow["Description2"] = (object)item.Description2 ?? DBNull.Value;
                dtRow["Description3"] = (object)item.Description3 ?? DBNull.Value;
                dtRow["Description4"] = (object)item.Description4 ?? DBNull.Value;
                dtRow["Temperature1"] = (object)item.Temperature1 ?? DBNull.Value;
                dtRow["Temperature2"] = (object)item.Temperature2 ?? DBNull.Value;
                dtRow["Temperature3"] = (object)item.Temperature3 ?? DBNull.Value;
                dtRow["Temperature4"] = (object)item.Temperature4 ?? DBNull.Value;
                dtRow["Temperature5"] = (object)item.Temperature5 ?? DBNull.Value;
                dtRow["Temperature6"] = (object)item.Temperature6 ?? DBNull.Value;

                PartAndMoldTemperature.Rows.Add(dtRow);
            }

            try
            {
                //var PartAndMoldTemperatureMapIdParam = new SqlParameter
                //{
                //    ParameterName = "PartAndMoldTemperatureMapId",
                //    DbType = DbType.Int32,
                //    Value = PartAndMoldObj.PartAndMoldTemperatureMapId
                //};

                var DateParam = new SqlParameter
                {
                    ParameterName = "Date",
                    DbType = DbType.DateTime,
                    Value = (object)PartAndMoldObj.Date ?? DBNull.Value
                };

                var NotesParam = new SqlParameter
                {
                    ParameterName = "Notes",
                    DbType = DbType.String,
                    Value = (object)PartAndMoldObj.Notes ?? DBNull.Value
                };

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = coverPageId
                };

                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var lengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };

                var PartAndMoldTemperatureListParam = new SqlParameter
                {
                    ParameterName = "PartAndMoldTemperatureList",
                    SqlDbType = SqlDbType.Structured,
                    Value = PartAndMoldTemperature,
                    TypeName = "dbo.PartAndMoldTemperatureList"
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_PartAndMoldTemperatureMap_save", DateParam, NotesParam
                                                    , coverPageIdParam, LoggedInUserIdParam, lengthUnitIdParam
                                                    , PartAndMoldTemperatureListParam).FirstOrDefault();

                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        public BaseApiResponse DeletePartAndMoldTemperatureMapData(int PartAndMoldTemperatureMapId)
        {
            var response = new BaseApiResponse();

            try
            {
                var PartAndMoldTemperatureMapIdParam = new SqlParameter
                {
                    ParameterName = "p_PartAndMoldTemperatureMapId",
                    DbType = DbType.Int32,
                    Value = PartAndMoldTemperatureMapId
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_PartAndMoldTemperatureMap_delete", PartAndMoldTemperatureMapIdParam).FirstOrDefault();
                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse AddOrUpdatePartMoldTemperatureMapData(int LoggedInUserId, short lengthUnitId, PartAndMoldTemperatureMapModel PartAndMoldObj)
        {
            var response = new BaseApiResponse();

            DataTable PartAndMoldTemperature = new DataTable("PartAndMoldTemperatureList");
            PartAndMoldTemperature.Columns.Add("Type");
            PartAndMoldTemperature.Columns.Add("Description1");
            PartAndMoldTemperature.Columns.Add("Description2");
            PartAndMoldTemperature.Columns.Add("Description3");
            PartAndMoldTemperature.Columns.Add("Description4");
            PartAndMoldTemperature.Columns.Add("Temperature1");
            PartAndMoldTemperature.Columns.Add("Temperature2");
            PartAndMoldTemperature.Columns.Add("Temperature3");
            PartAndMoldTemperature.Columns.Add("Temperature4");
            PartAndMoldTemperature.Columns.Add("Temperature5");
            PartAndMoldTemperature.Columns.Add("Temperature6");


            foreach (var item in PartAndMoldObj.PartAndMoldTemperatureDetail)
            {
                DataRow dtRow = PartAndMoldTemperature.NewRow();

                dtRow["Type"] = (object)item.Type ?? DBNull.Value;
                dtRow["Description1"] = (object)item.Description1 ?? DBNull.Value;
                dtRow["Description2"] = (object)item.Description2 ?? DBNull.Value;
                dtRow["Description3"] = (object)item.Description3 ?? DBNull.Value;
                dtRow["Description4"] = (object)item.Description4 ?? DBNull.Value;
                dtRow["Temperature1"] = (object)item.Temperature1 ?? DBNull.Value;
                dtRow["Temperature2"] = (object)item.Temperature2 ?? DBNull.Value;
                dtRow["Temperature3"] = (object)item.Temperature3 ?? DBNull.Value;
                dtRow["Temperature4"] = (object)item.Temperature4 ?? DBNull.Value;
                dtRow["Temperature5"] = (object)item.Temperature5 ?? DBNull.Value;
                dtRow["Temperature6"] = (object)item.Temperature6 ?? DBNull.Value;

                PartAndMoldTemperature.Rows.Add(dtRow);
            }

            try
            {
                var DateParam = new SqlParameter
                {
                    ParameterName = "Date",
                    DbType = DbType.DateTime,
                    Value = (object)PartAndMoldObj.Date ?? DBNull.Value
                };

                var NotesParam = new SqlParameter
                {
                    ParameterName = "Notes",
                    DbType = DbType.String,
                    Value = (object)PartAndMoldObj.Notes ?? DBNull.Value
                };

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = PartAndMoldObj.CoverPageId
                };

                var LoggedInUserIdParam = new SqlParameter
                {
                    ParameterName = "LoggedInUserId",
                    DbType = DbType.Int32,
                    Value = LoggedInUserId
                };

                var lengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = lengthUnitId
                };

                var MoldTemperatureDataPartHtmlContentParam = new SqlParameter
                {
                    ParameterName = "MoldTemperatureDataPartHtmlContent",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(PartAndMoldObj.MoldTemperatureDataPartHtmlContent) ? (object)PartAndMoldObj.MoldTemperatureDataPartHtmlContent : DBNull.Value
                };

                var MoldTempratureDataPartImagePathParam = new SqlParameter
                {
                    ParameterName = "MoldTempratureDataPartImagePath",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(PartAndMoldObj.MoldTempratureDataPartImagePath) ? (object)PartAndMoldObj.MoldTempratureDataPartImagePath : DBNull.Value
                };

                var MoldTemperatureDataPartTitleParam = new SqlParameter
                {
                    ParameterName = "MoldTemperatureDataPartTitle",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(PartAndMoldObj.MoldTemperatureDataPartTitle) ? (object)PartAndMoldObj.MoldTemperatureDataPartTitle: DBNull.Value
                };
                                                                        

                var PartAndMoldTemperatureListParam = new SqlParameter
                {
                    ParameterName = "PartAndMoldTemperatureList",
                    SqlDbType = SqlDbType.Structured,
                    Value = PartAndMoldTemperature,
                    TypeName = "dbo.PartAndMoldTemperatureList"
                };

                var IsDOEDataParam = new SqlParameter
                {
                    ParameterName = "IsDOEData",
                    SqlDbType = SqlDbType.Bit,
                    Value = PartAndMoldObj.IsDOEData,
                    
                };

                //@IsDOEData

                var result = _repository.ExecuteSQL<int>("usp_smom_PartMoldTemperatureMap_save",
                                                     DateParam
                                                    , NotesParam
                                                    , coverPageIdParam, LoggedInUserIdParam, lengthUnitIdParam
                                                    , MoldTemperatureDataPartHtmlContentParam
                                                    , MoldTempratureDataPartImagePathParam
                                                    , MoldTemperatureDataPartTitleParam
                                                    , PartAndMoldTemperatureListParam
                                                    , IsDOEDataParam
                                                    ).FirstOrDefault();
                response.Success = result > 0;

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
    }
}
