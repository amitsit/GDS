
namespace GDS.Entities.SMOM.LinearityResults
{
    public class LinearityResultsModel
    {
        public int PlantId { get; set; }
        public int Shot { get; set; }
        public long PlantEquipmentListId { get; set; }
        public long CoverPageId { get; set; }
        public int Percentage { get; set; }
        public double FillSpeed { get; set; }
        public double FillTime { get; set; }
        public double ExpectedFillTime { get; set; }
        public double? ActualSpeed { get; set; } 
        public double InjectionPressure { get; set; }
        public double? PercentDifference { get; set; }
        public double ActualCublicFlowRate { get; set; }
        public double TheorCublicFlowRate { get; set; }
        public string MaterialCode { get; set; }

        
        //General Information
        public double ScrewArea { get; set; }
        public double ScrewPosition { get; set; }
        public double TransferPosition { get; set; }
        public double Stroke { get; set; }
        public double Cubic { get; set; }

        //Load Sensitivity
        public double AirShotFillTime { get; set; }
        public double AirShotFillPressure { get; set; }
        public double PercentKPSI { get; set; }

        //Temperature Study
        public string FrontZoneTemp { get; set; }
        public double MeltTemp { get; set; }
        public double TempDifference { get; set; }

        //System Leakage
        public double WeightRunner { get; set; }
        public double ShotLeakageAvg { get; set; }
        public double PercentLeakage { get; set; }

    }
}
