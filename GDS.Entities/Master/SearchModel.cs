using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class SearchModel
    {
        public int? SearchType { get; set; }

        public int? MenuId { get; set; }

        public int? ProcessId { get; set; }

        public string ProcessName { get; set; }

        public string ProcessDesc { get; set; }

        public int? SubProcessId { get; set; }

        public int? RegionId { get; set; }

        public string RegionName { get; set; }

        public string SubProcessCode { get; set; }

        public string SubProcessName { get; set; }

        public int? DocumentId { get; set; }

        public string DocumentCode { get; set; }

        public string DocumentTitle { get; set; }
    }
}
