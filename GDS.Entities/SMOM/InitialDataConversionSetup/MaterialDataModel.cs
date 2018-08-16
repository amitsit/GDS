namespace GDS.Entities.SMOM.InitialDataConversionSetup
{
    public class MaterialDataModel
    {
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; }
        public double? MeltLow { get; set; }
        public double? MeltHigh { get; set; }
        public double? MoldTempLow { get; set; }
        public double? MoldTempHigh { get; set; }
    }
}
