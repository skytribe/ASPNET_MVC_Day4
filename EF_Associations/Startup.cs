using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF_Associations.Startup))]
namespace EF_Associations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
