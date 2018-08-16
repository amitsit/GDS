using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.MoldFlowSetup
{
    public class MoldFlowTimerModel
    {
        public long MoldflowTimerId { get; set; }
        public long MoldFlowGeneralInfoId { get; set; }
        public double? Fill { get; set; }
        public double? Pack { get; set; }
        public double? Hold { get; set; }
        public double? Cooling { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
