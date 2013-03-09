using CommonDomain.Persistence;
using EventStore;
using NerdDinner.Cqrs;
using NerdDinner.Cqrs.ApplicationServices;

namespace NerdDinner.Infrastructure
{
    public class Globals
    {
        public static IBus Bus { get; set; }

        public static IStoreEvents EventStore { get; set; }

        public static IRepository Repository { get; set; }

        public static IDinnerApplicationService ApplicationService { get; set; }
    }
}