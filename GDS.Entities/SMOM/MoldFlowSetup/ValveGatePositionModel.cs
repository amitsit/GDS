namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class ValveGatePositionModel
    {
        public long ValveGatePositionId { get; set; }
        public long MoldFlowGeneralInfoId { get; set; }
        public byte Zone { get; set; }
        public string ZoneName { get; set; }
        public double? OpenVolumePercentage { get; set; }
        public double? CloseVolumePercentage { get; set; }
        public double? OpenPosition { get; set; }
        public double? ClosePosition { get; set; }
        public double? PackTime { get; set; }
        public double? VIPVolume { get; set; }
        public double? ShrinkFactor { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
