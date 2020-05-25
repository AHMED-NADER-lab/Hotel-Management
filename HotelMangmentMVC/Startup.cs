using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelMangmentMVC.Startup))]
namespace HotelMangmentMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
