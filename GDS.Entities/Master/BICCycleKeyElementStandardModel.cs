using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class BICCycleKeyElementStandardModel
    {
        #region Instance Properties

        public int BICCycleKeyElementStandardID { get; set; }

        public int BICCycleKeyElementID { get; set; }

        public string ElementName { get; set; }

        public int TonnageRangeId { get; set; }

        public int TonnageFrom { get; set; }

        public int TonnageTo { get; set; }

        public double? WC { get; set; }

        public decimal Value { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdateBy { get; set; }

        public string decimalAllow { get; set; }

        public string NeedToSuccess { get; set; }

        #endregion Instance Properties
    }
}
