using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class TLNSavingReportMasterModel
    {
        #region Instance Properties

        public long TLNSavingReportingId { get; set; }

        public long PlantMonthYearId { get; set; }

        public Int32 PlantId { get; set; }

        public Int32 MonthNumber { get; set; }

        public string MonthName { get; set; }

        public Int32 YearNumber { get; set; }

        public double? LaborHrPerWkSaved { get; set; }

        public double? PressHrPerWkSaved { get; set; }

        public DateTime CreatedDate { get; set; }

        public Int32 CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Int32? UpdateBy { get; set; }

        #endregion Instance Properties
    }

    public class Temp
    {
        //public TLNSavingReportMasterModel[] modelList { get; set; }
        public int CurrentUser { get; set; }
    }

}
