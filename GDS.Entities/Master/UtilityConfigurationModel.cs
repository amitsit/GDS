using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
     public class UtilityConfigurationModel
    {
        public int PlantConfigurationId { get; set; }
        public int? PlantMonthYearId { get; set; }
        public int PlantId { get; set; }
        public string LabelName { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
