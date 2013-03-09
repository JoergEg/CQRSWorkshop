using System.Collections.Generic;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.Aggregates
{
    public class Dinner
    {
        public static void HostDinner(HostDinner command, NerdDinnerContext db)
        {
            var dinner = new Models.Dinner
                {
                    DinnerID = command.Id.Id, 
                    HostedBy = command.HostedBy,
                    Address = command.Address,
                    ContactPhone = command.ContactPhone,
                    Country = command.Country,
                    Description = command.Description,
                    EventDate = command.EventDate,
                    Title = command.Title
                };

            RSVP rsvp = new RSVP();
            rsvp.AttendeeName = command.HostedBy;

            dinner.RSVPs = new List<RSVP>();
            dinner.RSVPs.Add(rsvp);

            db.Dinners.Add(dinner);
            db.SaveChanges();
        }
    }
}