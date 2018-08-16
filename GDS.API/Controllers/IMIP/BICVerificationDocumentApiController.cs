using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using GDS.Common;
using GDS.Entities.IMIP;
using GDS.Services.IMIP.BICVerificationDocument;
using System.Web.Http;
using GDS.Entities.Master;
using GDS.Entities.SMOM.CoverPage;

namespace GDS.API.Controllers.IMIP
{
    [RoutePrefix("api")]
    public class BICVerificationDocumentApiController : ApiController
    {
        #region Constants
        /// <summary>
        /// Declare The logger object for perform operation on Logger
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Initializtions
        private readonly IBICVerificationDocumentService _iBICVerificationDocumentService;

        public BICVerificationDocumentApiController()
        {
            _iBICVerificationDocumentService = EngineContext.Resolve<IBICVerificationDocumentService>();
        }
        #endregion

        #region Methods

        [HttpGet]
        [Route("GetMoldNumber")]
        public ApiResponse<MoldNumberDDLModel> GetMoldNumber(int plantId)
        {
            return _iBICVerificationDocumentService.GetMoldNumber(plantId);
        }

        [HttpGet]
        [Route("GetCTPartThicknessList")]
        public ApiResponse<CTPartThicknessModel> GetCTPartThicknessList()
        {
            return _iBICVerificationDocumentService.GetCTPartThicknessList();
        }

        [HttpGet]
        [Route("GetProgramsByPlantId")]
        public ApiResponse<ProgramMasterModel> GetProgramsByPlantId(int plantId)
        {
            return _iBICVerificationDocumentService.GetProgramsByPlantId(plantId);
        }

        [HttpGet]
        [Route("GetBICDocument_GetPartProgramTonnage")]
        public ApiResponse<CoverPageMachineConfiguration> GetBICDocument_GetPartProgramTonnage(int? plantid, long? inputdataid, long? plantequipmentlistid, Int16? lengthUnitId, Int16? pressureUnitId)
        {
            return _iBICVerificationDocumentService.GetBICDocument_GetPartProgramTonnage(plantid, inputdataid, plantequipmentlistid, lengthUnitId, pressureUnitId);
        }

        [HttpGet]
        [Route("GetBICVerificationDocumentList")]
        public ApiResponse<BICVerificationDocumentModel> GetBICVerificationDocumentList(int? plantId = null, int? plantEquipmentId = null,
            long? bicVerificationDocumentId = null, long? coverPageId = null)
        {
            return _iBICVerificationDocumentService.GetBICVerificationDocumentList(plantId, plantEquipmentId, bicVerificationDocumentId, coverPageId);
        }

        [HttpGet]
        [Route("GetBICVerificationDocumentImages")]
        public ApiResponse<BICVerificationDocumentImagesModel> GetBICVerificationDocumentImages(long? bicVerificationDocumentId, long? coverPageId)
        {
            return _iBICVerificationDocumentService.GetBICVerificationDocumentImages(bicVerificationDocumentId, coverPageId);
        }

        [HttpGet]
        [Route("GetBICVerificationQuestionAnswerList")]
        public ApiResponse<BICVerificationQuestionAnswerModel> GetBICVerificationQuestionAnswerList(int? bicVerificationDocumentId = null, long? coverPageId = null)
        {
            return _iBICVerificationDocumentService.GetBICVerificationQuestionAnswerList(bicVerificationDocumentId, coverPageId);
        }

        [HttpPost]
        [Route("SaveBICVerificationDocument")]
        public BaseApiResponse SaveBICVerificationDocument(BICVerificationDocumentModel model)
        {
            return _iBICVerificationDocumentService.SaveBICVerificationDocument(model);
        }

        [HttpPost]
        [Route("UploadImage")]
        public BaseApiResponse UploadImage()
        {
            var response = new BaseApiResponse();
            var request = HttpContext.Current.Request;
            string[] allowedFileTypes = { ".jpg", ".jpeg", ".png" };

            try
            {
                if (!request.Files.AllKeys.Any())
                    throw new Exception("File not found");

                if (request.Params["BICVerificationDocumentId"] == null)
                    throw new Exception("Could not find BICVerificationDocumentId");

                var files = new List<HttpPostedFile>();
                for (var i = 0; i < request.Files.Count; i++)
                {
                    if (!allowedFileTypes.Contains(Path.GetExtension(request.Files[i].FileName).ToLower()))
                        throw new Exception("Invalid file type");

                    files.Add(request.Files[i]);
                }
                
                var bicVerificationDocumentId = Convert.ToInt64(request.Params["BICVerificationDocumentId"]);
                response = _iBICVerificationDocumentService.UploadImage(files, bicVerificationDocumentId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("DeleteBICVerificationDocumentImages")]
        public BaseApiResponse DeleteBICVerificationDocumentImages(long bicVerificationDocumentId)
        {
            return _iBICVerificationDocumentService.DeleteBICVerificationDocumentImages(bicVerificationDocumentId);
        }

        [HttpPost]
        [Route("DeleteBICVerificationDocument")]
        public BaseApiResponse DeleteBICVerificationDocument(long bicVerificationDocumentId, int plantId, long plantEquipmentId)
        {
            return _iBICVerificationDocumentService.DeleteBICVerificationDocument(bicVerificationDocumentId, plantId, plantEquipmentId);
        }

        #endregion
    }
}
