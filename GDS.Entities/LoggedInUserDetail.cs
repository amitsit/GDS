using GDS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Entities
{
    public class LoggedInUserDetail
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserId { get; set; }

        public bool? InvalidUser { get; set; }

        /// <summary>
        /// Gets or sets the internal user identifier.
        /// </summary>
        /// <value>
        /// The internal user identifier.
        /// </value>
        public int? InternalUserId { get; set; }

        /// <summary>
        /// Gets or sets the network user identifier.
        /// </summary>
        /// <value>
        /// The network user identifier.
        /// </value>
        public string NetworkUserId { get; set; }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>
        /// The language code.
        /// </value>
        public string LanguageCd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the login user internal identifier.
        /// </summary>
        /// <value>
        /// The login user internal identifier.
        /// </value>
        public int? InternalId { get; set; }

        /// <summary>
        /// Gets or sets the impersonated internal identifier.
        /// </summary>
        /// <value>
        /// The impersonated internal identifier.
        /// </value>
        public int? ImpersonatedInternalId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }


        public string UserName { get; set; }

        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public IEnumerable<string> Roles { get; set; }

        public List<RoleRightsPermissionModel> RolesRightsPermissions { get; set; }
        public string LoginUserUniqueKey { get; set; }
    }
}
