using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieManager.Startup))]
namespace MovieManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
