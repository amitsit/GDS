

namespace GDS.Entities.Master
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RoleRightsModel
    {
        public long? RightId { get; set; }

        public string ModuleName { get; set; }

        public string SubmoduleName { get; set; }

        public string FunctionName { get; set; }

        public bool? IsActive { get; set; }

        //FuntionInRoles Table

        public long? RoleRightId { get; set; }

        public int? RoleId { get; set; }


        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }


        //Extra Fields

        public bool? IsSelected { get; set; }

        public bool? IsEdited { get; set; }



    }
}
