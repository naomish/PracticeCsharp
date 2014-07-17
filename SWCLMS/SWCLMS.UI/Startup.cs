using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SWCLMS.UI.Startup))]
namespace SWCLMS.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
