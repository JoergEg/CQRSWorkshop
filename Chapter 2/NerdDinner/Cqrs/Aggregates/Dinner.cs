using System.Collections.Generic;
using NerdDinner.Cqrs.Commands;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.Aggregates
{
    public class Dinner
    {
        public static void HostDinner(HostDinner command, Models.Dinner dinner, NerdDinnerContext db)
        {
            dinner.HostedBy = command.HostedBy;

            RSVP rsvp = new RSVP();
            rsvp.AttendeeName = command.HostedBy;

            dinner.RSVPs = new List<RSVP>();
            dinner.RSVPs.Add(rsvp);

            db.Dinners.Add(dinner);
            db.SaveChanges();
        }
    }
}