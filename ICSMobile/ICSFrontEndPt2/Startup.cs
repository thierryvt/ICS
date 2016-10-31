using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICSFrontEndPt2.Startup))]
namespace ICSFrontEndPt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
