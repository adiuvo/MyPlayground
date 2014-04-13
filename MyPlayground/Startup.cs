using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPlayground.Startup))]
namespace MyPlayground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
