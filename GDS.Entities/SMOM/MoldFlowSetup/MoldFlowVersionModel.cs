using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowVersionModel
    {
        public long? MoldFlowGeneralInfoId { get; set; }
        public string IdentificationText { get; set; }
        public string MoldNumber { get; set; }
        public string JobName { get; set; }
        public Nullable<DateTime> Date { get; set; }

        public int? VersionNumber { get; set; }
        public int? MoldFlowSetupHeaderId { get; set; }
    }
}
