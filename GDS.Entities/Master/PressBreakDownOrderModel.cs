using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class PressBreakDownOrderModel
    {
        public long PlantEquipmentListId { get; set; }
        public int PlantId { get; set; }
        public string PressNumber { get; set; }
        public int? OrderNumber { get; set; }
    }
}
