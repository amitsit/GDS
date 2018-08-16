
namespace GDS.Entities.SMOM.GPMCalculator
{
    public class GPMCalculatorModel
    {
        public long CoverPageId { get; set; }
        public string MaterialName { get; set; }
        public int MaterialTypeId { get; set; }

        public int MaterialId { get; set; }
        public double? MeltTempCelsius { get; set; }
        public double? PartEjectTempCelsius { get; set; }
        public double? WaterTempCelsius { get; set; }
        public double? AllowableTempRiseCelsius { get; set; }
        public double? PartThicknessMM { get; set; }
        public double? MeltTemp { get; set; }
        public double? PartEjectTemp { get; set; }
        public double? WaterTemp { get; set; }
        public double? AllowableTempRise { get; set; }
        public double? CycleTime { get; set; }
        public double? SpecificHeat { get; set; }
        public double? ShotWeight { get; set; }
        public double? PartThickness { get; set; }
         public double? ThermalDiff { get; set; }
        public double? HDT { get; set; }
        public int LoggedInUserId { get; set; } 
    } 
}
