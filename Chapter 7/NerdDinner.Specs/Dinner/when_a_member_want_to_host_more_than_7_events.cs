using System;
using System.Collections.Generic;
using NerdDinner.Cqrs;
using NerdDinner.Cqrs.ApplicationServices;

namespace NerdDinner.Specs.Dinner
{
    public class when_a_member_want_to_host_more_than_7_events : CommandTestFixture<HostDinner, HostDinnerApplicationService, Cqrs.Aggregates.Dinner>
    {
        protected override IEnumerable<DomainEvent> Given()
        {
            return new List<DomainEvent>
                {
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2014, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2015, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2016, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2017, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2018, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2019, 12, 12), "the description", "123456", "Rue 15", "France"),
                    new DinnerCreated(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2020, 12, 12), "the description", "123456", "Rue 15", "France"),
                };
        }

        protected override HostDinner When()
        {
            return new HostDinner(new DinnerId(new Guid("2e221e60-eabb-44fc-a67d-2772c50a3350")), "me", "Nerd at Paris", new DateTime(2021, 12, 12), "the description", "123456", "Rue 15", "France");
        }

        //TODO: write tests for specified domain logic
    }
}