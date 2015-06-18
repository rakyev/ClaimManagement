using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICM.Web.Startup))]
namespace ICM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
