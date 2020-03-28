using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entertainment_Lib.Startup))]
namespace Entertainment_Lib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
