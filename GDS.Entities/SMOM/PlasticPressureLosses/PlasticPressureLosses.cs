namespace GDS.Entities.SMOM.PlasticPressureLosses
{
    public class ColdRunnerSystemModel
    {
        public long ColdRunnerSystemId { get; set; }
        public long CoverPageId { get; set; }
        public double Hydraulic_PressureToPurgeShotThroughNozzle { get; set; }
        public double Hydraulic_PressureToFillNozzleSprueAndRunner { get; set; }
        public double Hydraulic_PressureToFillNozzleSprueAndRunnerPlusGate { get; set; }
        public double Hydraulic_TotalPressureNeededToFillPart95To98PerFull { get; set; }
        public double AllowablePressureDrop_Nozzle { get; set; }
        public double AllowablePressureDrop_SprueAndRunner { get; set; }
        public double AllowablePressureDrop_PartGate { get; set; }
        public double AllowablePressureDrop_Part { get; set; }
        public int LoggedInUserId { get; set; }
        public byte? ValidationStatusCode { get; set; }
    }

    public class HotRunnerModel
    {
        public long HotRunnerId { get; set; }
        public long CoverPageId { get; set; }
        public double Hydraulic_PressureToPurgeShotThroughNozzle { get; set; }
        public double Hydraulic_PressueToFillThroughDrops { get; set; }
        public double Hydraulic_TotalPressureNeededToFillPart95To98PerFull { get; set; }
        public double AllowablePressureDrop_Nozzle { get; set; }
        public double AllowablePressureDrop_Manifold { get; set; }
        public double AllowablePressureDrop_Part { get; set; }
        public int LoggedInUserId { get; set; }
        public byte? ValidationStatusCode { get; set; }
    }

    public class HotDropToColdRunner
    {
        public long HotDropToColdRunnerId { get; set; }
        public long CoverPageId { get; set; }
        public double Hydraulic_PressureToPurgeShotThroughNozzle { get; set; }
        public double Hydraulic_PressureToFillManifoldIntoRunners { get; set; }
        public double Hydraulic_PressureToFillManifoldPlusRunnerGatePlusPartGate { get; set; }
        public double Hydraulic_TotalPressureNeededToFillPart95To98PerFull { get; set; }
        public double AllowablePressureDrop_Nozzle { get; set; }
        public double AllowablePressureDrop_ManifoldPlusRunnerGate { get; set; }
        public double AllowablePressureDrop_PartGate { get; set; }
        public double AllowablePressureDrop_Part { get; set; }
        public int LoggedInUserId { get; set; }
        public byte? ValidationStatusCode { get; set; }
    }
}
