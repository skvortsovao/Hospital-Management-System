using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HospitalRealTimeServer.Startup))]

namespace HospitalRealTimeServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.MapSignalR(); //Enables SignalR at /signalr
        }
    }
}