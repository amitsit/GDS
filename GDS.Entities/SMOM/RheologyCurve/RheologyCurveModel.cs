
namespace GDS.Entities.SMOM.RheologyCurve
{
    public class RheologyCurveModel
    {
        public int Percentage { get; set; }
        public double FillSpeed { get; set; }
        public double FillTime { get; set; }
        public double FillPressure { get; set; }
        public double PeakPlasticPressure { get; set; }
        public double DivideFillTime { get; set; }
        public double RelativeViscosity { get; set; }
        public int RheologyCurveId { get; set; }
        public double? ProductionInjectionSpeed { get; set; }
    }

    public class RheologyCurvePostModel
    {
        public int RheologyCurveId { get; set; }
        public double? ProductionInjectionSpeed { get; set; }
        public int LoggedInUserId { get; set; }
        public int CoverPageId { get; set; }
    }
}
