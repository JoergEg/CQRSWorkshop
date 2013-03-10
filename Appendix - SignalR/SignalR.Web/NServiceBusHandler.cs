using System;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using SignalR.Infrastructure;

namespace SignalR.Web
{
    public class NServiceBusHandler : IHandleMessages<Event>
    {
        public NServiceBusHandler()
        {
            
        }
        public void Handle(Event @event)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<EventLogHub>();
            context.Clients.All.LogEvent(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),  @event.GetType().Name, @event.ToString());
        }
    }

    public class DomainEvent {}
}