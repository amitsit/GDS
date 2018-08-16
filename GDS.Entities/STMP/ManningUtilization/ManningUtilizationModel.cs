using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.STMP.ManningUtilization
{
    public class ManningUtilizationModel
    {
        public int? PlantId { get; set; }
        public double? StdQuotedWeek { get; set; }
        public double? StdReliefDivisor { get; set; }

        public List<ManningUtilizationTable1> ManningUtilizationTable1 { get; set; }
        public List<ManningUtilizationTable2> ManningUtilizationTable2 { get; set; }
        public List<ManningUtilizationTable3> ManningUtilizationTable3 { get; set; }
    }

    public class ManningUtilizationTable1
    {
        public string ProgramName { get; set; }
        public double? StdQuotedWeek { get; set; }
        public double? MANNING { get; set; }
        public double? RELIEF { get; set; }
        public double? Total { get; set; }
        public double? StdReliefDivisor { get; set; }
        public string LABOR { get; set; }

    }

    public class ManningUtilizationTable2
    {
        public string PressNumber { get; set; }
        public double? tonnage { get; set; }
        public double? UTILIZHOURS { get; set; }
        public double? AVA_HRS { get; set; }
        public double? TakeRate { get; set; }
        public double? CYC_SEC { get; set; }
    }

    public class ManningUtilizationTable3
    {
        public string Total { get; set; }
        public int TonnageFrom { get; set; }
        public string TonnageToDisplay { get; set; }
        public int TonnageTo { get; set; }
        public double? UTZ_HRS { get; set; }
        public double? AVAIL_HRS { get; set; }
        public double? DEMAND { get; set; }
        public double? CYC_SEC { get; set; }
        public int AVG_Year { get; set; }
        public int? NumberOfPress { get; set; }
        public double? CAP { get; set; }

        public double? UTZ { get; set; }
        public double? AVG_CYC { get; set; }
        public double? Weight_TON { get; set; }
    }
}
