using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.WaterFlow
{
    public class WaterFlowThermolatorDiameterMappingModel
    {
        public long WaterFlowThermolatorDiameterMappingId { get; set; }

        public int WaterFlowId { get; set; }

        public int TypeId { get; set; }

        public string ThermolatorTCU { get; set; }

        public double? LineFittingDiameter { get; set; }

        public string Name { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
