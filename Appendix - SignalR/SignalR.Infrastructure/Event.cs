using NServiceBus;

namespace SignalR.Infrastructure
{
    public abstract class Event : IMessage
    {
    }

    public class Event1 : Event
    {
        public string Msg { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }

    public class Event2 : Event
    {
        public string Msg { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }

    public class Event3 : Event
    {
        public string Msg { get; set; }

        public override string ToString()
        {
            return Msg;
        }
    }
}