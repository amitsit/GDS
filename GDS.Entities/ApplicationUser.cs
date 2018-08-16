namespace GDS.Entities
{
    using Microsoft.AspNet.Identity.EntityFramework;
    
    /// <summary>
    /// Class Application User.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
    }

    /// <summary>
    /// Class Application DB Context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}