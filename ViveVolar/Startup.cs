using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ViveVolar.Startup))]

namespace ViveVolar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
