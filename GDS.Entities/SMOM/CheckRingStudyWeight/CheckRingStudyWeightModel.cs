using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CheckRingStudyWeight
{
    public class CheckRingStudyWeightModel
    {
        public long CoverPageId{ get; set; }
        public double? AmountOfDeCompress { get; set; }
        public long? CheckRingStudyId { get; set; }
        public int ShotNumber { get; set; }
        public double? ShotWeight { get; set; }
        public string MaterialCode { get; set; }
        public byte? ValidationStatusCode { get; set; }
    }
}
