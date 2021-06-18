using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M_ventas_y_cc.Startup))]
namespace M_ventas_y_cc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
