using GDS.Entities.Master;

namespace GDS.Entities.Dashboard
{
    public class PerformancesModel
    {
        public double? ACTHC { get; set; }
        public double? REQHC { get; set; }
        public double? HCOPP { get; set; }
        public double? COSTOPP { get; set; }
        public double? NoOfActiveMolds { get; set; }
        public double? NoOfMoldsAtBIC { get; set; }
        public double? NoOfMoldsAtWC { get; set; }
    }

    public class PerformancesInputModel : UnitTypeModel
    {
        public string PlantIdString { get; set; }
        public int? LoggedInUserId { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public string WeekString { get; set; }
        public bool IsPlantSpecific { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
    }

    public class ConfigurationMasterModel
    {
        public int PlantConfigurationId { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
    }
}
