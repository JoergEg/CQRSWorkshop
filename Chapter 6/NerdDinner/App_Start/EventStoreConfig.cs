using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using EventStore;
using EventStore.Dispatcher;
using NerdDinner.Cqrs;
using NerdDinner.Cqrs.ApplicationServices;
using NerdDinner.Cqrs.ReadModels;
using NerdDinner.Infrastructure;

namespace NerdDinner
{
    public class EventStoreConfig
    {
        public static void RegisterEventStore()
        {
            //use a global singleton instead of IoC for this workshop
            var bus = new InProcessBus();
            Globals.Bus = bus;

            var eventStore = GetInitializedEventStore(bus);
            var repository = new EventStoreRepository(eventStore, new AggregateFactory(), new ConflictDetector());

            Globals.EventStore = eventStore;
            Globals.Repository = repository;

            Globals.ApplicationService = new HostDinnerApplicationService(Globals.Repository);

            SetupDomainEventHandlers(bus);
        }

        private static void SetupDomainEventHandlers(IBus bus)
        {
            //TODO: Resolve through IoC
            var view = new DinnerListView();
            bus.RegisterHandler<DinnerCreated>(view.Handle);
        }

        private static IStoreEvents GetInitializedEventStore(IDispatchCommits bus)
        {
            return Wireup.Init()
                .UsingSqlPersistence("EventStore")
                .UsingJsonSerialization()
                .UsingSynchronousDispatchScheduler(bus)
                .Build();
        }
    }
}