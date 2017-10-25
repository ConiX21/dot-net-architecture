using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Controler.Startup))]
namespace Controler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
