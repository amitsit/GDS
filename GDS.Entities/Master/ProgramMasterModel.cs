namespace GDS.Entities.Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProgramMasterModel
    {
        public long ProgramID { get; set; }

        public string ProgramName { get; set; }

        public int? PlantID { get; set; }
        public long? InputDataId { get; set; }
        public string PlantName { get; set; }
        public string Tool { get; set; }

        public bool? IsActive { get; set; }

        public double? LCR { get; set; }
        public double? MCR { get; set; }
        public double? IHS { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}