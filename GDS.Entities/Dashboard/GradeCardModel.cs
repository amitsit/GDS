namespace GDS.Entities.Dashboard
{
    public class GradeCardModel
    {
        public int? PlantID { get; set; }
        public string PlantName { get; set; }
        public double? PlantCycle { get; set; }
        public double? Efficiency { get; set; }
        public double? Tonnage { get; set; }
        public string ClassName { get; set; }
    }

    public class GradeCardInputModel
    {
        public string PlantIdString { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public int? UserId { get; set; }
        public string WeekString { get; set; }
        public bool IsPlantSpecific { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
    }

    public class GradeCardChartModel
    {
        public string Json { get; set; }
        public string Labels { get; set; }
    }
}
