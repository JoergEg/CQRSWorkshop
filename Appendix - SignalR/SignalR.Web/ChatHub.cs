using Microsoft.AspNet.SignalR;

namespace SignalR.Web
{
    public class ChatHub : Hub
    {
        public void sendMessage(string msg)
        {
            Clients.All.sendMessage(msg);
        }
    }
}