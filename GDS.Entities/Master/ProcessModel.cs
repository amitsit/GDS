using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class ProcessModel
    {
        public int? ProcessId { get; set; }

        public int? MenuId { get; set; }

        public string ProcessName { get; set; }

        public bool? IsActive { get; set; }

        public Int16? DisplayOrder { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
