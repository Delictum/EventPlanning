using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPlanning.Mvc.Startup))]
namespace EventPlanning.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
