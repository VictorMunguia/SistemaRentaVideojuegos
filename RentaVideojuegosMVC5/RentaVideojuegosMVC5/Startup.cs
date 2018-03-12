using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentaVideojuegosMVC5.Startup))]
namespace RentaVideojuegosMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
