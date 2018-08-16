using System;
using System.Collections.Generic;
using GDS.Entities.Master;

// ReSharper disable InconsistentNaming
namespace GDS.Entities.STMP.CapitalPlanBenifits
{
    public class CapitalPlanBenifitsModel
    {
        public int? PlantId { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public string STDCYC { get; set; }
        public int UserId { get; set; }

        public List<CapitalPlanTable> CapitalPlanTable { get; set; }
        public List<CategoryStates> CategoryStates { get; set; }
        //public List<DashboardPlantSelection> DashboardPlantSelection { get; set; }
    }

    public class CapitalPlanTable
    {
        public int TonnageFrom { get; set; }
        public int TonnageTo { get; set; }
        public string TonnageToDisplay { get; set; }
        public int AVAIL_HRS { get; set; }
        public double? DEMAND { get; set; }
        public double? CYC_SEC { get; set; }
        public int NumberOfPress { get; set; }
        public double? CAP { get; set; }
        public double? AvgLaborPerPressSize { get; set; }
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
        public double? DLTPERC { get; set; }
        public double? DLTSEC { get; set; }
        public double? MP { get; set; }
        public int? AvgAge { get; set; }

        public double? Press_Utilization_REQ { get; set; }
        public double? DeltaPress { get; set; }

    }

    public class CategoryStates
    {

        // Result set 1 : Table 1
        public double? TotalDemandShotCount { get; set; }
        public double? TotalDemandCycleSeconds { get; set; }
        public int? PressQuantity { get; set; }
        public double? TotalTonnageToolWeighted { get; set; }
        public double? DLActualHeadcount { get; set; }
        public double? PlantDLFringedWage { get; set; }
        public double? PlantDLHourlyWage { get; set; }
        public double? TotalMoldingHourlyCost { get; set; }
        public double? STMPRequiredManning { get; set; }
        public double? DeltaActualOrRequiredHC { get; set; }
        public double? LaborCostOpportunity { get; set; }

        // Result set 2 : Table 2
        public double? PercentageWeightTon { get; set; }
        public double? AVGOF_AVG_CYC { get; set; }
        public int? WeightTonlookupInCycleGoal { get; set; }

        public double? LookUpPercOfWeightTon { get; set; }
        public int? PlantWise_AVG_Year { get; set; }
        public double? HistPercentage { get; set; }
        public string PlantName { get; set; }
    }

    public class DashboardPlantSelection
    {
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public int? OEE { get; set; }
    }

    public class CapitalPlanBenifitsInputModel : UnitTypeModel
    {
        public string PlantIdString { get; set; }
        public int? LoggedInUserId { get; set; }
        public string CycleTimeSelection { get; set; }
        public string OEE { get; set; }
        public string WeekString { get; set; }
        public bool IsPlantSpecific { get; set; }
        public double? MaxUtilizationTarget { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
    }

}
