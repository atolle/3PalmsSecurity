using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_3PalmsSecurity.Startup))]
namespace _3PalmsSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
