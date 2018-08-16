using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CavityBalance
{
    public class CavityBalanceModel
    {
       
        public long CoverPageId { get; set; }
        public int LoggedInUserId { get; set; }
        public List<CavityBalanceList> CavityBalanceList { get; set; }
    }

    public class CavityBalanceList
    {
       
        public int ShotNumber { get; set; }
        public double? Cav1 { get; set; }
        public double? Cav2 { get; set; }
        public double? Cav3 { get; set; }
        public double? Cav4 { get; set; }
        public double? Cav5 { get; set; }
        public double? Cav6 { get; set; }
        public double? Cav7 { get; set; }
        public double? Cav8 { get; set; }
        public byte? ValidationStatusCode { get; set; }
    }
}
