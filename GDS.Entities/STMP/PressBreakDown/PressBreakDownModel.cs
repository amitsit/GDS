

namespace GDS.Entities.STMP.PressBreakDown
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PressBreakDownModel
    {
        public long? PressBreakdownId { get; set; }

        public long? PlantMonthYearId { get; set; }

        public int? PlantId { get; set; }

        public long? PlantEquipmentListId { get; set; }

        public string PressNumber { get; set; }

        public decimal? CapacityChartMan { get; set; }

        public double? CapChartMan { get; set; }

        public double? CapChartManTotal { get; set; }

        public double? CapChartRand { get; set; }

        public double? CapChartManUtilization { get; set; }



        public double? tonnage { get; set; }


        public double? BICCycle { get; set; }


        public double? MoldPerc { get; set; }


        public double? PlantEquipmentListTonnage { get; set; }

        public string PlantEquipmentOEE { get; set; }

        public double? PlantEquipmentShopLogixPercentage { get; set; }

        public double? PlantEquipmentDollarValue { get; set; }

        public string PlantEquipmentCycle { get; set; }

        public double? PlantEquipmentDailyRecapRep { get; set; }

        public string PlantEquipmentManufacturer { get; set; }

        public int? PressYear { get; set; }

        public long? ProgramId { get; set; }

        public long? ToolId { get; set; }

        public string ToolNumber { get; set; }

        public string ToolDescription { get; set; }

        public string PressManufacturer { get; set; }

        public string ProgramName { get; set; }

        public string Tool { get; set; }
        public double? MoldOEE { get; set; }

        public double? STDCYC { get; set; }

        public double? ACTCYC { get; set; }

        public double? VHSUP { get; set; }

        public double? REQOPS { get; set; }

        public double? TAKERATE { get; set; }

        public double? OEETAKE { get; set; }

        public double? UTILIZHOURS { get; set; }

        public double? UTILIZSHIFTS { get; set; }

        public double? CUSTSCHEDHOURS { get; set; }

        public double? DailyShiftsRequired { get; set; }


        public double? TotalDailyShiftsRequired { get; set; }


        public double? UTILIZTOOLPERPRS { get; set; }

        public double? TotalUTILIZTOOLPERPRS { get; set; }

        public double? CYCLETIMEEFFCYPERCENTAGE { get; set; }

        public double? MYCALCMANUTILIZ { get; set; }

        public double? MANUTILIZ { get; set; }

        public double? UsedforfiguringMOLDOEEPercentage { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Total { get; set; }

        public double? MoldingManning { get; set; }
        public double? FringeWageRate { get; set; }
        public double? HourlyWageRate { get; set; }
        public double? RequiredManning { get; set; }
        public double? Difference { get; set; }
        public double? Global_StdPerfomanceGoal { get; set; }
        public double? Global_AllPerformanceGoal { get; set; }
        public double? OTCost { get; set; }

        public int? OrderNumber { get; set; }
    }

    public class InsertNewToolToPressModel
    {
        public int ReturnId { get; set; }
        public string Message { get; set; }
    }

    public class ToolForDDL
    {
        public long InputDataId { get; set; }
        public string Tool { get; set; }
    }

    public class ProgramListForDDL
    {
        public long InputProgramMappingID { get; set; }
        public long ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Tool { get; set; }
        public int? PlantId { get; set; }
    }
}
