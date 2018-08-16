namespace GDS.Entities.STMP.CapacityChart
{
    public class CreateScenario
    {
    }

    public class CreateScenarioInputParams
    {
        public int ScenarioHeaderId { get; set; }
        public string ScenarioName { get; set; }
        public int PlantId { get; set; }
        public double? MoldingManning { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }
        public double? Utilization { get; set; }
        public int LoggedInUserId { get; set; }
    }

}
