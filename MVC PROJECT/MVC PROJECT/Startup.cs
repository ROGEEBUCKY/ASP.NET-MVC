using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_PROJECT.Startup))]
namespace MVC_PROJECT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
