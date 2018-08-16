using GDS.Common;
using GDS.Data.Repository;
using GDS.Entities.SMOM.ProcessReport;
using GDS.Entities.SMOM.RecoveryTimeStudy;
using Microsoft.AspNet.SignalR.Client.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GDS.Services.SMOM.ProcessReport
{
    public class ProcessReportService : IProcessReportService
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
        private readonly IGenericRepository<ProcessReportModel> _repository;
        #endregion

        #region ctor
        public ProcessReportService(IGenericRepository<ProcessReportModel> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public ApiResponse<ProcessReportModel> GetProcessReport(int MoldFlowSetupHeaderId, int PressureUnitId, int LengthUnitId)
         {
            var response = new ApiResponse<ProcessReportModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",MoldFlowSetupHeaderId),
                    new SqlParameter("PressureUnitId",(object)PressureUnitId?? DBNull.Value),
                    new SqlParameter("LengthUnitId",(object)LengthUnitId?? DBNull.Value)
                };

                var result = _repository.ExecuteSQL<ProcessReportModel>(
                                "usp_smom_ProcessReport_Get", paramList).ToList();

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


        public ApiResponse<ProcessReportMoldModel> GetProcessReportMoldForDropDown()
        {
            var response = new ApiResponse<ProcessReportMoldModel>();

            try
            {
                var result = _repository.ExecuteSQL<ProcessReportMoldModel>(
                                "usp_smom_ProcessReport_GetInitalDataMoldListForDropDown").ToList();

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

        public BaseApiResponse UploadProcessReportAttachment(long MoldFlowSetupHeaderId, HttpPostedFile Attachment ,string AttachmentName, int? AttachmentVersion, int LoggedInUserId)
        {
            var response = new BaseApiResponse();

            try
            {
                if (Attachment != null)
                {
                    byte[] AttachmentData = null;
                    using (var binaryReader = new BinaryReader(Attachment.InputStream))
                    {
                        AttachmentData = binaryReader.ReadBytes(Attachment.ContentLength);
                    }

                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",MoldFlowSetupHeaderId),
                    new SqlParameter("Attachment",(object)AttachmentData?? DBNull.Value),
                    new SqlParameter("AttachmentName",(object)AttachmentName?? DBNull.Value),                 
                    new SqlParameter("LoggedInUserId",(object)LoggedInUserId?? DBNull.Value),
                    new SqlParameter("AttachmentVersion",(object)AttachmentVersion?? DBNull.Value)
                };

                    var result = _repository.ExecuteSQL<long>("usp_SMOM_ProcessReportAttachment_Insert", paramList).FirstOrDefault();
                    response.Success = result > 0;
                    response.lng_InsertedId = result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;

        }

        public ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachment(int MoldFlowSetupHeaderId)
        {
            var response = new ApiResponse<ProcessReportAttachmentModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",MoldFlowSetupHeaderId)
                };

                var result = _repository.ExecuteSQL<ProcessReportAttachmentModel>(
                                "usp_SMOM_ProcessReportAttachment_Get", paramList).ToList();

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


        public ApiResponse<ProcessReportAttachmentModel> GetProcessReportAttachmentById(long ProcessReportAttachmentId)
        {
            var response = new ApiResponse<ProcessReportAttachmentModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ProcessReportAttachmentId",ProcessReportAttachmentId)
                };

                var result = _repository.ExecuteSQL<ProcessReportAttachmentModel>(
                                "usp_SMOM_ProcessReportAttachment_GetById", paramList).ToList();
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

        public HttpResponseMessage DownloadProcessReportAttachmentById(long ProcessReportAttachmentId)
        {
            try
            {
                object[] paramList =
                {
                    new SqlParameter("ProcessReportAttachmentId",ProcessReportAttachmentId)
                };

                var result = _repository.ExecuteSQL<ProcessReportAttachmentModel>(
                                "usp_SMOM_ProcessReportAttachment_GetById", paramList).ToList();
                HttpResponseMessage httpResponseMessage;
                if (result != null && result.Count > 0)
                {
                    httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                    var response = new HttpResponseMessage();
                    response.Content = new ByteArrayContent(result[0].Attachment);
                    response.Content.Headers.ContentDisposition
                        = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = result[0].AttachmentName;
                    response.Content.Headers.ContentType
                        = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentLength = result[0].Attachment.Length;
                    return response;
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }


        public BaseApiResponse DeleteProcessReportAttachment(long ProcessReportAttachmentId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("ProcessReportAttachmentId",ProcessReportAttachmentId)
                };

                var result = _repository.ExecuteSQL<int>("usp_SMOM_ProcessReportAttachment_Delete", paramList).FirstOrDefault();
                response.Success = result > 0;
                response.lng_InsertedId = result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }


        //ProcessReportNotesMethods

        public ApiResponse<ProcessReportNotesModel> GetProcessReportNotes(long MoldFlowSetupHeaderId)
        {
            var response = new ApiResponse<ProcessReportNotesModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("MoldFlowSetupHeaderId",MoldFlowSetupHeaderId)
                };

                var result = _repository.ExecuteSQL<ProcessReportNotesModel>(
                                "usp_SMOM_ProcessReportNotes_Get", paramList).ToList();
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

        public ApiResponse<ProcessReportNotesModel> GetProcessReportNotesById(long ProcessReportNotesId)
        {
            var response = new ApiResponse<ProcessReportNotesModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("ProcessReportNotesId",ProcessReportNotesId)
                };

                var result = _repository.ExecuteSQL<ProcessReportNotesModel>(
                                "usp_SMOM_ProcessReportNotes_GetById", paramList).ToList();
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

        public BaseApiResponse InsertProcessReportNotes(long MoldFlowSetupHeaderId, string Notes, int LoggedInUserId, long ProcessReportNotesId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                     new SqlParameter("ProcessReportNotesId",ProcessReportNotesId),
                      new SqlParameter("Notes",Notes),
                     new SqlParameter("MoldFlowSetupHeaderId",MoldFlowSetupHeaderId),

                      new SqlParameter("LoggedInUserId",LoggedInUserId),

                };

                var result = _repository.ExecuteSQL<int>("usp_SMOM_ProcessReportNotes_Insert", paramList).FirstOrDefault();
                response.Success = result > 0;
                response.lng_InsertedId = result;

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteProcessReportNotes(long ProcessReportNotesId)
        {
            var response = new BaseApiResponse();
            try
            {
                object[] paramList =
               {
                    new SqlParameter("ProcessReportNotesId",ProcessReportNotesId)
                };

                var result = _repository.ExecuteSQL<int>("usp_SMOM_ProcessReportNotes_Delete", paramList).FirstOrDefault();
                response.Success = result > 0;
                response.lng_InsertedId = result;
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
