using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CorpIMPD
{
    public class CorpIMPDModel
    {
        public long MachineInformationId { get; set; }
        public long CoverPageId { get; set; }
        public int MaterialTypeId { get; set; }
        public string MoldNumber { get; set; }
        public string PartDescription { get; set; }
        public int? PlantId { get; set; }
        public string PressNumber { get; set; }
        public double? NominalWallThickness { get; set; }
        public double? GateWidth { get; set; }
        public double? GateDepth { get; set; }
        public double? GateLand { get; set; }
        public double? GateDiameter { get; set; }
        public double? NoOfHotRunnerZones { get; set; }
        public double? HotRunnerTempSetPoint { get; set; }
        public double? NoOfValveGates { get; set; }
        public long? IACMoldNumber { get; set; }
        public double? NoOfCavities { get; set; }
        public double? NoOfGatesorCavity { get; set; }
        public double? NozzleLength { get; set; }
        public double? NozzleOrifice { get; set; }
        public double? ThermolatorStationary { get; set; }
        public double? ThermolatorMoving { get; set; }
        public double? ThermolatorSpeakerOrLifter { get; set; }
        public double? TonnageSetPoint { get; set; }
        public int LoggedInUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
