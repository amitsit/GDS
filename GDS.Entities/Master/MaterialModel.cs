using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class MaterialModel
    {
        #region Instance Properties

        public int? MaterialId { get; set; }

        public string MaterialCode { get; set; }

        public string SupplierName { get; set; }

        public int? MaterialTypeId { get; set; }

        public string MaterialTypeCode { get; set; }

        public string MaterialTypeDescription { get; set; }

        public double? MeltLow { get; set; }

        public double? MeltHigh { get; set; }

        public double? MoldTempLow { get; set; }

        public double? MoldTempHigh { get; set; }

        public double? MeltFlowIndex { get; set; }

        public double? Shrinkage { get; set; }

        public double? HDT { get; set; }

        public double? ThermalDiff { get; set; }

        public double? SpecificGravity { get; set; }

        public double? MaxShearRate { get; set; }

        public double? OptimumPeripheralSpeed { get; set; }

        public double? DensityAtProcessTemperature { get; set; }

        public double? DryingTempLow { get; set; }

        public double? DryingTempHigh { get; set; }

        public double? DryingTimeLow { get; set; }

        public double? DryingTimeHigh { get; set; }

        public double? ThermalConductivityLow { get; set; }

        public double? ThermalConductivityHigh { get; set; }

        public double? SpecificHeat { get; set; }

        public double? Density { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public double? RecommendedScrewSpeed { get; set; }

        public double? HeatDeflectionTemperature { get; set; }

        public double? ThermalDiffusivity { get; set; }

        public double? CriticalShearRate { get; set; }

        public int LoggedInUserId { get; set; }

        #endregion Instance Properties
    }
}
