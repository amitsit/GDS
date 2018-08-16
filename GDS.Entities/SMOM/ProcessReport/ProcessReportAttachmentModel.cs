using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.ProcessReport
{
    public class ProcessReportAttachmentModel
    {
        public long ProcessReportAttachmentId { get; set; }

        public long? MoldFlowSetupHeaderId { get; set; }

        public byte[] Attachment { get; set; }

        public string AttachmentName { get; set; }

        public int? VersionNumber { get; set; }

        public int CreatedBy { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string WholeName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
