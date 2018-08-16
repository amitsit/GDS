using GDS.Entities.Master;
using System;

namespace GDS.Entities.SMOM.ConversionSetup
{
    public class ConversionSetupModel
    {
    }

    public class ConversionSetupSaveModel
    {
        public int? MoldFlowSetupHeaderId { get; set; }
        public int? MoldFlowPlantId { get; set; }
        public long? MoldFlowPlantEquipmentListId { get; set; }
        public int? SelectedPlantId { get; set; }
        public long? SelectedPlantEquipmentListId { get; set; }
        public int UserId { get; set; }
    }

    public class ConversionSetupParameter : UnitTypeModel
    {
        public long? InitDataPlantId { get; set; }
        public long? InitDataPlantEquipmentId { get; set; }
        public long? InitDataMoldFlowSetupHeaderId { get; set; }
        public long? SelectedMachinePlantId { get; set; }
        public long? SelectedMachinePlantEquipmentId { get; set; }
        public long? InitDataGeneralInfoId { get; set; }
    }


    public class ConSetupGeneralInfo : UnitTypeModel
    {
        public long? InitDataGeneralInfoId { get; set; }
        public int? PlantId { get; set; }
        public string MoldNumber { get; set; }
        public string JobName { get; set; }
        public long? PlantEquipmentListId { get; set; }
        public DateTime Date { get; set; }
        public int? MaterialId { get; set; }
        public double? MeltTempInput { get; set; }
        public int LoggedInUserId { get; set; }
        public int? MoldFlowSetupHeaderId { get; set; }
        public string IdentificationText { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }

    }

    public class ConversionShotPositionModel
    {
        public double? ShotSize { get; set; }
        public double? Transfer { get; set; }
        public double? Decompress { get; set; }
        public double? Cushion { get; set; }
        public double? FillCubicVolume { get; set; }
        public double? TotalCubicVolume { get; set; }
    }

    public class ConversionPressureModel
    {
        public double? HydraulicTransfer { get; set; }
        public double? HydraulicPack { get; set; }
        public double? HydraulicHold { get; set; }
        public double? HydraulicBack { get; set; }
        public double? PlasticTransfer { get; set; }
        public double? PlasticPack { get; set; }
        public double? PlasticHold { get; set; }
        public double? PlasticBack { get; set; }
        public double? Tonnage { get; set; }
    }

    public class ConversionShotWeightModel
    {
        public double? TransferCAV1LH { get; set; }
        public double? TransferCAV2LH { get; set; }
        public double? TransferCAV3LH { get; set; }
        public double? TransferCAV4LH { get; set; }
        public double? TransferWeightRunner { get; set; }
        public double? FullPartCAV1LH { get; set; }
        public double? FullPartCAV2LH { get; set; }
        public double? FullPartCAV3LH { get; set; }
        public double? FullPartCAV4LH { get; set; }
        public double? FullPartWeightRunner { get; set; }

    }

    public class ConversionTimerModel
    {
        public double? Fill { get; set; }
        public double? Pack { get; set; }
        public double? Hold { get; set; }
        public double? Cooling { get; set; }
        public double? ScrewRecovery { get; set; }
        public double? ClampClose { get; set; }
        public double? ClampOpen { get; set; }
        public double? CycleTime { get; set; }
        public double? RobotTakeOut { get; set; }

    }

    public class ConversionBarrelTempModel
    {
        public double? Nozzle { get; set; }
        public double? Valve { get; set; }
        public double? FrontZone { get; set; }
        public double? MidFront { get; set; }
        public double? MidRear { get; set; }
        public double? RearZone { get; set; }
        public string InitDataPlantName { get; set; }
        public string InitDataPressName { get; set; }
        public double? MeltTempInput { get; set; }
    }

    public class ConversionHotRunnerModel
    {
        public int ZoneNumber { get; set; }
        public string Zone { get; set; }
        public double? Temperature { get; set; }
    }

    public class ConversionValveGatePositionModel
    {
        public byte SVG { get; set; }
        public double? PositionOpen { get; set; }
        public double? PositionClose { get; set; }
        public double? PositionPackTime { get; set; }
        public double? TimeOpen { get; set; }
        public double? TimeClose { get; set; }
        public double? TimePackTime { get; set; }
    }

    public class ConversionFillStagesModel
    {
        public double? ScrewArea { get; set; }
        public double? ScrewArea_mm { get; set; }
        public double? InitDataScrewArea { get; set; }
        public double? InitDataScrewArea_mm { get; set; }
        public double? Velocity_Xferpos { get; set; }
        public double? Velocity4 { get; set; }
        public double? Velocity3 { get; set; }
        public double? Velocity2 { get; set; }
        public double? Velocity1 { get; set; }
        public double? Position_Xferpos { get; set; }
        public double? Position4 { get; set; }
        public double? Position3 { get; set; }
        public double? Position2 { get; set; }
        public double? Position1 { get; set; }
        public double? CubicFlow_Xferpos { get; set; }
        public double? CubicFlow4 { get; set; }
        public double? CubicFlow3 { get; set; }
        public double? CubicFlow2 { get; set; }
        public double? CubicFlow1 { get; set; }
        public double? ConvertedVelocity_Xferpos { get; set; }
        public double? ConvertedVelocity4 { get; set; }
        public double? ConvertedVelocity3 { get; set; }
        public double? ConvertedVelocity2 { get; set; }
        public double? ConvertedVelocity1 { get; set; }
        public double? ConvertedPosition_Xferpos { get; set; }
        public double? ConvertedPosition4 { get; set; }
        public double? ConvertedPosition3 { get; set; }
        public double? ConvertedPosition2 { get; set; }
        public double? ConvertedPosition1 { get; set; }
        public double? ConvertedCubicFlow_Xferpos { get; set; }
        public double? ConvertedCubicFlow4 { get; set; }
        public double? ConvertedCubicFlow3 { get; set; }
        public double? ConvertedCubicFlow2 { get; set; }
        public double? ConvertedCubicFlow1 { get; set; }
        public string ReasonForProfile { get; set; }

    }

    public class ConversionMoldTempModel
    {
        public double? Stationary_1 { get; set; }
        public double? Stationary_2 { get; set; }
        public double? Moveable_1 { get; set; }
        public double? Moveable_2 { get; set; }
    }
}
