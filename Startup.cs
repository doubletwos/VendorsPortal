using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendorsPortal.Startup))]
namespace VendorsPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
