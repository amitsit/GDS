using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GDS.Entities.STMP.PlantEquipmentList
{
    public class STMPPlantEquipmentListMasterModel
    {
        public int? PlantId { get; set; }
        public string Plant { get; set; }
        public Int64? PlantEquipmentListId { get; set; }
        public string PlantName_PressSpecification { get; set; }
        [JsonProperty("Press #")]
        public string PressNumber { get; set; }
        [JsonProperty("Press Manufacturer")]
        public string PressManufacturer { get; set; }
        [JsonProperty("Press Model")]
        public string PressModel { get; set; }
        [JsonProperty("Press Serial #")]
        public string PressSerial { get; set; }
        public decimal? Tonnage { get; set; }
        [JsonProperty("Press Year")]
        public int? PressYear { get; set; }
        [JsonProperty("Max Pressure")]
        public decimal? MaxPressure_PSI { get; set; }
        public decimal? Intensification { get; set; }
        [JsonProperty("Barrel Capacity")]
        public decimal? BarrelCapacity_OZ { get; set; }
        [JsonProperty("Screw Diameter  Inches")]
        public decimal? ScrewDiameter_IN { get; set; }
        [JsonProperty("Max Injection Stroke  Inches")]
        public decimal? MaxInjectionStroke_IN { get; set; }
        [JsonProperty("Max Injection Speed  Inches")]
        public decimal? MaxInjectionSpeed_IN { get; set; }
        [JsonProperty("Tie Bars  HxV")]
        public string TieBarsHxV { get; set; }
        [JsonProperty("Tie Bar Horizontal")]
        public decimal? TieBarHorizontal { get; set; }
        [JsonProperty("Tie Bar Verical")]
        public decimal? TieBarVertical { get; set; }
        public decimal? PlatenHorizontal { get; set; }
        public decimal? PlatenVertical { get; set; }
        [JsonProperty("Platen  HxV")]
        public string PlatenHxV { get; set; }
        [JsonProperty("Die Height")]
        public decimal? DieHeight { get; set; }
        public decimal? DayLight { get; set; }
        [JsonProperty("Clamp Style")]
        public string ClampStyle { get; set; }
        public string Robot { get; set; }
        [JsonProperty("Robot Year")]
        public int? RobotYear { get; set; }
        [JsonProperty("Robot Model")]
        public string RobotModel { get; set; }
        [JsonProperty("Robot Serial #")]
        public string RobotSerial { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
