using GDS.Common;
using GDS.Entities.SMOM.ProcessReport;
using GDS.Services.SMOM.ProcessReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GDS.API.Controllers.SMOM
{
    [RoutePrefix("api")]
    public class ProcessReportApiController : ApiController
    {
        #region Initializtions

        private readonly IProcessReportService _iService;

        public ProcessReportApiController()
        {
            _iService = EngineContext.Resolve<IProcessReportService>();
        }

        #endregion

        #region Methods


        [HttpGet]
        [Route("GetProcessReport")]
        public ApiResponse<ProcessReportModel> GetProcessReport(int MoldFlowSetupHeaderId, int PressureUnitId, int LengthUnitId)
        {
            return _iService.GetProcessReport(MoldFlowSetupHeaderId, PressureUnitId, LengthUnitId);
        }

        [HttpGet]
        [Route("GetProcessReportMoldForDropDown")]
        public ApiResponse<ProcessReportMoldModel> GetProcessReportMoldForDropDown()
        {
            return _iService.GetProcessReportMoldForDropDown();
        }

        [HttpPost]
        [Route("UploadProcessReportAttachment")]
        public BaseApiResponse UploadProcessReportAttachment(long MoldFlowSetupHeaderId,string AttachmentName,int? AttachmentVersion, int LoggedInUserId)
        {
            HttpPostedFile httpPostedFile = null;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                httpPostedFile = HttpContext.Current.Request.Files[0];
            }
            return _iService.UploadProcessReportAttachment(MoldFlowSetupHeaderId, httpPostedFile, AttachmentName, AttachmentVersion ,LoggedInUserId);
        }

        [HttpGet]
        [Route("GetProcessReportAttachment")]
        public ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachment(int MoldFlowSetupHeaderId)
        {
            return _iService.GetProcessReportAttachment(MoldFlowSetupHeaderId);
        }

        [HttpGet]
        [Route("GetProcessReportAttachmentById")]
        public ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachmentById(long ProcessReportAttachmentId)
        {
            return _iService.GetProcessReportAttachmentById(ProcessReportAttachmentId);
        }

        [HttpGet]
        [Route("DownloadProcessReportAttachmentById")]
        public HttpResponseMessage DownloadProcessReportAttachmentById(long ProcessReportAttachmentId)
        {
            return _iService.DownloadProcessReportAttachmentById(ProcessReportAttachmentId);
        }

        [HttpPost]
        [Route("DeleteProcessReportAttachment")]
        public BaseApiResponse DeleteProcessReportAttachment(long ProcessReportAttachmentId)
        {
            return _iService.DeleteProcessReportAttachment(ProcessReportAttachmentId);
        }
        [HttpGet]
        [Route("GetProcessReportNotes")]
        public ApiResponse<ProcessReportNotesModel> GetProcessReportNotes(long MoldFlowSetupHeaderId)
        {
            return _iService.GetProcessReportNotes(MoldFlowSetupHeaderId);
        }

        [HttpGet]
        [Route("GetProcessReportNotesById")]
        public ApiResponse<ProcessReportNotesModel> GetProcessReportNotesById(long ProcessReportNotesId)
        {
            return _iService.GetProcessReportNotesById(ProcessReportNotesId);
        }

        [HttpPost]
        [Route("InsertProcessReportNotes")]
        public BaseApiResponse InsertProcessReportNotes(long MoldFlowSetupHeaderId, string Notes, int LoggedInUserId, long ProcessReportNotesId)
        {
            return _iService.InsertProcessReportNotes(MoldFlowSetupHeaderId, Notes, LoggedInUserId, ProcessReportNotesId);
        }

        [HttpPost]
        [Route("DeleteProcessReportNotes")]
        public BaseApiResponse DeleteProcessReportNotes(long ProcessReportNotesId)
        {
            return _iService.DeleteProcessReportNotes(ProcessReportNotesId);
        }


        #endregion
    }
}
