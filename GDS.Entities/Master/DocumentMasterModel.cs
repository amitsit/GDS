using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class DocumentMasterModel
    {
        public int? ProcessId { get; set; }

        public int? SubProcessId { get; set; }

        public int? DocumentId { get; set; }

        public string DocumentCode { get; set; }

        public string DocumentTitle { get; set; }

        public string DocumentPath { get; set; }

        public int? SubProcessDocumentId { get; set; }

        public int? RegionId { get; set; }

        public bool? IsActive { get; set; }

        public Int16? DisplayOrder { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public Nullable<DateTime> ReleaseDate { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }


    }
}
