using GDS.Entities.SMOM.MachineLinearity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CoverPage
{
    public class CoverPageModel
    {
        public long CoverPageId { get; set; }
        public long CoverPageIdTool { get; set; }
        public long CoverPageIdPress { get; set; }
        public int? PlantId { get; set; }
        public int? PlantEquipmentListId { get; set; }
        public long? InputDataId { get; set; }
        public DateTime? CoverPageDate { get; set; }
        public int LoggedInUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }
        public string Tool { get; set; }
        public string IdentificationText { get; set; }
        public int? VersionNo { get; set; }
        public bool MoldflowShow { get; set; }
        public bool NeedExistingMoldOnly { get; set; }
        public double? StdPerfomanceGoal { get; set; }
        public double? AllPerformanceGoal { get; set; }
        public int? MoldFlowSetupHeaderId { get; set; }
    }

    public class CoverPageMachineConfigurationModel
    {
        public CoverPageMachineConfiguration CoverPageMachineConfigurationDetails { get; set; }
        public MachineLinearityPositionSetting PositionSettingDetails { get; set; }
        public List<MachineLinearityShotWithParts> ShotWithPartsList { get; set; }
        public List<MachineLinearityAirShot> AirShotList { get; set; }
    }

    public class CoverPageMachineConfiguration
    {
        public long? CoverPageId { get; set; }
        public int? PlantId { get; set; }
        public long? ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Part { get; set; }
        public DateTime CoverPageDate { get; set; }
        public int? InputDataId { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }
        public string Tool { get; set; }
        public long? PlantEquipmentListId { get; set; }
        public string PressManufacturer { get; set; }
        public double? Tonnage { get; set; }
        public string PressYear { get; set; }
        public string ClampStyle { get; set; }
        public string TieBarsHXV { get; set; }
        public string PlatenHXV { get; set; }
        public string DieHeight { get; set; }
        public string DayLight { get; set; }
        public double? ScrewDiameter { get; set; }
        public double? ScrewArea { get; set; }
        public string Intensification { get; set; }
        public double? MaxHydraulicPressure { get; set; }
        public double? BarrelCapacity { get; set; }
        public double? MaxInjectionSpeed { get; set; }
        public double? MaxInjectionStroke { get; set; }

        public int? MoldId { get; set; }
        public int? VersionNo { get; set; }
        public string IdentificationText { get; set; }
        public long? CoverPageIdTool { get; set; }
    }

    public class CoverPageMoldFlow
    {
        public long CoverPageId { get; set; }
        public string MoldNumber { get; set; }
        public string JobName { get; set; }
        public string IdentificationText { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LoggedInUserId { get; set; }
    }

    public class IMPDRedirectParamsFromInputDataId
    {
        public int MoldFlowSetupHeaderId { get; set; }
        public string MoldFlowNumber { get; set; }
        public long ProgramId { get; set; }
        public int ConversionMode { get; set; }
        public string RedirectToCurrentSetup { get; set; }
    }
}
