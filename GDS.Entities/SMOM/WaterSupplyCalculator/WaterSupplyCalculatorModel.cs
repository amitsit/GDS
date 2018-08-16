using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.WaterSupplyCalculator
{
    public class WaterSupplyCalculatorModel
    {
        #region Instance Properties
        public long WaterSupplyCalculatorId { get; set; }
        public long CoverPageId { get; set; }
        public int? UserId { get; set; }
        public double? SupplyLine { get; set; }
        public double? ToolFitting { get; set; }
        public double? CircuitsPerThermolator { get; set; }
        public byte? ValidationStatusCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
}
