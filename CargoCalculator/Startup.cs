using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CargoCalculator.Startup))]
namespace CargoCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
