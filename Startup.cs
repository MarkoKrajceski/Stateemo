using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stateemo.Startup))]
namespace Stateemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
