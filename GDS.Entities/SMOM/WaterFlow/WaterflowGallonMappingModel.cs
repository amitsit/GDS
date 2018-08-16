
namespace GDS.Entities.SMOM.WaterFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WaterflowGallonMappingModel
    {
        public long? GallonMappingId { get; set; }

        public int? WaterFlowId { get; set; }

        public int? TypeId { get; set; }

        public string GallonName { get; set; }

        public string AssignedGallons { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
