using System.Web.Http;
using GDS.Common;
using GDS.Entities;
using GDS.Entities.STMP.PlantEquipmentList;
using GDS.Services.STMP.PlantEquipmentList;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System;
using System.Data.OleDb;
using Spire.Xls;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class PlantEquipmentListApiController : ApiController
    {
        #region Initializtions

        private readonly IPlantEquipmentListService _iPlantEquipmentListService;

        public PlantEquipmentListApiController()
        {
            _iPlantEquipmentListService = EngineContext.Resolve<IPlantEquipmentListService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetPlantEquipmentList")]
        public ApiResponse<STMPPlantEquipmentListModel> GetPlantEquipmentList(int? plantId = null, long? plantEquipmentListId = null)
        {
            return _iPlantEquipmentListService.GetPlantEquipmentList(plantId, plantEquipmentListId);
        }

        [HttpPost]
        [Route("InsertPlanEquipmentList")]
        public BaseApiResponse InsertPlanEquipmentList(int plantId)
        {
            return _iPlantEquipmentListService.InsertPlanEquipmentList(plantId);
        }

        [HttpPost]
        [Route("InsertPlanEquipmentListMaster")]
        public BaseApiResponse InsertPlanEquipmentListMaster(int UserId, List<STMPPlantEquipmentListMasterModel> dataObjects)
        {
            return _iPlantEquipmentListService.InsertPlanEquipmentListMaster(UserId, dataObjects);
        }

        [HttpPost]
        [Route("UploadPlantEquipmentFile")]
        public BaseApiResponse UploadPlantEquipmentFile(int UserId,int NumberOfColumn)
        {
            var directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/TempFiles");
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
                    foreach (DataColumn c in datatable.Columns)
                    {
                        c.ColumnName = c.ColumnName.Replace(" ", "_");
                        c.ColumnName = c.ColumnName.Replace("/", "_");
                        c.ColumnName = c.ColumnName.Replace("\\", "_");
                    }

                    int desiredSize = NumberOfColumn;

                    while (datatable.Columns.Count > desiredSize)
                    {
                        datatable.Columns.RemoveAt(desiredSize);
                    }

                }

            }
            return _iPlantEquipmentListService.UploadPlantEquipmentFile(datatable, UserId);
        }

        [HttpGet]
        [Route("GetPlantEquipmentListForDDL")]
        public ApiResponse<PlantEquipmentForDDLModel> GetPlantEquipmentListForDDL(int plantId = 0, long bicVerificationDocumentId = 0, long coverPageId = 0)
        {
            return _iPlantEquipmentListService.GetPlantEquipmentListForDDL(plantId, bicVerificationDocumentId, coverPageId);
        }

        [HttpPost]
        [Route("InsertOrUpdatePlantEquipmentList")]
        public BaseApiResponse InsertOrUpdatePlantEquipmentList(PlantEquipmentMasterModel model)
        {
            return _iPlantEquipmentListService.InsertOrUpdatePlantEquipmentList(model);
        }

        [HttpGet]
        [Route("DeletePlantEquipment")]
        public BaseApiResponse DeletePlantEquipment(int plantEquipmentListId)
        {
            return this._iPlantEquipmentListService.DeletePlantEquipment(plantEquipmentListId);
        }

        [HttpGet]
        [Route("GetPlantEquipmentServerPagination")]
        public ApiResponse<PlantEquipmentMasterModel> GetPlantEquipmentServerPagination(int plantId, int pageIndex, int pageSize,string SearchColumnName ,string searchFor, string orderByColumn, bool orderByAscDirection = true)
        {
            return _iPlantEquipmentListService.GetPlantEquipmentServerPagination(plantId, pageIndex, pageSize, SearchColumnName, searchFor, orderByColumn, orderByAscDirection);
        }


        [HttpGet]
        [Route("GetPlantEquipmentColumnList")]
        public ApiResponse<PlantEquipmentColumnListModel> GetPlantEquipmentColumnList()
        {
            return _iPlantEquipmentListService.GetPlantEquipmentColumnList();
        }
        #endregion
    }
}
