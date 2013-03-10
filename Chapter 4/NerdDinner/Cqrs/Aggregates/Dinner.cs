using System;
using System.Collections.Generic;
using CommonDomain.Core;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.Aggregates
{
    public class Dinner : AggregateBase
    {
        public Dinner()
        {
            
        }

        private Dinner(HostDinner command)
        {
            CreateDinnerInDB(command);

            RaiseEvent(new DinnerCreated(command.Id, command.HostedBy, command.Title, command.EventDate,
                                         command.Description, command.ContactPhone, command.Address, command.Country));
        }

        private static void CreateDinnerInDB(HostDinner command)
        {
            var db = new NerdDinnerContext();
            var dinner = new Models.Dinner
                {
                    Address = command.Address,
                    ContactPhone = command.ContactPhone,
                    Country = command.Country,
                    Description = command.Description,
                    DinnerID = command.Id.Id,
                    EventDate = command.EventDate,
                    HostedBy = command.HostedBy,
                    Title = command.Title
                };

            var rsvp = new RSVP();
            rsvp.AttendeeName = command.HostedBy;

            dinner.RSVPs = new List<RSVP>();
            dinner.RSVPs.Add(rsvp);

            db.Dinners.Add(dinner);
            db.SaveChanges();
        }

        public void Apply(DinnerCreated e)
        {
            Id = Guid.NewGuid();

        }

        public static Dinner HostDinner(HostDinner command)
        {
            return new Dinner(command);
        }
    }
}