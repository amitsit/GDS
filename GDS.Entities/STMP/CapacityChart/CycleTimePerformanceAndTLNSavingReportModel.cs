namespace GDS.Entities.STMP.CapacityChart
{
    public class CycleTimePerformanceAndTLNSavingReportModel
    {
        public int PlantId { get; set; }
        public int UserId { get; set; }
        public int ScenarioHeaderId { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public double? STDCYC { get; set; }
        public string WeekString { get; set; }
        public double? MoldingManning { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }

        public int? NumberOfActiveMold { get; set; }
        public int? NumberOfMoldsBICCT { get; set; }
        public int? NumberMoldsWCCT { get; set; }
        public int? WeeklyLaborHrsSaved { get; set; }
        public int? WeeklyPressHrsSaved { get; set; }

       
    }
}
