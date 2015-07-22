using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthCrm.Startup))]
namespace HealthCrm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
