using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MEAB.Startup))]
namespace MEAB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
