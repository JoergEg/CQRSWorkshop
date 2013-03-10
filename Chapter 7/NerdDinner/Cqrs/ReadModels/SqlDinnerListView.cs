using System.Collections.Generic;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.ReadModels
{
    public class SqlDinnerListView : HandlesEvent<DinnerCreated>
    {
        public void Handle(DinnerCreated @event)
        {
            var db = new NerdDinnerContext();
            var dinner = new Dinner
            {
                Address = @event.Address,
                ContactPhone = @event.ContactPhone,
                Country = @event.Country,
                Description = @event.Description,
                DinnerID = @event.Id.Id,
                EventDate = @event.EventDate,
                HostedBy = @event.HostedBy,
                Title = @event.Title
            };

            var rsvp = new RSVP();
            rsvp.AttendeeName = @event.HostedBy;

            dinner.RSVPs = new List<RSVP>();
            dinner.RSVPs.Add(rsvp);

            db.Dinners.Add(dinner);
            db.SaveChanges();
        }
    }
}