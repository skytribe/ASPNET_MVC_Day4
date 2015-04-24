using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF_Data1st.Startup))]
namespace EF_Data1st
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
