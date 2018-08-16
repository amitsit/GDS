namespace GDS.Entities.SMOM.TonnageCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TonnageCalculatorModel
    {
        public long TonnageCalculatorId { get; set; }

        public long CoverPageId { get; set; }

        public int? MaterialTypeId { get; set; }

        public int? WallStockId { get; set; }

        public double? ApproxRunnerSize_AVG_horizontal { get; set; }

        public double? ApproxRunnerSize_AVG_vertical { get; set; }

        public double? NumberOfRunners { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public List<TonnageCalculatorCavityModel> TonnageCalculatorCavityList { get; set; }
    }

    public class TonnageCalculatorCavityModel
    {
        public long TonnageCalculatorCavityId { get; set; }

        public long TonnageCalculatorId { get; set; }

        public double? CavityNumber { get; set; }

        public double? PartSize_horizontal { get; set; }

        public double? PartSize_vertical { get; set; }

        public double? OpeningWithinPart_1_horizontal { get; set; }

        public double? OpeningWithinPart_1_vertical { get; set; }

        public double? OpeningWithinPart_2_horizontal { get; set; }

        public double? OpeningWithinPart_2_vertical { get; set; }

        public double? OpeningWithinPart_3_horizontal { get; set; }

        public double? OpeningWithinPart_3_vertical { get; set; }

        public double? OpeningWithinPart_4_horizontal { get; set; }

        public double? OpeningWithinPart_4_vertical { get; set; }

        public string Left_OR_Right { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }

    }
