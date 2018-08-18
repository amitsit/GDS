using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class MenuModel
    {

        public int? MenuId { get; set; }

        public string MenuName { get; set; }

        public bool? IsActive { get; set; }

        public int? DisplayOrder { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
