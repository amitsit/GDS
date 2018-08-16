using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.WaterFlow
{
   public  class WaterMinuteDataModel
    {
        #region Instance Properties
        public int WaterMinuteDataId { get; set; }
        public int WaterFlowId { get; set; }
        public int TypeId { get; set; }
        public int OrderNumber { get; set; }
        public double? MainInOutNoMold { get; set; }
        public double? MainInOutWithMold { get; set; }
        public double? LineA { get; set; }
        public double? LineB { get; set; }
        public double? LineC { get; set; }
        public double? LineD { get; set; }
        public double? LineE { get; set; }
        public double? LineF { get; set; }
        public double? LineG { get; set; }
        public double? LineH { get; set; }
        public double? LineI { get; set; }
        public double? LineJ { get; set; }
        public double? LineK { get; set; }
        public double? LineL { get; set; }
        public double? LineM { get; set; }
        public double? LineN { get; set; }
        public double? Slide1 { get; set; }
        public double? Slide2 { get; set; }
        public double? Slide3 { get; set; }
        public double? Slide4 { get; set; }
        public double? Lifter1 { get; set; }
        public double? Lifter2 { get; set; }
        public double? Lifter3{ get; set; }
        public double? Lifter4 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion
    }
}
