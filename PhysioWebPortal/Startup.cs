using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhysioWebPortal.Startup))]
namespace PhysioWebPortal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
