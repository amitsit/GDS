using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDS.API.Controllers.Master
{

    using Common;
    using Entities.Master;
    using GDS.Services.Master;
    using Services.Master.TLNSavingReport;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class TLNSavingReportApiController : ApiController
    {

        #region Initializtions
        private readonly ITLNSavingReportService _iTLNSavingReportService;

        public TLNSavingReportApiController()
        {
            this._iTLNSavingReportService = EngineContext.Resolve<ITLNSavingReportService>();
        }
        #endregion

        #region Methods

      

        [HttpGet]
        [Route("GetTLNSavingReportData")]
        public ApiResponse<TLNSavingReportMasterModel> GetTLNSavingReportData(int PlantId, int YearNumber)
        {
            return _iTLNSavingReportService.GetTLNSavingReportData(PlantId, YearNumber);
        }

        [HttpPost]
        [Route("SaveTLNSavingReportData")]
        public BaseApiResponse SaveTLNSavingReportData(List<TLNSavingReportMasterModel> TLNSavingReportDataCollection,int PlantId, int YearNumber, int CreatedBy)
        {
            return _iTLNSavingReportService.SaveTLNSavingReportData(TLNSavingReportDataCollection,PlantId, YearNumber, CreatedBy );
        }

        #endregion
    }
}