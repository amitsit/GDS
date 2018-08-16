using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GDS.Entities.SMOM.InitialDataConversionSetup
{
    public class InitialDataConversionSetupModel
    {
        public long? MoldFlowGeneralInfoId{ get; set; }
        public int? PlantId{ get; set; }
        public string PlantName{ get; set; }
		public string MoldNumber{ get; set; }
		public string JobName{ get; set; }
		public long? PlantEquipmentListId{ get; set; }
		public string PressNumber{ get; set; }
		public Nullable<DateTime> Date{ get; set; }
		public int? MaterialId{ get; set; }
		public int? MoldFlowSetupHeaderId{ get; set; }
		public string MeltTemp{ get; set; }
        public string MoldTemp { get; set; }
        public int? SelectedPlantId { get; set; }
        public long? SelectedPlantEquipmentListId { get; set; }
        public bool? IsFinalized { get; set; }
        public long? ProgramID { get; set; }
        public bool? IsPushedToProducton { get; set; }

    }

    public class InitDataGeneralInfoModel : UnitTypeModel
    {
        public long InitDataGeneralInfoId { get; set; }
        public int? PlantId { get; set; }
        public string MoldNumber { get; set; }
        public string JobName { get; set; }
        public long? PlantEquipmentListId { get; set; }
        public  Nullable<DateTime> Date { get; set; }
        public int? MaterialId { get; set; }
        public double? MeltTempInput { get; set; }
        public int LoggedInUserId { get; set; }
        public int? MoldFlowSetupHeaderId { get; set; }
        public string IdentificationText { get; set; }


        public string Ejectors { get; set; }
        public string Cores { get; set; }
        public string SpecialNote_Issue { get; set; }

        public bool? IsFinalized { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }
        public int? InputDataPlantId { get; set; }
        public string InputDataPlantName { get; set; }

        public long? ProgramID { get; set; }

        public bool? IsExistingMold { get; set; }
        public long? InputDataId { get; set; }
        public bool? IsPushedToProducton { get; set; }
    }


    public class BarrelTempSettingModel : UnitTypeModel
    {
        public long InitDataBarrelTempSetttingId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
        public double? Nozzle { get; set; }
        public double? Valve { get; set; }
        public double? FrontZone { get; set; }
        public double? MidFront { get; set; }
        public double? MidRear { get; set; }
        public double? RearZone { get; set; }
        public int LoggedInUserId { get; set; }
        public double? MeltTempInput { get; set; }

    }

    public class InitDataShotPositionModel : UnitTypeModel
    {
        public long InitDataShotPositionsId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
        public double? ShotSize { get; set; }
        public double? Transfer { get; set; }
        public double? Decompress { get; set; }
        public double? Cushion { get; set; }
        public double? FillCubicVolume { get; set; }
        public double? TotalCubicVolume { get; set; }
        public int LoggedInUserId { get; set; }
    }

    public class InitDataHotRunnerModel : UnitTypeModel
    {
        public long InitDataGeneralInfoId { get; set; }
        public int LoggedInUserId { get; set; }
        public List<InitDataHotRunnerList> HotRunnerList { get; set; }

    }

    public class InitDataHotRunnerList
    {
        public int ZoneNumber { get; set; }
        public string Zone { get; set; }
        public double? Temperature { get; set; }
    }


    public class InitDataShotWeightModel : UnitTypeModel
    {
        public long InitDataShotWeightId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
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
        public int LoggedInUserId { get; set; }
    }

    public class InitDataMoldTempModel : UnitTypeModel
    {
        public long InitDataMoldTempId { get; set; }
        public long InitDataGeneralInfoId { get; set; }

        public double? Stationary_1 { get; set; }
        public double? Stationary_2 { get; set; }
        public double? Moveable_1 { get; set; }
        public double? Moveable_2 { get; set; }
        public double? Misc_1 { get; set; }
        public double? Misc_2 { get; set; }

        public int LoggedInUserId { get; set; }
    }

    public class InitDataPressureModel : UnitTypeModel
    {
        public long InitDataPressureId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
        public double? Transfer { get; set; }
        public double? Pack { get; set; }
        public double? Hold { get; set; }
        public double? Back { get; set; }
        public double? Tonnage { get; set; }
        public int LoggedInUserId { get; set; }
    }

    public class InitDataTimerModel
    {
        public long InitDataTimerId { get; set; }
        public long InitDataGeneralInfoId { get; set; }
        public double? Fill { get; set; }
        public double? Pack { get; set; }
        public double? Hold { get; set; }
        public double? Cooling { get; set; }
        public double? ScrewRecovery { get; set; }
        public double? ClampClose { get; set; }
        public double? ClampOpen { get; set; }
        public double? CycleTime { get; set; }
        public double? RobotTakeOut { get; set; }
        public int LoggedInUserId { get; set; }
    }

    public class LoadInitDataFromMoldFlowSetupModel
    {
        public long MoldFlowSetupId { get; set; }

        // General Information
        public int? PlantId{ get; set; }
        public long? PlantEquipmentListId { get; set; }
        public int? MaterialId { get; set; }

        // Shot position 
        public double? ShotSize { get; set; }
        public double? Transfer { get; set; }
        public double? Cushion { get; set; }

        // Pressure
        public double? HydraulicTransfer { get; set; }
        public double? HydraulicPack { get; set; }
        public double? HydaulicHold { get; set; }
        public double? Tonnage { get; set; }

        // Mold Temp
        public double? Stationary { get; set; }
        public double? Moveable { get; set; }

        // Timer 
        public double? Fill { get; set; }
        public double? Pack { get; set; }
        public double? Hold { get; set; }
        public double? Cooling { get; set; }

        public List<ValveGatePositionRecord> ValveGatePositionList { get; set; }

        private string ValveGateStr
        {
            set
            {
                ValveGatePositionList = !string.IsNullOrEmpty(value)
                    ? Common.Utility.DeserializeFromXMLNew<ValveGatePosition>(value).ValveGatePositionList
                    : new List<ValveGatePositionRecord>();
            }
        }

    }

    [XmlRoot("ValveGatePosition")]
    public class ValveGatePosition
    {
        public ValveGatePosition() { ValveGatePositionList = new List<ValveGatePositionRecord>(); }

        [XmlElement("ValveGatePositionRecord", typeof(ValveGatePositionRecord))]
        public List<ValveGatePositionRecord> ValveGatePositionList { get; set; }
    }

    public class ValveGatePositionRecord
    {
        [XmlElement("Zone")]
        public byte Zone { get; set; }

        [XmlElement("OpenPosition")]
        public double? OpenPosition { get; set; }

        [XmlElement("ClosePosition")]
        public double? ClosePosition { get; set; }

        [XmlElement("PackTime")]
        public double? PackTime { get; set; }
        
    }


    public class InitDataFillStagesModel : UnitTypeModel
    {
        public long InitDataFillStagesId { get; set; }
        public long InitDataGeneralInfoId { get; set; }

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
        public string ReasonForProfile { get; set; }
        public int LoggedInUserId { get; set; }
    }

    public class InitDataInputDataModel : UnitTypeModel
    {
        public long InitDataGeneralInfoId { get; set; }
        public int MoldFlowSetupHeaderId { get; set; }
        public bool? IsHistory { get; set; }
    }

    public class InitDataPushToProductionInputModel
    {
        public int? PlantId { get; set; }
        public string MoldNumber { get; set; }
        public int UserId { get; set; }
    }
}
