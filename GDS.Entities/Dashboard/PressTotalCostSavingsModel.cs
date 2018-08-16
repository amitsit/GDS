namespace GDS.Entities.Dashboard
{
    public class PressTotalCostSavingsModel
    {
        public int? TonnageFrom { get; set; }
        public int? TonnageTo { get; set; }
        public int? NumberOfPress { get; set; }
        public double? PowerSavings { get; set; }
        public double? LaborSavings { get; set; }
        public double? MROSavings { get; set; }
        public string TonnageToDisplay { get; set; }
    }

    public class PressTotalCostSavingsInputModel
    {
        public string PlantIdString { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public int UserId { get; set; }
        public bool IsPlantSpecific { get; set; }
        public string WeekString { get; set; }
        public double? MaxUtilizationTarget { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
        public int AssumedShiftsperMachine { get; set; }
        public bool IsMachineIdle { get; set; }
        public bool IsavingsNewMachineCost { get; set; }
        public bool IsPlantWeigtedWageBlank { get; set; }
        public bool RemoveUpdateCosts { get; set; }
    }
}
