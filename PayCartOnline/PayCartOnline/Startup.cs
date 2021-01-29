using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayCartOnline.Startup))]
namespace PayCartOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
