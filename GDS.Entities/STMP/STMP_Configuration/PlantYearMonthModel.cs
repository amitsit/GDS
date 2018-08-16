using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.STMP.STMP_Configuration
{
   public class PlantYearMonthModel
    {

        public long? PlantMonthYearId { get; set; }

        public int? PlantId { get; set; }

        public string PlantName { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
