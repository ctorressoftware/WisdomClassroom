using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WisdomClassroomApp.Startup))]
namespace WisdomClassroomApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
