using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GDS.Web.Startup))]
namespace GDS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
