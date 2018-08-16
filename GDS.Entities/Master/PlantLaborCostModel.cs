using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class PlantLaborCostModel
    {
        public long PlantLaborCostId { get; set; }

        public int PlantId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public int LoggedInUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CategoryName { get; set; }

        public string PlantName { get; set; }
    }
}
