using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.Master;
using GDS.Entities.SMOM;
using System.Collections.Generic;

namespace GDS.Services.SMOM.GateSeal
{
     public class GateSealService : IGateSealService
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
        private readonly IGenericRepository<GateSealMasterModel> _repository;

        #endregion

        #region ctor


        public GateSealService(IGenericRepository<GateSealMasterModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public ApiResponse<GateSealPartModel> GetSealPartDetail(int GateSealId )
        {
            var response = new ApiResponse<GateSealPartModel>();

            try
            {
                var GateSealIdParam = new SqlParameter
                {
                    ParameterName = "GateSealId",
                    DbType = DbType.Int32,
                    Value = (object)GateSealId
                };

                var result = _repository.ExecuteSQL<GateSealPartModel>("usp_smom_GateSealPartDetail_Get", GateSealIdParam).ToList();
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
        public ApiResponse<GateSealMasterModel> GetSealDetail(long CoverPageId ,Int16 PressureUnitId)
        {
            var response = new ApiResponse<GateSealMasterModel>();
            List<GateSealMasterModel> result = new List<GateSealMasterModel>();
            try
            {
                var CoverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)CoverPageId
                };
                var pressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = PressureUnitId
                };

                result = _repository.ExecuteSQL<GateSealMasterModel>("usp_smom_GateSeal_get", CoverPageIdParam, pressureUnitId).ToList();

                if (result.Count==0)
                {
                    result.Add(new GateSealMasterModel());
                    result[0].PartModelList = new List<GateSealPartModel>();
                }

                var GateSealIdParam = new SqlParameter
                {
                    ParameterName = "GateSealId",
                    DbType = DbType.Int32,
                    Value = (object)result[0].GateSealId??(object) DBNull.Value
                };


                result[0].PartModelList = _repository.ExecuteSQL<GateSealPartModel>("usp_smom_GateSealPartDetail_Get", GateSealIdParam).ToList();

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

        public BaseApiResponse SaveOrUpdateSealDetail(int UserId, long CoverPageId, Int16 PressureUnitId, GateSealMasterModel MasterModel)
        {
            var response = new BaseApiResponse();

            try
            {
                
                #region Parameters

                string getxmlstr = GDS.Common.ConvertToXml<GateSealPartModel>.GetXMLString(MasterModel.PartModelList);

                var GateSealDataCollectionXML = new SqlParameter
                {
                    ParameterName = "GateSealDataCollection",
                    DbType = DbType.String,
                    Value = getxmlstr
                };


                var gatesealIdParam = new SqlParameter
                {
                    ParameterName = "GateSealId",
                    DbType = DbType.Int32,
                    Value =(object) MasterModel.GateSealId ?? (object)DBNull.Value
                };

                var noofcavitiesParam = new SqlParameter
                {
                    ParameterName = "NoOfCavities",
                    DbType = DbType.Double,
                    Value = (object)MasterModel.NoOfCavities ?? (object)DBNull.Value
                };

                var packholdpsibarparam = new SqlParameter
                {
                    ParameterName = "PackHoldPSIBar",
                    DbType = DbType.Double,
                    Value = (object)MasterModel.PackHoldPSIBar ?? (object)DBNull.Value
                };
                var gatesealfromparam = new SqlParameter
                {
                    ParameterName = "GateSealFrom",
                    DbType = DbType.Int32,
                    Value = (object)MasterModel.GateSealFrom ?? (object)DBNull.Value
                };
                var gatesealtoparam = new SqlParameter
                {
                    ParameterName = "GateSealTo",
                    DbType = DbType.Int32,
                    Value = (object)MasterModel.GateSealTo ?? (object)DBNull.Value
                };

                var CoverPageIdparam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = CoverPageId
                };

                var useridParam = new SqlParameter
                {
                    ParameterName = "UserId",
                    DbType = DbType.Int32,
                    Value = UserId
                };

                var pressureUnitId = new SqlParameter
                {
                    ParameterName = "PressureUnitId",
                    DbType = DbType.Int16,
                    Value = PressureUnitId
                };
                #endregion

                var result = _repository.ExecuteSQL<int>("usp_smom_Gatesealpartdetail_Update", GateSealDataCollectionXML, gatesealIdParam, noofcavitiesParam, packholdpsibarparam, gatesealfromparam, gatesealtoparam, CoverPageIdparam,useridParam, pressureUnitId).FirstOrDefault();
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
