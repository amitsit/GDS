using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.STMP.CustomerRequirement
{
    public class CustomerRequirementModel
    {
        public Int64? CustomerRequirementId { get; set; }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string PlantName { get; set; }
        public string MoldToolId { get; set; }
        public double? Take { get; set; }
        public int? Week1 { get; set; }
        public int? Week2 { get; set; }
        public int? Week3 { get; set; }
        public int? Week4 { get; set; }
        public int? Week5 { get; set; }
        public int? Week6 { get; set; }
        public int? Week7 { get; set; }
        public int? Week8 { get; set; }
        public int? Week9 { get; set; }
        public int? Week10 { get; set; }

        public int? Week11 { get; set; }
        public int? Week12 { get; set; }

        public double? Average { get; set; }
        public double? LCR { get; set; }
        public double? MAX { get; set; }
        public DateTime? StartWeekDate { get; set; }
        public int? PlantId { get; set; }
        public bool? IsAssignedinSTMP { get; set; }

    }

    public class CustomerRequirementQADInputModel
    {
        public string PLANT { get; set; }
        public string Program { get; set; }
        public string Mold { get; set; }
        public int? WK1 { get; set; }
        public int? WK2 { get; set; }
        public int? WK3 { get; set; }
        public int? WK4 { get; set; }
        public int? WK5 { get; set; }
        public int? WK6 { get; set; }
        public int? WK7 { get; set; }
        public int? WK8 { get; set; }
        public int? WK9 { get; set; }
        public int? WK10 { get; set; }
        public int? WK11 { get; set; }
        public int? WK12 { get; set; }

    }

    public class DatesList
    {
        public DateTime Dates { get; set; }
        public string DatesStr { get; set; }
    }
}
