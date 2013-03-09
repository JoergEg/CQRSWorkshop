using Microsoft.AspNet.SignalR;

namespace SignalR.Web
{
    public class ChatHub : Hub
    {
        public void SendMessage(string msg)
        {
            Clients.All.sendMessage(msg);
        }
    }
}