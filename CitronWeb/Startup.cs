using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CitronWeb.Startup))]
namespace CitronWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
