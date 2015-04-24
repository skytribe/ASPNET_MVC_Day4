using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF_CodeFrist.Startup))]
namespace EF_CodeFrist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
