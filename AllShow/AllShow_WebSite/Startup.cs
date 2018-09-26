using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllShow_WebSite.Startup))]
namespace AllShow_WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
