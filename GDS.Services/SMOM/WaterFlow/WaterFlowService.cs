using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.WaterFlow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Services.SMOM.WaterFlow
{
    public class WaterFlowService : IWaterFlowService
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
        private readonly IGenericRepository<WaterFlowMasterModel> _repository;

        #endregion

        #region ctor


        public WaterFlowService(IGenericRepository<WaterFlowMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<WaterFlowMasterModel> GetWaterFlowDetail(int CoverPageId, Int16 LengthUnitId, Int16 PressureUnitId)
        {
            var response = new ApiResponse<WaterFlowMasterModel>();
            List<WaterFlowMasterModel> result = new List<WaterFlowMasterModel>();

            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = (object)CoverPageId
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)LengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)PressureUnitId
                };

                result = _repository.ExecuteSQL<WaterFlowMasterModel>("usp_smom_WaterFlow_get", CoverPageIdParam, LengthUnitIdParam, PressureUnitIdParam).ToList();
                if (result.Count == 0)
                {
                    WaterFlowMasterModel WaterFlowMasterObj = new WaterFlowMasterModel();
                    WaterFlowMasterObj.CoverPageId = CoverPageId;
                    result.Add(WaterFlowMasterObj);
                }
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

        public ApiResponse<WaterMinuteDataModel> GetWaterFlowMinuteDataDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId)
        {
            var response = new ApiResponse<WaterMinuteDataModel>();
            List<WaterMinuteDataModel> result = new List<WaterMinuteDataModel>();
            try
            {
                var WaterFlowIdParam = new SqlParameter
                {
                    ParameterName = "WaterFlowId",
                    DbType = DbType.Int32,
                    Value = (object)WaterFlowId
                };


                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)LengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)PressureUnitId
                };

                result = _repository.ExecuteSQL<WaterMinuteDataModel>("usp_smom_WaterFlowMinuteData_Get", WaterFlowIdParam, LengthUnitIdParam, PressureUnitIdParam).ToList();
                if (result.Count == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        // loop assign TypeId like Fixed Half,Moving Half,Special
                        result.Add(new WaterMinuteDataModel() { TypeId = (i + 1) });
                    }
                }
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

        public BaseApiResponse SaveWaterFlowDetail(WaterFlowMasterModel model, int CreatedBy, Int16 LengthUnitId, Int16 PressureUnitId,byte? validationStatusCode)
        {
            var response = new BaseApiResponse();

            try
            {
                var FKIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int32,
                    Value = (object)model.CoverPageId
                };

                var WaterFlowIdParam = new SqlParameter
                {
                    ParameterName = "WaterFlowId",
                    DbType = DbType.Int32,
                    Value = (object)model.WaterFlowId
                };

                var FixedThermolatorModelParam = new SqlParameter
                {
                    ParameterName = "FixedThermolatorModel",
                    DbType = DbType.Double,
                    Value = (object)model.FixedThermolatorModel ?? DBNull.Value
                };

                var FixedThermolatorSerialNoParam = new SqlParameter
                {
                    ParameterName = "FixedThermolatorSerialNo",
                    DbType = DbType.Double,
                    Value = (object)model.FixedThermolatorSerialNo ?? DBNull.Value
                };

                var MovingThermolatorModelParam = new SqlParameter
                {
                    ParameterName = "MovingThermolatorModel",
                    DbType = DbType.Double,
                    Value = (object)model.MovingThermolatorModel ?? DBNull.Value
                };

                var MovingThermolatorSerialNoParam = new SqlParameter
                {
                    ParameterName = "MovingThermolatorSerialNo",
                    DbType = DbType.Double,
                    Value = (object)model.MovingThermolatorSerialNo ?? DBNull.Value
                };

                var FixedHalfGallonPerMinuteParam = new SqlParameter
                {
                    ParameterName = "FixedHalfGallonPerMinute",
                    DbType = DbType.Double,
                    Value = (object)model.FixedHalfGallonPerMinute ?? DBNull.Value
                };

                var MovingHalfGallonPerMinuteParam = new SqlParameter
                {
                    ParameterName = "MovingHalfGallonPerMinute",
                    DbType = DbType.Double,
                    Value = (object)model.MovingHalfGallonPerMinute ?? DBNull.Value
                };


                string waterMinuteDataXML = GDS.Common.ConvertToXml<WaterMinuteDataModel>.GetXMLString(model.WaterMinuteDataList);

                var WaterFlowMiunteDataModelCollectionXMLParam = new SqlParameter
                {
                    ParameterName = "WaterFlowMinuteDataModelCollectionXML",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(waterMinuteDataXML) ? waterMinuteDataXML : (object)DBNull.Value
                };

                string WaterFlowThermolatorMappingDataXml = GDS.Common.ConvertToXml<WaterFlowThermolatorDiameterMappingModel>.GetXMLString(model.WaterFlowThermolatorDiameterMappingDataList);

                var WaterFlowThermolatorMappingDataXmlParam = new SqlParameter
                {
                    ParameterName = "WaterFlowThermolatorMappingDataModelCollectionXML",
                    DbType = DbType.String,
                    Value = !string.IsNullOrWhiteSpace(WaterFlowThermolatorMappingDataXml) ? WaterFlowThermolatorMappingDataXml : (object)DBNull.Value
                };

                var FixedHoseDiameterToMoldParam = new SqlParameter
                {
                    ParameterName = "FixedHoseDiameterToMold",
                    DbType = DbType.Double,
                    Value = (object)model.FixedHoseDiameterToMold ?? DBNull.Value
                };

                var MovingHoseDiameterToMoldParam = new SqlParameter
                {
                    ParameterName = "MovingHoseDiameterToMold",
                    DbType = DbType.Double,
                    Value = (object)model.MovingHoseDiameterToMold ?? DBNull.Value
                };

                var CreatedByParam = new SqlParameter
                {
                    ParameterName = "CreatedBy",
                    DbType = DbType.Int32,
                    Value = (object)CreatedBy
                };

                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)LengthUnitId ?? (object)DBNull.Value
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)PressureUnitId ?? (object)DBNull.Value
                };

                var validationStatusCodeParam = new SqlParameter
                {
                    ParameterName = "ValidationStatusCode",
                    DbType = DbType.Int16,
                    Value = (object)validationStatusCode ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_WaterFlow_save", WaterFlowMiunteDataModelCollectionXMLParam, WaterFlowIdParam,
                    FKIdParam, FixedThermolatorModelParam, FixedThermolatorSerialNoParam, MovingThermolatorModelParam, MovingThermolatorSerialNoParam, FixedHoseDiameterToMoldParam, MovingHoseDiameterToMoldParam, FixedHalfGallonPerMinuteParam, MovingHalfGallonPerMinuteParam,
                    CreatedByParam, LengthUnitIdParam, PressureUnitIdParam, WaterFlowThermolatorMappingDataXmlParam, validationStatusCodeParam
                    ).FirstOrDefault();
                response.InsertedId = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }



        public BaseApiResponse SaveGallonMappingList(int UserId, WaterflowGallonMappingModel gallonMappingList)
        {
            var response = new BaseApiResponse();
            try
            {
                var UserIdParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = (object)UserId
                };

                var WaterFlowIdParam = new SqlParameter
                {
                    ParameterName = "WaterFlowId",
                    DbType = DbType.Int32,
                    Value = (object)gallonMappingList.WaterFlowId ?? (object)DBNull.Value
                };

                var TypeIdParam = new SqlParameter
                {
                    ParameterName = "TypeId",
                    DbType = DbType.Int32,
                    Value = (object)gallonMappingList.TypeId ?? (object)DBNull.Value
                };

                var GallonNameParam = new SqlParameter
                {
                    ParameterName = "GallonName",
                    DbType = DbType.String,
                    Value = (object)gallonMappingList.GallonName ?? (object)DBNull.Value
                };

                var AssignedGallonsParam = new SqlParameter
                {
                    ParameterName = "AssignedGallons",
                    DbType = DbType.String,
                    Value = (object)gallonMappingList.AssignedGallons ?? (object)DBNull.Value
                };

                var result = _repository.ExecuteSQL<int>("usp_smom_WaterFlowGallonMapping_save", UserIdParam, WaterFlowIdParam, TypeIdParam, GallonNameParam, AssignedGallonsParam).FirstOrDefault();
                response.Success = (result > 0);
                response.InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<WaterflowGallonMappingModel> GetGallonMappingList(int WaterFlowId)
        {
            var response = new ApiResponse<WaterflowGallonMappingModel>();

            try
            {
                var WaterFlowIdParam = new SqlParameter
                {
                    ParameterName = "WaterFlowId",
                    DbType = DbType.Int32,
                    Value = (object)WaterFlowId
                };

                var result = _repository.ExecuteSQL<WaterflowGallonMappingModel>("usp_smom_GallonMappingList_get", WaterFlowIdParam).ToList();
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


        public ApiResponse<WaterFlowThermolatorDiameterMappingModel> GetWaterFlowThermolatorMappingDetail(int WaterFlowId, Int16 LengthUnitId, Int16 PressureUnitId)
        {
            var response = new ApiResponse<WaterFlowThermolatorDiameterMappingModel>();
            List<WaterFlowThermolatorDiameterMappingModel> result = new List<WaterFlowThermolatorDiameterMappingModel>();
            try
            {
                var WaterFlowIdParam = new SqlParameter
                {
                    ParameterName = "WaterFlowId",
                    DbType = DbType.Int32,
                    Value = (object)WaterFlowId
                };


                var LengthUnitIdParam = new SqlParameter
                {
                    ParameterName = "LengthUnitId",
                    DbType = DbType.Int16,
                    Value = (object)LengthUnitId
                };

                var PressureUnitIdParam = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = (object)PressureUnitId
                };

                result = _repository.ExecuteSQL<WaterFlowThermolatorDiameterMappingModel>("usp_smom_WaterFlowThermolatorDiameterMapping_Get", WaterFlowIdParam, LengthUnitIdParam, PressureUnitIdParam).ToList();
                if (result.Count == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        // loop assign TypeId like Fixed Half,Moving Half,Special
                        result.Add(new WaterFlowThermolatorDiameterMappingModel() { TypeId = (i + 1) });
                    }
                }
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
