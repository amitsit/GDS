namespace GDS.Entities.Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class RoleRightsPermissionModel
    {
        public int? UserId { get; set; }

        public string ModuleName { get; set; }

        public string SubmoduleName { get; set; }

        public string FunctionName { get; set; }

        public string RoleName { get; set; }

        public bool? IsActive { get; set; }
    }
}
