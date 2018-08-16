using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master.IACCycleGoalModel
{
    public class IACCycleGoalModel
    {
        public int IACCycleGoalId { get; set; }
        public int? PlantId { get; set; }
        public string PlantName { get; set; }
        public long? PlantMonthYearId { get; set; }
        public string PlantMonthYear { get; set; }
        public int TonnageRangeId { get; set; }
        public int? StartRange { get; set; }
        public int? EndRange { get; set; }
        public int IACBIC { get; set; }
        public int? WorldClass { get; set; }
        public Double? AvgLaborPerPressSize { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
