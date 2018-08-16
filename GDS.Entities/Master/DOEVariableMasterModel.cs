using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
   public class DOEVariableMasterModel
    {
        public int VariableId { get; set; }
        public string VariableName { get; set; }
        public string Type { get; set; }
        public Boolean IsActive { get; set; }
        public int LoggedInUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}
