namespace GDS.Entities.STMP.PlantEquipmentList
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class STMPPlantEquipmentListModel
    {
        public int? PlantId { get; set; }
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
        //public string SearchFor { get; set; }
        //public string OrderByColumn { get; set; }
        //public bool OrderByDirection { get; set; }
        public Int64 PlantEquipmentListId { get; set; }
        public string PlantName_PressSpecification { get; set; }
        public string PlantName { get; set; }
        public string PressNumber { get; set; }
        public string PressManufacturer { get; set; }
        public string PressModel { get; set; }
        public string PressSerial { get; set; }
        public decimal? Tonnage { get; set; }
        public string PressYear { get; set; }
        public decimal? MaxPressure_PSI { get; set; }
        public decimal? Intensification { get; set; }
        public string BarrelCapacity_OZ { get; set; }
        public decimal? ScrewDiameter_IN { get; set; }
        public decimal? MaxInjectionStroke_IN { get; set; }
        public decimal? MaxInjectionSpeed_IN { get; set; }
        public string TieBarsHxV { get; set; }
        public string TieBarHorizontal { get; set; }
        public string TieBarVertical { get; set; }
        public decimal? PlatenHorizontal { get; set; }
        public decimal? PlatenVertical { get; set; }
        public string PlatenHXV { get; set; }
        public string DieHeight { get; set; }
        public string DayLight { get; set; }
        public string ClampStyle { get; set; }
        public string Robot { get; set; }
        public int? RobotYear { get; set; }
        public string RobotModel { get; set; }
        public string RobotSerial { get; set; }
        public long TotalCount { get; set; }
        public long RowNumber { get; set; }
        public string QMCMethod { get; set; }
        public string ShopLogixPressNumber { get; set; }
        public bool? IsActiveInAMP { get; set; }
        public bool? IsHavingIssue { get; set; }
    }

    public class PlantEquipmentForDDLModel
    {
        public int PlantId { get; set; }
        public string PressNumber { get; set; }
        public long PlantEquipmentListId { get; set; }
    }
}