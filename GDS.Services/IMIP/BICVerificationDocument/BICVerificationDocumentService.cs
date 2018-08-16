using System;
using System.Collections.Generic;
using System.Linq;
using GDS.Common;
using GDS.Entities.IMIP;
using GDS.Data.Repository;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web;
using GDS.Entities.Master;
using GDS.Entities.STMP.InputData;
using GDS.Entities.SMOM.CoverPage;

namespace GDS.Services.IMIP.BICVerificationDocument
{
    public class BICVerificationDocumentService : IBICVerificationDocumentService
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
        private readonly IGenericRepository<BICVerificationDocumentModel> _repository;
        #endregion

        #region ctor
        public BICVerificationDocumentService(IGenericRepository<BICVerificationDocumentModel> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods

        public ApiResponse<MoldNumberDDLModel> GetMoldNumber(int plantId)
        {
            var response = new ApiResponse<MoldNumberDDLModel>();

            try
            {
                var plantIdParam = new SqlParameter("PlantId", plantId);

                response.Data = _repository.ExecuteSQL<MoldNumberDDLModel>("usp_InputData_GetMoldNumber", plantIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public ApiResponse<CoverPageMachineConfiguration> GetBICDocument_GetPartProgramTonnage(int? plantid,long? inputdataid,long? plantequipmentlistid, Int16? lengthUnitId, Int16? pressureUnitId)
        {
            var response = new ApiResponse<CoverPageMachineConfiguration>();

            try
            {                    

                object[] paramList =
               {
                    new SqlParameter("PlantId",(object)plantid?? DBNull.Value),
                    new SqlParameter("InputDataId",(object)inputdataid?? DBNull.Value),
                    new SqlParameter("PlantEquipmentListId",(object)plantequipmentlistid?? DBNull.Value),                     
                    new SqlParameter("LengthUnitId",(object)lengthUnitId ?? DBNull.Value),
                    new SqlParameter("PressureUnitId",(object)pressureUnitId ?? DBNull.Value)
                };

                response.Data = _repository.ExecuteSQL<CoverPageMachineConfiguration>("usp_IMIP_BICDocument_GetPartProgramTonnage",paramList).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public ApiResponse<CTPartThicknessModel> GetCTPartThicknessList()
        {
            var response = new ApiResponse<CTPartThicknessModel>();

            try
            {
                response.Data = _repository.ExecuteSQL<CTPartThicknessModel>("usp_imip_WallStockMaster_GetCTPartThicknessList").ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public ApiResponse<ProgramMasterModel> GetProgramsByPlantId(int plantId)
        {
            var response = new ApiResponse<ProgramMasterModel>();

            try
            {
                var programIdParam = new SqlParameter("PlantId", plantId);

                response.Data = _repository.ExecuteSQL<ProgramMasterModel>("usp_InputData_GetProgramsByPlantId", programIdParam).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }
            return response;
        }

        public ApiResponse<BICVerificationDocumentModel> GetBICVerificationDocumentList(int? plantId, int? plantEquipmentId, long? bicVerificationDocumentId, long? coverPageId)
        {
            var response = new ApiResponse<BICVerificationDocumentModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("PlantId",(object)plantId?? DBNull.Value),
                    new SqlParameter("PlantEquipmentListId",(object)plantEquipmentId?? DBNull.Value),
                    new SqlParameter("BICVerificationDocumentId",(object)bicVerificationDocumentId ?? DBNull.Value),
                    new SqlParameter("CoverPageId",(object)coverPageId ?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<BICVerificationDocumentModel>(
                                "usp_imip_BICVerificationDocument_get", paramList).ToList();

                // If the request is for listing BIC verification document
                // then remove New mold values
                if (bicVerificationDocumentId == null && coverPageId == null)
                    result = result.Where(w => w.CoverPageId == null).ToList();

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
        
        public ApiResponse<BICVerificationQuestionAnswerModel> GetBICVerificationQuestionAnswerList(int? bicVerificationDocumentId, long? coverPageId)
        {
            var response = new ApiResponse<BICVerificationQuestionAnswerModel>();

            try
            {
                var bicVerificationDocumentIdParam = new SqlParameter
                {
                    ParameterName = "BICVerificationDocumentId",
                    DbType = DbType.Int32,
                    Value = (object)bicVerificationDocumentId ?? DBNull.Value
                };

                var coverPageIdParam = new SqlParameter
                {
                    ParameterName = "CoverPageId",
                    DbType = DbType.Int64,
                    Value = (object)coverPageId ?? DBNull.Value
                };

                var result = _repository.ExecuteSQL<BICVerificationQuestionAnswerModel>("usp_imip_ManageQuestionAnswer_get"
                            , bicVerificationDocumentIdParam, coverPageIdParam).ToList();
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

        public BaseApiResponse SaveBICVerificationDocument(BICVerificationDocumentModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                var xmlBICVerificationQuestionAnswerList = ConvertToXml<BICVerificationQuestionAnswerModel>.GetXMLString(model.BICVerificationQuestionAnswerList);
                var xmlBICVerificationDocumentBreakDownList = ConvertToXml<BICVerificationDocumentBreakDown>.GetXMLString(model.BICVerificationDocumentBreakDownList);
                //var dtBICVerificationDocumentBreakDownList = Utility.ConvertListToDataTable(model.BICVerificationDocumentBreakDownList);

                object[] paramList =
                {
                    new SqlParameter("BICVerificationDocumentId",model.BICVerificationDocumentId)
                   ,new SqlParameter("TypeId",model.TypeId)
                   ,new SqlParameter("CoverPageId",(object)model.CoverPageId ?? DBNull.Value)
                   ,new SqlParameter("PlantId",model.PlantId)
                   ,new SqlParameter("ProgramId",model.ProgramId)
                   ,new SqlParameter("Part",model.Part)
                   ,new SqlParameter("MoldNumber",model.MoldNumber)
                   ,new SqlParameter("PlantEquipmentListId",model.PlantEquipmentListId)
                   ,new SqlParameter("Tonnage",model.Tonnage)
                   ,new SqlParameter("WallStockMM",model.WallStockMM)
                   ,new SqlParameter("InsertMolding",model.InsertMolding)
                   ,new SqlParameter("CurrentCycleSec",model.CurrentCycleSec)
                   ,new SqlParameter("BaselineDate",(object)model.BaselineDate??DBNull.Value)
                   ,new SqlParameter("ImprovedDate",(object)model.ImprovedDate??DBNull.Value)
                   ,new SqlParameter("ValidationStatusCode",(object)model.ValidationStatusCode??DBNull.Value)
                   //,new SqlParameter("CTThicknessAddSec",model.CTThicknessAddSec)
                   //,new SqlParameter("InsertMoldingAddSec",model.InsertMoldingAddSec)
                   //,new SqlParameter("BICCycleTime",model.BICCycleTime)
                   //,new SqlParameter("WCCycleTime",model.WCCycleTime)
                   //,new SqlParameter("NeedImprovementBy",model.NeedImprovementBy)
                   ,new SqlParameter("LoggedInUserId",model.LoggedInUserId)
                   ,new SqlParameter("BICVerificationQuestionAnswerList",xmlBICVerificationQuestionAnswerList)
                   ,new SqlParameter("BICVerificationDocumentBreakDownList",xmlBICVerificationDocumentBreakDownList)
                   //,new SqlParameter
                   //{
                   //    ParameterName = "BICVerificationDocumentBreakDown",
                   //    SqlDbType = SqlDbType.Structured,
                   //    TypeName = "dbo.ut_BICVerificationDocumentBreakDown",
                   //    Value = dtBICVerificationDocumentBreakDownList
                   //}
                };

                var result = _repository.ExecuteSQL<int>("usp_imip_SaveBICVerificationDocument", paramList).FirstOrDefault();
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

        public BaseApiResponse DeleteBICVerificationDocument(long bicVerificationDocumentId, int plantId, long plantEquipmentId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                 {
                    new SqlParameter("BICVerificationDocumentId",(object)bicVerificationDocumentId ?? DBNull.Value),
                    new SqlParameter("PlantId",(object)plantId?? DBNull.Value),
                    new SqlParameter("PlantEquipmentListId",(object)plantEquipmentId?? DBNull.Value),
                   
                };

                var result =
                   _repository.ExecuteSQL<long>(
                       "usp_imip_BICVerificationDocument_Delete", paramList)
                       .FirstOrDefault();

                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #region Images

        public ApiResponse<BICVerificationDocumentImagesModel> GetBICVerificationDocumentImages(long? bicVerificationDocumentId, long? coverPageId)
        {
            var response = new ApiResponse<BICVerificationDocumentImagesModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("BICVerificationDocumentId",(object)bicVerificationDocumentId ?? DBNull.Value),
                    new SqlParameter("CoverPageId",(object)coverPageId ?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<BICVerificationDocumentImagesModel>("usp_imip_BICVerificationDocumentImages_GetBICVerificationDocumentImages", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteBICVerificationDocumentImages(long bicVerificationDocumentId)
        {
            var response = new BaseApiResponse();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("BicVerificationDocumentId",bicVerificationDocumentId)
                };

                var result =
                    _repository.ExecuteSQL<int>(
                        "usp_imip_BICVerificationDocumentImages_DeleteBICVerificationDocumentImages", paramList)
                        .FirstOrDefault();

                response.Success = result > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse UploadImage(List<HttpPostedFile> files, long bicVerificationDocumentId)
        {
            var response = new BaseApiResponse();

            try
            {
                var dt = new DataTable();

                dt.Columns.Add(new DataColumn("Image")
                {
                    DataType = Type.GetType("System.Byte[]")
                });

                foreach (var file in files)
                {
                    using (var fs = file.InputStream)
                    {
                        using (var br = new BinaryReader(fs))
                        {
                            var bytes = br.ReadBytes((int)fs.Length);

                            DataRow row = dt.NewRow();
                            row["Image"] = bytes;
                            dt.Rows.Add(row);
                        }
                    }
                }

                object[] paramList =
                {
                    new SqlParameter("BICVerificationDocumentId",bicVerificationDocumentId),
                    new SqlParameter("UserId",1),
                    new SqlParameter
                    {
                        ParameterName = "utImagesTable",
                        SqlDbType = SqlDbType.Structured,
                        TypeName = "dbo.utImagesTable",
                        Value = dt
                    }
                };
                var result = _repository.ExecuteSQL<int>("usp_imip_BICVerificationDocument_UploadImage", paramList).FirstOrDefault();

                response.Success = result > 0;

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
