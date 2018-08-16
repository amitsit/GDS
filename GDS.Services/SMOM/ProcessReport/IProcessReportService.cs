using GDS.Common;
using GDS.Entities.SMOM.ProcessReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GDS.Services.SMOM.ProcessReport
{
    public interface IProcessReportService
    {
        ApiResponse<ProcessReportModel> GetProcessReport(int MoldFlowSetupHeaderId, int PressureUnitId, int LengthUnitId);
        ApiResponse<ProcessReportMoldModel> GetProcessReportMoldForDropDown();
        BaseApiResponse UploadProcessReportAttachment(long MoldFlowSetupHeaderId, HttpPostedFile Attachment, string AttachmentName, int? AttachmentVersion, int LoggedInUserId);
        ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachment(int MoldFlowSetupHeaderId);
        ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachmentById(long ProcessReportAttachmentId);
        HttpResponseMessage DownloadProcessReportAttachmentById(long ProcessReportAttachmentId);
        BaseApiResponse DeleteProcessReportAttachment(long ProcessReportAttachmentId);
        ApiResponse<ProcessReportNotesModel> GetProcessReportNotes(long MoldFlowSetupHeaderId);
        ApiResponse<ProcessReportNotesModel> GetProcessReportNotesById(long ProcessReportNotesId);
        BaseApiResponse InsertProcessReportNotes(long MoldFlowSetupHeaderId, string Notes, int LoggedInUserId, long ProcessReportNotesId);
        BaseApiResponse DeleteProcessReportNotes(long ProcessReportNotesId);

    }
}
