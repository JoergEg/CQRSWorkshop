using System;
using System.Collections;
using System.Collections.Generic;
using CommonDomain;
using NUnit.Framework;
using NerdDinner.Cqrs;

namespace NerdDinner.Specs
{
    [TestFixture]
    public abstract class CommandTestFixture<TCommand, TCommandHandler, TAggregateRoot>
        where TCommand : Command
        where TCommandHandler : class, IDinnerApplicationService
        where TAggregateRoot : IAggregate, new()
    {
        protected TAggregateRoot AggregateRoot;
        protected dynamic CommandHandler;
        protected Exception CaughtException;
        protected ICollection PublishedEvents;
        protected FakeRepository Repository;
        protected virtual void SetupDependencies() { }

        protected virtual IEnumerable<DomainEvent> Given()
        {
            return new List<DomainEvent>();
        }

        protected virtual void Finally() { }

        protected abstract TCommand When();

        [SetUp]
        public void Setup()
        {
            Repository = new FakeRepository();
            CaughtException = new ThereWasNoExceptionButOneWasExpectedException();
            AggregateRoot = new TAggregateRoot();
            foreach (var @event in Given())
            {
                AggregateRoot.ApplyEvent(@event);
            }

            CommandHandler = BuildCommandHandler();
            SetupDependencies();
            try
            {
                CommandHandler.When(When());
                if (Repository.SavedAggregate == null)
                    PublishedEvents = AggregateRoot.GetUncommittedEvents();
                else
                    PublishedEvents = Repository.SavedAggregate.GetUncommittedEvents();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }

        private dynamic BuildCommandHandler()
        {
            return Activator.CreateInstance(typeof(TCommandHandler), Repository) as TCommandHandler;
        }
    }

    public class ThereWasNoExceptionButOneWasExpectedException : Exception { }
}