using System;
namespace GDS.Entities.Master
{
    public class PlantMasterModel
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public string PlantIdCsv { get; set; }
        public string PlantName_PressSpecification { get; set; }
        public string PlantName_QAD { get; set; }
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string UnitSystemName { get; set; }
        public string LengthUnitName { get; set; }
        public int? CountryID { get; set; }
        public string Location { get; set; }
        public byte? UnitSystemId { get; set; }
        public byte? LengthUnit { get; set; }
        public byte? PressureUnit { get; set; }
        public double? StdPerfomanceGoal { get; set; }
        public double? AllPerformanceGoal { get; set; }
        public double? HeadCount { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }
        public double? MoldingManning { get; set; }
        public double? DefaultUTLZPercentage { get; set; }
        public string PlantColor { get; set; }
        public bool IsActive { get; set; }
        public int LoggedInUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public double? StdReliefDivisor { get; set; }
        public double? StdQuotedWeek { get; set; }
        public long? ScenarioHeaderId { get; set; }
        public string InjectionMoldingAreaId { get; set; }
        public bool? IsSelected { get; set; }
        public int? SaasId { get; set; }

    }
}
