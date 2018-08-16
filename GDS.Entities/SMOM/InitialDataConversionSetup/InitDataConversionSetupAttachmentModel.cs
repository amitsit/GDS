using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.InitialDataConversionSetup
{
    public class InitDataConversionSetupAttachmentModel
    {
        public long InitDataConversionSetupAttachmentId { get; set; }

        public long InitDataGeneralInfoId { get; set; }

        public byte[] Attachment { get; set; }

        public string AttachmentName { get; set; }

        public int LoggedInUserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
