using CommonDomain.Persistence;
using EventStore;
using NerdDinner.Cqrs;
using Raven.Client;
using Raven.Client.Document;

namespace NerdDinner.Infrastructure
{
    public class Globals
    {
        public static IBus Bus { get; set; }

        public static IStoreEvents EventStore { get; set; }

        public static IRepository Repository { get; set; }

        public static IDinnerApplicationService ApplicationService { get; set; }

        public static IDocumentStore RavenDocumentStore { get; set; }
    }
}