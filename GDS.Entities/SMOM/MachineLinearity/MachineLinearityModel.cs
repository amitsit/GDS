using System.Collections.Generic;

namespace GDS.Entities.SMOM.MachineLinearity
{
    public class MachineLinearityModel
    {
        //Machine Configuration Details
        public int PlantId { get; set; }
        public long PlantEquipmentListId { get; set; }
        public long CoverPageId { get; set; }
        public string PressNumber { get; set; }
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
        public int LoggedInUserId { get; set; }
        public MachineLinearityPositionSetting PositionSettingDetails { get; set; }
        public List<MachineLinearityShotWithParts> ShotWithPartsList { get; set; }
        public List<MachineLinearityAirShot> AirShotList { get; set; }
    }

    public class MachineLinearityPositionSetting
    {
        public long MachineLinearityPositionSettingId { get; set; }
        public double? ShotSize { get; set; }
        public double? Decompress { get; set; }
        public double? Transfer { get; set; }
        public int? MaterialId { get; set; }
        public string Nozzle { get; set; }
        public string Valve { get; set; }
        public string FrontZone { get; set; }
        public string MidFront { get; set; }
        public string MidRear { get; set; }
        public string RearZone { get; set; }
         }

    public class MachineLinearityShotWithParts
    {
        public int Percentage { get; set; }
        public double UnitSystem { get; set; }
        public double? FillTime { get; set; }
        public double? FillPressure { get; set; }
        public double? WeightRunner { get; set; }
    }

    public class MachineLinearityAirShot
    {
        public int Percentage { get; set; }
        public double UnitSystem { get; set; }
        public double? FillTime { get; set; }
        public double? FillPressure { get; set; }
        public double? MeltTemp { get; set; }
    }
}