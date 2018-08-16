using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.IMIP
{
    public class ImprovementPlanActionModel
    {
        public long PlanActionId { get; set; }
        public long BICVerificationDocumentId { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? PromiseDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Champion { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
