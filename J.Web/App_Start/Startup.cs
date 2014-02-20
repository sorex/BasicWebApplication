using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(J.Web.Startup))]
namespace J.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}