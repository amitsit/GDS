using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
  public class BICCycleKeyElementModel
    {
        #region Instance Properties

        public int BICCycleKeyElementID { get; set; }

        public int? PlantId { get; set; }

        public int? PlantMonthYearId { get; set; }

        public string ElementName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdateBy { get; set; }

        public string decimalAllow { get; set; }

        public double? SortOrder { get; set; }

        public string NeedToSuccess { get; set; }

        #endregion Instance Properties
    }
}
