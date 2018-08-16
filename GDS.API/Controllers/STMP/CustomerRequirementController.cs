using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GDS.Common;
using GDS.Entities.STMP.CustomerRequirement;
using GDS.Services.STMP.CustomerRequirement;
using GDS.Services.STMP.InputData;
using System.Data;
using System.Web;
using Spire.Xls;
using System.IO;

namespace GDS.API.Controllers.STMP
{
    [RoutePrefix("api")]
    public class CustomerRequirementController : ApiController
    {
        #region Initializtions

        private readonly ICustomerRequirementService _iCustomerRequirementService;

        public CustomerRequirementController()
        {
            _iCustomerRequirementService = EngineContext.Resolve<ICustomerRequirementService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetCustomerRequirement")]
        public ApiResponse<CustomerRequirementModel> GetCustomerRequirement(int? loggedInUserId = null, int plantId = 0, int? plantMonthYearId = null, string searchValue = "")
        {
            return _iCustomerRequirementService.GetCustomerRequirement(loggedInUserId, plantId, plantMonthYearId, searchValue);
        }

        [HttpGet]
        [Route("Get7DayDatesIntervalForAYear")]
        public ApiResponse<DatesList> Get7DayDatesIntervalForAYear(DateTime startDate)
        {
            return _iCustomerRequirementService.Get7DayDatesIntervalForAYear(startDate);
        }


        [HttpPost]
        [Route("UpdateCustomerRequirementList")]
        public BaseApiResponse UpdateCustomerRequirementList(CustomerRequirementModel model)
        {
            return _iCustomerRequirementService.UpdateCustomerRequirementList(model);
        }

        [HttpPost]
        [Route("UploadCustomerRequirementFile")]
        public BaseApiResponse UploadCustomerRequirementFile(int UserId)
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
                    int desiredSize = 19;

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
            return _iCustomerRequirementService.UploadCustomerRequirementFile(datatableToxml, UserId);
        }

        #endregion
    }
}
