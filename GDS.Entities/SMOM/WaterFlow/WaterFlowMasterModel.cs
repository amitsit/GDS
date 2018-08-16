using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.WaterFlow
{
    public class WaterFlowMasterModel
    {
        #region Instance Properties
        public int WaterFlowId { get; set; }
        public int UserId { get; set; }
        public int CoverPageId { get; set; }
        public double? FixedThermolatorModel { get; set; }
        public double? FixedThermolatorSerialNo { get; set; }
        public double? MovingThermolatorModel { get; set; }
        public double? MovingThermolatorSerialNo { get; set; }
        public double? FixedHoseDiameterToMold { get; set; }
        public double? MovingHoseDiameterToMold { get; set; }
        public double? FixedHalfGallonPerMinute { get; set; }
        public double? MovingHalfGallonPerMinute { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public List<WaterMinuteDataModel> WaterMinuteDataList { get; set; }
        public List<WaterFlowThermolatorDiameterMappingModel> WaterFlowThermolatorDiameterMappingDataList { get; set; }
        #endregion
    }
}
