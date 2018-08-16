using GDS.Entities.Master;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowShotPositioinModel : UnitTypeModel
    {
        public long InitDataShotPositionsId { get; set; }
        public long MoldFlowGeneralInfoId { get; set; }
        public double? ShotSize { get; set; }
        public double? Transfer { get; set; }
        public double? Cushion { get; set; }
        public double? CubicVolumnTransfer { get; set; }
        public double? TotalCubicVolumn { get; set; }
        public int LoggedInUserId { get; set; }
        //Excel Sheet Data
        public double?  ShrinkRateMoldIsCutTo { get; set; }
        public double? MeltSolidRatio { get; set; }
        public double? VolumefromAnalysisin3 { get; set; }
      
    }
}
