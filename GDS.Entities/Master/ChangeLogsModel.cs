using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GDS.Entities.Master
{
    public class ChangeLogsModel
    {
        public int? UserId { get; set; }

         public int? ProcessId { get; set; }

        public int? SubProcessId { get; set; }

        public int? DocumentId { get; set; }

        public string Code { get; set; }

        public string Action { get; set; }

        public int? CreatedBy { get; set; }
        
        public string Description { get; set; }

        public string DocumentTitle { get; set; }

        public string ProcessName { get; set; }

        public string SubProcessName { get; set; }

        public string CreatedName { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }

        public int? Year { get; set; }

    }
}
