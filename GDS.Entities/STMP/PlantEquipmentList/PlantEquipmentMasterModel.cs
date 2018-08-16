using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.STMP.PlantEquipmentList
{
    public class PlantEquipmentMasterModel
    {
        public long PlantEquipmentListId { get; set; }
        public int PlantId { get; set; }
        public string PressNumber { get; set; }
        public string PressManufacturer { get; set; }
        public string PressModel { get; set; }
        public string PressSerial { get; set; }
        public decimal? Tonnage { get; set; }
        public string PressYear { get; set; }
        public string MaxPressure_PSI { get; set; }
        public string Intensification { get; set; }
        public string BarrelCapacity_OZ { get; set; }
        public string ScrewDiameter_IN { get; set; }
        public string MaxInjectionStroke_IN { get; set; }
        public string MaxInjectionSpeed_IN { get; set; }
        public string TieBarHXV { get; set; }
        public string TieBarHorizontal { get; set; }
        public string TieBarVertical { get; set; }
        public string PlatenHXV { get; set; }
        public string PlatenHorizontal { get; set; }
        public string PlatenVertical { get; set; }
        public string DieHeight { get; set; }
        public string DayLight { get; set; }
        public string ClampStyle { get; set; }
        public string Robot { get; set; }
        public string RobotYear { get; set; }
        public string RobotModel { get; set; }
        public string RobotSerial { get; set; }
        public int LoggedInUserId { get; set; }
        public string PlantName_PressSpecification { get; set; }
        public string PlantName { get; set; }
        public string TieBarsHxV { get; set; }        
        public long? TotalCount { get; set; }
        public long? RowNumber { get; set; }
        public string QMCMethod { get; set; }
        public string ShopLogixPressNumber { get; set; }
        public bool? IsActiveInAMP { get; set; }
        public bool? IsHavingIssue { get; set; }
    }

    public class PlantEquipmentColumnListModel {
        public string ColName { get; set; }
        public string DispName { get; set; }
    }
}
