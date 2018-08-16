using System.Collections.Generic;
using GDS.Entities.Master;

namespace GDS.Entities.STMP.LaborPlantSpecific
{
    
    public class LaborPlantSpecificModel
    {
       public List<LaborPlantTable3> LaborPlantTable3 { get; set; }
    }

    public class LaborPlantSpecificInputDataModel : UnitTypeModel
    {
        public string PlantIdString { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public string STDCYC { get; set; }
        public int LoggedInUserId { get; set; }
        public string WeekString { get; set; }
        public double? MaxUtilizationTarget { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
    }

    public class LaborPlantTable3
    {
        public int TonnageFrom { get; set; }
        public int TonnageTo { get; set; }
        public string TonnageToDisplay { get; set; }
        public int UTZ_HRS { get; set; }
        public int AVAIL_HRS { get; set; }
        public double? DEMAND { get; set; }
        public double? CYC_SEC { get; set; }
        public int AVG_Year { get; set; }
        public int NumberOfPress { get; set; }
        public double? IACBIC { get; set; }
        public double? WorldClass { get; set; }
        public double? CAP { get; set; }
        public double? UTZ { get; set; }
        public double? AVG_CYC { get; set; }
        public double? Weight_TON { get; set; }
        public double? Current_CYC { get; set; }
        public double? Current_UTZ_Second { get; set; }
        public double? Current_UTZ_Percentage { get; set; }
        public double? Current_UTZ_HRS { get; set; }
        public double? STD_IACBIC { get; set; }
        public double? STD_UTZ_Seconds { get; set; }
        public double? STD_UTZ_Percentage { get; set; }
        public double? STD_UTZ_HRS { get; set; }
        public double? STD_Cap_Imp { get; set; }
        public double? WC_IACBIC { get; set; }
        public double? WC_UTZ_Seconds { get; set; }
        public double? WC_UTZ_Percentage { get; set; }
        public double? WC_UTZ_HRS { get; set; }
        public double? WC_Cap_Imp { get; set; }
        public double? CapitalPlanBenefits_IMP_IACBIC_CYC { get; set; }
        public double? CapitalPlanBenefits_IMP_IACBIC_OEE { get; set; }
        public double? CapitalPlanBenefits_IMP_WC_CYC { get; set; }
        public double? CapitalPlanBenefits_IMP_WC_OEE { get; set; }
        public double? CapitalPlanBenefits_Excess_Current_CYCLE { get; set; }
        public double? CapitalPlanBenefits_Excess_Current_OEE { get; set; }
        public double? CapitalPlanBenefits_Excess_Current_Total { get; set; }
        public double? CapitalPlanBenefits_Excess_IACBIC_CYCLE { get; set; }
        public double? CapitalPlanBenefits_Excess_IACBIC_OEE { get; set; }
        public double? CapitalPlanBenefits_Excess_IACBIC_Total { get; set; }
        public double? CapitalPlanBenefits_Excess_WC_CYCLE { get; set; }
        public double? CapitalPlanBenefits_Excess_WC_OEE { get; set; }
        public double? CapitalPlanBenefits_Excess_WC_Total { get; set; }
        public double? AvgLaborPerPressSize { get; set; }
        public double? LaborPlantSpecific_IACBIC_TonAVG { get; set; }
        public double? LaborPlantSpecific_IACBIC_PlantAvg { get; set; }
        public double? LaborPlantSpecific_WC_TonAVG { get; set; }
        public double? LaborPlantSpecific_WC_PlantAvg { get; set; }
        public double? LaborPlantSpecific_WC_Total_AvgLaborPerPressSize { get; set; }
        public double? LaborPlantSpecific_IACBIC_Total_AvgLaborPerPressSize { get; set; }
    }
}
