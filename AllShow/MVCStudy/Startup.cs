using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCStudy.Startup))]
namespace MVCStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
