using System;
using NUnit.Framework;
using NerdDinner.Cqrs;
using NerdDinner.Cqrs.ApplicationServices;

namespace NerdDinner.Specs.Dinner
{
    public class when_a_dinner_is_hosted : CommandTestFixture<HostDinner, HostDinnerApplicationService, Cqrs.Aggregates.Dinner>
    {
        protected override HostDinner When()
        {
            return new HostDinner(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2014, 12, 12), "the description", "123456", "Rue 15", "France");
        }

        [Test]
        public void then_a_dinner_created_event_should_be_published()
        {
            Assert.AreEqual(typeof(DinnerCreated), PublishedEvents.Last().GetType());
        }

        [Test]
        public void then_the_published_event_should_contain_the_address()
        {
            Assert.AreEqual("Rue 15", PublishedEvents.Last<DinnerCreated>().Address);
        }

        [Test]
        public void then_the_published_event_should_contain_the_dinnerId()
        {
            Assert.AreEqual(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350"), PublishedEvents.Last<DinnerCreated>().Id.Id);
        }

        [Test]
        public void then_the_published_event_should_contain_the_contact_phone()
        {
            Assert.AreEqual("123456", PublishedEvents.Last<DinnerCreated>().ContactPhone);
        }

        [Test]
        public void then_the_published_event_should_contain_the_country()
        {
            Assert.AreEqual("France", PublishedEvents.Last<DinnerCreated>().Country);
        }

        [Test]
        public void then_the_published_event_should_contain_the_description()
        {
            Assert.AreEqual("the description", PublishedEvents.Last<DinnerCreated>().Description);
        }

        [Test]
        public void then_the_published_event_should_contain_the_eventdate()
        {
            Assert.AreEqual(new DateTime(2014,12,12), PublishedEvents.Last<DinnerCreated>().EventDate);
        }

        [Test]
        public void then_the_published_event_should_contain_hostby()
        {
            Assert.AreEqual("me", PublishedEvents.Last<DinnerCreated>().HostedBy);
        }

        [Test]
        public void then_the_published_event_should_contain_the_title()
        {
            Assert.AreEqual("Nerd at Paris", PublishedEvents.Last<DinnerCreated>().Title);
        }
    }
}