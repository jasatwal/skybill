using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sky.Web.UI.Startup))]
namespace Sky.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
