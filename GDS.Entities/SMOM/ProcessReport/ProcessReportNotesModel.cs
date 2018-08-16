using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.ProcessReport
{
    public class ProcessReportNotesModel
    {
        public long ProcessReportNotesId { get; set; }

        public long MoldFlowSetupHeaderId { get; set; }

        public string Notes { get; set; }

        public int LoggedInUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public string UserName { get; set; }

    }
}
