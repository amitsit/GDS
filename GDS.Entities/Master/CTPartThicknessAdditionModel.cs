namespace GDS.Entities.Master
{
    public class CTPartThicknessAdditionModel
    {
        public long CTPartThicknessAdditionId { get; set; }
        public int? PlantId { get; set; }
        public int? PlantMonthYearId { get; set; }
        public decimal FromRangeMM { get; set; }
        public decimal ToRangeMM { get; set; }
        public decimal CTValue { get; set; }
        public bool IsActive { get; set; }
        public int LoggedInUserId { get; set; }
        public string PlantName { get; set; }
    }
}
