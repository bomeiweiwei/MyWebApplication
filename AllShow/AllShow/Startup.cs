using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllShow.Startup))]
namespace AllShow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
