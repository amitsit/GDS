using GDS.Entities.Master;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class ManualInputModel : UnitTypeModel
    {
        public long ManualInputId { get; set; }
        public long MoldFlowGeneralInfoId { get; set; }
        public double? MeltTemp { get; set; }
        public double? MoldCavitySideTemp { get; set; }
        public double? MoldCoreSideTemp { get; set; }
        public double? NominalFlowRate { get; set; }
        public double? TotalVolumeOfThePartsAndRunners { get; set; }
        public double? SwitchOverPressure { get; set; }
        public double? MaxClampForceRequired { get; set; }
        public double? VolumeFilledInitially { get; set; }
        public double? VolumeToBeFilled { get; set; }
        public double? TotalProjectedArea { get; set; }
        public double? ClampForceMaximum { get; set; }
        public double? TotalPartWeightExcludingRunners { get; set; }
        public double? TotalPartWeightMaximum { get; set; }
        public double? MaximumInjectionPressure { get; set; }

        public double? TimeAtTheEndOfFilling { get; set; }
        public double? TotalWeightPartsPlusRunnersFillWeight { get; set; }
        public double? TotalWeightExcludingRunnersFillWeight { get; set; }
        public double? PackingPhase { get; set; }

        public int LoggedInUserId { get; set; }
    }
}
