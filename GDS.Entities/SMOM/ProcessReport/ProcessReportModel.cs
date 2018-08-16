using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.ProcessReport
{
    public class ProcessReportModel
    {
        public DateTime ProcessDate { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }
        public string Material { get; set; }
        public double? FillTime { get; set; }
        public double? FillPressure { get; set; }
        public double? FullWeight { get; set; }
        public double? FullPartsWeight { get; set; }
        public double? RunnerWeights { get; set; }
        public double? PackTime { get; set; }
        public double? PackPressure { get; set; }
        public double? HoldTime { get; set; }
        public double? HoldPressure { get; set; }
        public double? BackPressure { get; set; }
        public double? RecoveryTime { get; set; }
        public double? CoolingTime { get; set; }
        public double? CycleTime { get; set; }
        public double? Stationary_1 { get; set; }
        public double? Moveable_1 { get; set; }
        public double? Stationary_2 { get; set; }
        public double? Moveable_2 { get; set; }
        public double? MeltTemperature { get; set; }
        public double? BarrelUsagePercentage { get; set; }
        public double? FillCubicVolume { get; set; }
        public double? TotalCubicVolume { get; set; }
        public string MoldNumber { get; set; }
        public string SupplierName { get; set; }
        public double? Tonnage { get; set; }
        public string MaterialTypeDescription { get; set; }
        public int? VersionNumber { get; set; }
    }
}
