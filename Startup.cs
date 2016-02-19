using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5CentrexDataProcessor.Startup))]
namespace MVC5CentrexDataProcessor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}