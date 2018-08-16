using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.WaterFlow
{
    public class WaterFlowTypeModel
    {
        #region Instance Properties
        public WaterMinuteDataModel FixedHalfEntity { get; set; }
        public WaterMinuteDataModel MovingHalfEntity { get; set; }
        public WaterMinuteDataModel SpecialEntity { get; set; }
        #endregion
    }

}
