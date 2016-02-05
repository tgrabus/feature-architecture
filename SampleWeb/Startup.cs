using Microsoft.Owin;
using Owin;
using SampleWeb;

[assembly: OwinStartup(typeof(Startup))]
namespace SampleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
