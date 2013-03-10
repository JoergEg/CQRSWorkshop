using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;

namespace SignalR.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static IBus Bus { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Register the default hubs route: ~/signalr
            RouteTable.Routes.MapHubs();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterBus();
        }

        private void RegisterBus()
        {
            Bus = Configure.With()
                           .DefaultBuilder()
                           .Log4Net()
                           .XmlSerializer()
                           .MsmqTransport()
                           .UnicastBus()
                           .CreateBus()
                           .Start();
        }
    }
}