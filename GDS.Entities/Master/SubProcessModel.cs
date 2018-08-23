using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class SubProcessModel
    {
        public int? SubProcessId { get; set; }

        public int? ProcessId { get; set; }

        public int? GlobalSubProcessId { get; set; }

        public string SubProcessCode { get; set; }

        public string SubProcessName { get; set; }

        public string SubProcessModelPath { get; set; }

        public string SubProcessDescription { get; set; }

        public string SubProcessOwner { get; set; }

        public string SubProcessInput { get; set; }

        public string FundamentalOfProcess { get; set; }

        public string SubProcessOutput { get; set; }

        public int? RegionId { get; set; }

        public string RegionName { get; set; }

        public Int16? DisplayOrder { get; set; }

        public int? CreatedBy { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

    }
}
