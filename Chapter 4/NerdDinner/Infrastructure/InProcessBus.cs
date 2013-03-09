using System;
using System.Collections.Generic;
using EventStore;
using EventStore.Dispatcher;
using NerdDinner.Cqrs;

namespace NerdDinner.Infrastructure
{
    public interface IBus
    {
        void Send<T>(T command) where T : Command;
        void RegisterHandler<T>(Action<T> handler) where T : DomainEvent;
    }

    public class InProcessBus : IBus, IDispatchCommits
    {
        private readonly Dictionary<Type, List<Action<DomainEvent>>> _routes = new Dictionary<Type, List<Action<DomainEvent>>>();

        public void Send<T>(T command) where T : Command
        {
            dynamic commandHandler = GetCommandHandlerForCommand<T>();
            commandHandler.When(command);
        }

        public void RegisterHandler<T>(Action<T> handler) where T : DomainEvent
        {
            List<Action<DomainEvent>> handlers;
            if (!_routes.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<DomainEvent>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<DomainEvent, T>(x => handler(x)));
        }

        private dynamic GetCommandHandlerForCommand<T>() where T : Command
        {
            return null;
            //return _container.Resolve<Handles<T>>();
        }

        public void Dispatch(Commit commit)
        {
            foreach (var @event in commit.Events)
            {
                List<Action<DomainEvent>> handlers;

                if (!_routes.TryGetValue(@event.Body.GetType(), out handlers)) return;
                foreach (var handler in handlers)
                {
                    //dispatch on thread pool for added awesomeness
                    //var handler1 = handler;
                    //ThreadPool.QueueUserWorkItem(x => handler1(@event));
                    handler((DomainEvent)@event.Body);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}