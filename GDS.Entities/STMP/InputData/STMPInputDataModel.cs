namespace GDS.Entities.STMP.InputData
{
    public class STMPInputDataModel
    {
        public long InputDataId { get; set; }
        public long? PlantMonthYearId { get; set; }
        public int? PlantId { get; set; }
       // public long? ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string PlantName { get; set; }
        public string Tool { get; set; }
        public string PartDescription { get; set; }
        public string MoldOEE { get; set; }
        public double? TotalMoldCavites { get; set; }
        public double? CostedCycle { get; set; }
        public double? ActualCycle { get; set; }
        public double? CavityInVehicleSets { get; set; }
        public double? RequiredOps { get; set; }
        public double? Value { get; set; }
        public int? CurrnetUser { get; set; }

        public bool? IsActiveMold { get; set; }
        public bool IsMoldsBICCT { get; set; }
        public bool IsMoldsWCCT { get; set; }
        public bool? IsActiveSMOM { get; set; }

        public int TotalRecords { get; set; }
        public string ProgramIds { get; set; }
    }
}
