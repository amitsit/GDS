namespace GDS.Entities.STMP.ReplacementSavings
{

    public class ReplacementSavingsModel
    {
        public int TonnageRangeId { get; set; }
        public int TONS { get; set; }
        public int IACBIC { get; set; }
        public int WorldClass { get; set; }
        public int MidPoint { get; set; }
        public double? HeadCount { get; set; }
        public double? SavingNewMachineCost1 { get; set; }
        public double? SavingNewMachineCost2 { get; set; }
        public double? StaticValuePowerCost120HRSRun { get; set; }
        public double? StaticValuePowerCost120HRSIdle { get; set; }
        public double? PowerCost120HRSRun { get; set; }
        public double? PowerCost120HRSIdle { get; set; }
        public double? BlendedLaborWage { get; set; }
        public double? PerPressHourlyLabor { get; set; }
        public double? MROCostSavingRun { get; set; }
        public double? MROCostSavingIdle { get; set; }
    }

    public class ReplacementSavingsInputModel
    {
        public int AssumedShiftsperMachine { get; set; }
        public bool IsMachineIdle { get; set; }
        public bool IsavingsNewMachineCost { get; set; }
        public bool IsPlantWeigtedWageBlank { get; set; }
        public int? LoggedInUserId { get; set; }
    }
}
