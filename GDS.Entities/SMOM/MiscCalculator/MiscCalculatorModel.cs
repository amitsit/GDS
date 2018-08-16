using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.MiscCalculator
{
    public class MiscCalculatorModel
    {
        #region Instance Properties
        public long MiscCalculatorId { get; set; }
        public long CoverPageId { get; set; }
        public int UserId { get; set; }
        public double? PlasticPressure_HydrualicPressure { get; set; }
        public double? PlasticPressure_IntensificationRatio { get; set; }
        public double? ScrewSurfaceSpeed_Screw { get; set; }
        public double? ScrewSurface_RPM { get; set; }
        public double? ActualInjectionSpeed_LoadedShot { get; set; }
        public double? ActualInjectionSpeed_Transfer { get; set; }
        public double? ActualInjectionSpeed_FillTime { get; set; }
        public double? VolumetricInjectionSpeed_Screw { get; set; }
        public double? VolumetricInjectionSpeed_LoadedShotSize { get; set; }
        public double? VolumetricInjectionSpeed_Transfer { get; set; }
        public double? VolumetricInjectionSpeed_FillTime { get; set; }
        public double? CalculateShotSize_MaterialMeltDensity { get; set; }
        public double? CalculateShotSize_ShotWeight { get; set; }
        public double? CalculateShotSize_Screw { get; set; }
        public double? ShotVolume_ShotSize { get; set; }
        public double? ShotVolume_Cushion { get; set; }
        public double? CalculateShotSize_ShotSizeDecomCushion { get; set; }
        public double? ShotVolumn_Screw { get; set; }
        public double? MoldSwing_DieHeight { get; set; }
        public double? MoldSwing_Horizontal { get; set; }
        public double? MoldSwing_MaxClampOpenPosition { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte? ValidationStatusCode { get; set; }
        #endregion



    }
}
