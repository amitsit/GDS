using GDS.Entities.Master;

namespace GDS.Entities.STMP.CapacityChart
{
    public class PlantUtilizationModel
    {
        public string Total { get; set; }
        public int? NumberOfPress { get; set; }
        public int? TonnageFrom { get; set; }
        public int? TonnageTo { get; set; }
        public double? UTZ { get; set; }
        public double? AVG_CYC { get; set; }
        public string TonnageToDisplay { get; set; }
        

        public double? DLTPERC { get; set; }
        public double? DLTSEC { get; set; }

        public double? IACBIC { get; set; }
        public double? WorldClass { get; set; }
        public double? MP { get; set; }

        public double? DefaultUTLZPercentage { get; set; }
        public double? Press_Utilization_REQ { get; set; }



        //public int UTZ_HRS  { get; set; }
        //public int AVAIL_HRS  { get; set; }
        //public double DEMAND  { get; set; }
        //public double CYC_SEC  { get; set; }
        //public int AVG_Year  { get; set; }
        //public double CAP  { get; set; }
        //public double Weight_TON { get; set; }
    }

    public class PlantUtilizationInputParamModel : UnitTypeModel
    {
        public int? ScenarioHeaderId { get; set; }
        public int PlantId { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public string STDCYC { get; set; }
        public int UserId { get; set; }
        public string WeekString { get; set; }
        public double? MoldingManning { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }
        public double? StdReliefDivisor { get; set; }
        public double? StdQuotedWeek { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
    }

}
