namespace GDS.Entities.STMP.CapacityChart
{
    public class PressManSummaryModel
    {
        public double? GrindingManRequired { get; set; }
        public double? PressManRequired { get; set; }
        public double? ReliefManRequired { get; set; }
        public double? PressManHoursReq { get; set; }
        public double? PressManHoursUtilized { get; set; }
        public double? ReliefManHoursReq { get; set; }
        public double? TotalManHoursReq { get; set; }
        public double? TotalUtilizationHours { get; set; }
        public double? FlexHoursReq { get; set; }
        public double? MoldingManning { get; set; }
        public double? RequiredManning { get; set; }
        public double? Difference { get; set; }
        public double? Headcount { get; set; }
        public double? Trapped { get; set; }
        public double? LaborOpportunity { get; set; }
        public double? OTOpportunity { get; set; }
    }
}
