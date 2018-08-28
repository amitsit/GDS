using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class ContactUsModel
    {
        public int? ContactId { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsActive { get; set; }

        public string ContactDetail { get; set; }

        public int? RegionId { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
