using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GDS.Services.Master.TLNSavingReport
{

    using Common;
    using Entities.Master;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ITLNSavingReportService
    {
        ApiResponse<TLNSavingReportMasterModel> GetTLNSavingReportData(int PlantId,int YearNumber);
   
        BaseApiResponse SaveTLNSavingReportData(List<TLNSavingReportMasterModel> TLNSavingReportDataCollection, int PlantId, int YearNumber, int CreatedBy);


    }

}




