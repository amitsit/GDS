using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class ProcessModel: SubProcessModel
    {

        public int? MenuId { get; set; }

        public string ProcessName { get; set; }

        public bool? IsActive { get; set; }

        public string ProcessDesc { get; set; }

        public string SelectedRegion { get; set; }

      public List<SubProcessModel> SubProcessList { get; set; }

    }
}
