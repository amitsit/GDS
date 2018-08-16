using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
  public  class WallStockRangeModel
    {
        public int? Id { get; set; }

        public int? WallStockId { get; set; }

        public int? MaterialTypeId { get; set; }

        public int? WallStockCTPartRangeId { get; set; }

        public double? FromRange { get; set; }

        public double? ToRange { get; set; }

        public int? Type { get; set; }

        public string RangeString { get; set; }

        public double? Value { get; set; }

        public string MaterialTypeCode { get; set; }

    }
}
