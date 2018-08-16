using System;

namespace GDS.Entities.STMP.DailyRecapRap
{
    public class STMP_DailyRecapRap_PressParametersModel
    {
        public STMP_DailyRecapRap_PressParametersModel()
        {
            IsEnable = true;
        }
        public long? PressExpectedParametersId { get; set; }
        public long? PlantEquipmentListId { get; set; }
        public long? PlantMonthYearId { get; set; }
        public int PlantId { get; set; }
        public string PressNumber { get; set; }
        public double? HisPercentage { get; set; }
        public double? ShopLogixOEE { get; set; }
        public double? StandardPercentage { get; set; }
        public double? AllPercentage { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsEnable { get; set; }
        public string PlantName { get; set; }

    }
}
