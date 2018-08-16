using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.SMOM.CoverPage
{
    public class CoverPageHistoryModel
    {
        public long CoverPageId { get; set; }
        public int PlantEquipmentListId { get; set; }
        public int InputDataId { get; set; }
        public string IdentificationText { get; set; }
        public int? VersionNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
