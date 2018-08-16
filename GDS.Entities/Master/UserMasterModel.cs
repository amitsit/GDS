using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities.Master
{
    public class UserMasterModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LoggedInUserId { get; set; }
        public string SelectedPlant { get; set; }
        public string SelectedRoles { get; set; }
        public string NetworkUserId { get; set; }

        public string RegionIdCsv { get; set; }
        public string PlantIdCsv { get; set; }

    }
}
