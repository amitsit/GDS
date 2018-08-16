using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.RecoveryTimeStudy
{
    public class RecoveryTimeStudyModel
    {
        public long RecoveryTimeStudyId { get; set; }
        public long CoverPageId { get; set; }
        public double? ShotSize { get; set; }
        public double? ScrewRPM { get; set; }
        public double? BackPressure { get; set; }
        public double? ScrewRecoveryTime { get; set; }
        public int LoggedInUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? ValidationStatusCode { get; set; }
        public List<RecoveryAdditionalParaList> AdditinalPrametersList { get; set; }
    }

    public class RecoveryAdditionalParaList
    {
        public int TrialNumber { get; set; }
        public string TrialName { get; set; }
        public double? MeltTempVariable { get; set; }
        public double? BackPressureVariable { get; set; }
        public double? ScrewRPMVariable { get; set; }
        public double? RecoveryTimeVariable { get; set; }
        public string Note { get; set; }
    }

}
