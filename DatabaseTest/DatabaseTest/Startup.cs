using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabaseTest.Startup))]
namespace DatabaseTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
