using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM
{
      public  class GateSealPartModel
    {
        #region Instance Properties
        public int? GateSealPartDetailId { get; set; }
        public int? GateSealId { get; set; }
        public int OrderNumber { get; set; }
        public double? HoldTime { get; set; }
        public double? PartWeight { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
}
