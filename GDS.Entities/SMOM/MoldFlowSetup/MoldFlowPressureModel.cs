using GDS.Entities.Master;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowPressureModel : UnitTypeModel
    {
        public long MoldFlowPressureId { get; set; }
        public long MoldFlowGeneralInfoId { get; set; }
        public double? HydraulicTransfer { get; set; }
        public double? PlasticTransfer { get; set; }
        public double? HydaulicHold { get; set; }
        public double? PlasticHold { get; set; }
        public double? HydraulicPack { get; set; }
        public double? PlasticPack { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
