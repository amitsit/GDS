namespace GDS.Entities.STMP.STMP_Configuration
{
    public class ScenarioHeaderModel
    {
        public long ScenarioHeaderId { get; set; }
        public string ScenarioName { get; set; }
        public int? PlantId { get; set; }
        public double? MoldingManning { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }
        public double? Utilization { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public int LoggedInUserId { get; set; }
        public int CreatedBy { get; set; }
        public string UserName { get; set; }
    }
}
