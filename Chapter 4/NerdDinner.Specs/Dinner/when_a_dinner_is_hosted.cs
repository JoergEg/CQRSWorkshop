using System;
using NUnit.Framework;
using NerdDinner.Cqrs;
using NerdDinner.Cqrs.ApplicationServices;

namespace NerdDinner.Specs.Dinner
{
    public class when_a_dinner_is_hosted : CommandTestFixture<HostDinner, HostDinnerApplicationService, NerdDinner.Cqrs.Aggregates.Dinner>
    {
        protected override HostDinner When()
        {
            return new HostDinner(new DinnerId(Guid.NewGuid()), "me", "Nerd at Paris", new DateTime(2014, 12, 12), "the description", "123456", "Rue 15", "Paris");
        }

        [Test]
        public void then_a_dinner_created_event_should_be_published()
        {
            Assert.AreEqual(typeof(DinnerCreated), PublishedEvents.Last().GetType());
        }

        [Test]
        public void Then_the_published_event_should_contain_the_address()
        {
            Assert.That(PublishedEvents.Last<DinnerCreated>().Address == "");
        } 
    }
}