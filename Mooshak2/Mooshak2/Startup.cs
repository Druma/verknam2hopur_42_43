using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mooshak2.Startup))]
namespace Mooshak2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
