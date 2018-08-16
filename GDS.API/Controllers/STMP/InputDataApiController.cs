using System.Web.Http;
using GDS.Common;
using GDS.Entities;
using GDS.Entities.STMP.InputData;
using GDS.Services.STMP.InputData;
using GDS.Entities.Master;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Spire.Xls;
using System;
using System.Linq;
using System.IO;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class InputDataApiController : ApiController
    {
        #region Initializtions

        private readonly IInputDataService _iInputDataService;

        public InputDataApiController()
        {
            _iInputDataService = EngineContext.Resolve<IInputDataService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetInputData")] 
        public ApiResponse<STMPInputDataModel> GetInputData(long? inputDataId = null)
        {
            return _iInputDataService.GetInputData(inputDataId);
        }
        
        [HttpPost]
        [Route("GetInputDataList")]
        public TableParameter<STMPInputDataModel> GetInputDataList(int UserId,int PlantId,int PageIndex,string SearchValue, TableParameter<STMPInputDataModel> tableParameter)
        {
            tableParameter.PageIndex = PageIndex;
            string sortColumn = tableParameter.SortColumn.Desc ? tableParameter.SortColumn.Column + " desc" : tableParameter.SortColumn.Column + " asc";
            string searchValue = SearchValue == null ? string.Empty : SearchValue.Trim();
            var Inputdata = _iInputDataService.GetInputDataList(UserId,PlantId, sortColumn, searchValue, tableParameter);
            int totalRecords = 0;
            if (Inputdata != null && Inputdata.Data.Count > 0)
            {
                totalRecords =Inputdata.Data[0].TotalRecords;
            }

            return new TableParameter<STMPInputDataModel>
            {
                aaData =(List<STMPInputDataModel>) Inputdata.Data,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords
            };

        }

        [HttpGet]
        [Route("GetPrograms")]
        public ApiResponse<ProgramMasterModel> GetPrograms()
        {
            return _iInputDataService.GetPrograms();
        }

        [HttpPost]
        [Route("SaveInputData")]
        public BaseApiResponse SaveInputData(STMPInputDataModel model)
        {
            return _iInputDataService.SaveInputData(model);
        }

        [HttpPost]
        [Route("SaveInputData_InitialDataConverstion")]
        public BaseApiResponse SaveInputData_InitialDataConverstion(bool? IsExistingMold,int? MoldFlowSetupHeaderId, STMPInputDataModel model)
        {
            return _iInputDataService.SaveInputData_InitialDataConverstion(IsExistingMold, MoldFlowSetupHeaderId,model);
        }

        [HttpPost]
        [Route("DeleteInputData")]
        public BaseApiResponse DeleteInputData(long inputDataId)
        {
            return _iInputDataService.DeleteInputData(inputDataId);
        }

        [HttpGet]
        [Route("GetMoldByProgramAndPlant")]
        public ApiResponse<STMPInputDataModel> GetMoldByProgramAndPlant(int? PlantId, long? ProgramID, int LoggedInUserId)
        {
            return _iInputDataService.GetMoldByProgramAndPlant(PlantId, ProgramID, LoggedInUserId);
        }

        [HttpPost]
        [Route("UploadInputDataFile")]
        public BaseApiResponse UploadInputDataFile(int columnSize,int UserId)
        {
            var directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/TempFiles");
            string datatableToxml = "";
            DataTable datatable = null;
            if (!System.IO.Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
            string filePath = directoryPath + @"\" + Guid.NewGuid().ToString() + ".xlsx";

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files[0];
                httpPostedFile.SaveAs(filePath);
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(filePath);
                Worksheet sheet = workbook.Worksheets[0];
                datatable = sheet.ExportDataTable();
                if (datatable != null)
                {
                    int desiredSize = columnSize;

                    while (datatable.Columns.Count > desiredSize)
                    {
                        datatable.Columns.RemoveAt(desiredSize);
                    }

                }

                using (StringWriter sw = new StringWriter())
                {
                    datatable.WriteXml(sw);
                    datatableToxml = sw.ToString();
                }

            }
            return _iInputDataService.UploadInputDataFile(datatableToxml, UserId);
        }

        #endregion
    }
}
