using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using CommonDomain;
using NUnit.Framework;
using NerdDinner.Cqrs;
using NerdDinner.Models;

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
            //Hack for this chapter
            File.Copy("..\\..\\App_Data\\NerdDinnerContext.mdf", "NerdDinnerContext-20120906143708.mdf", true);
            File.Copy("..\\..\\App_Data\\NerdDinnerContext_log.ldf", "NerdDinnerContext-20120906143708_log.ldf", true);
            Database.SetInitializer<NerdDinnerContext>(null);

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

        [TearDown]
        public void TearDown()
        {
            //Hack for this chapter
            if (File.Exists("NerdDinnerContext-20120906143708.mdf"))
                File.Delete("NerdDinnerContext-20120906143708.mdf");
            if (File.Exists("NerdDinnerContext-20120906143708_log.ldf"))
                File.Delete("NerdDinnerContext-20120906143708_log.ldf");
        }

        private dynamic BuildCommandHandler()
        {
            return Activator.CreateInstance(typeof(TCommandHandler), Repository) as TCommandHandler;
        }
    }

    public class ThereWasNoExceptionButOneWasExpectedException : Exception { }
}