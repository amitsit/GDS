namespace GDS.Entities.Master
{
    public class WallStockModel
    {
        public int WallStockId { get; set; }
        public int MaterialTypeId { get; set; }
        public double FromRange { get; set; }
        public double? ToRange { get; set; }
        public double Value { get; set; }
        public decimal LoggedInUserId { get; set; }
        public string MaterialTypeCode { get; set; }
        public string MaterialTypeDescription { get; set; }
        public string RangeType { get; set; }
        public int WallStockCTPartRangeId { get; set; }
        public string FromToRangeValue { get; set; }
    }
    
    public class WallStockCTPartRange
    {
        public int WallStockCTPartRangeId { get; set; }
        public string RangeValue { get; set; }
        public string Type { get; set; }
    }
}
