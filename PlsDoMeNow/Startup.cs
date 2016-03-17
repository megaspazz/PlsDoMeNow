using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlsDoMeNow.Startup))]
namespace PlsDoMeNow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
