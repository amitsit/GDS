using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.DOE
{
    public class DOEModel
    {
        public long CoverPageId { get; set; }
        public int LoggedInUserId { get; set; }
        public int? Variable1 { get; set; }
        public int? Variable2 { get; set; }
        public int? Variable3 { get; set; }
        public int? Variable4 { get; set; }
        public List<DOEList> DOEList { get; set; }
    }

    public class DOEList
    {
        public int TrialNumber { get; set; }
        public string TrialName { get; set; }
        public double? Variable1Value { get; set; }
        public double? Variable2Value { get; set; }
        public double? Variable3Value { get; set; }
        public double? Variable4Value { get; set; }
        public int? Variable1 { get; set; }
        public int? Variable2 { get; set; }
        public int? Variable3 { get; set; }
        public int? Variable4 { get; set; }
        public string Result { get; set; }


    }

    public class DOEVariableList
    {
        public int VariableId { get; set; }
        public string VariableName { get; set; }

    }
}
