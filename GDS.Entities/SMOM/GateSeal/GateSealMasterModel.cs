using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM
{
    public class GateSealMasterModel
    {
        #region Instance Properties
        public int GateSealId { get; set; }
        public int UserId { get; set; }    
        public long? CoverPageId { get; set; }
        public double? NoOfCavities { get; set; }
        public double? PackHoldPSIBar { get; set; }
        public int? GateSealFrom { get; set; }
        public int? GateSealTo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public List<GateSealPartModel> PartModelList { get; set; }
        #endregion

    }
}
