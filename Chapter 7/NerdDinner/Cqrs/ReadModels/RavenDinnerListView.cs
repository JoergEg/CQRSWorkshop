using System.Collections.Generic;
using NerdDinner.Infrastructure;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.ReadModels
{
    public class RavenDinnerListView : HandlesEvent<DinnerCreated>
    {
        public void Handle(DinnerCreated @event)
        {
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

            var rsvp = new RSVP { AttendeeName = @event.HostedBy };
            dinner.RSVPs = new List<RSVP> { rsvp };

            using (var session = Globals.RavenDocumentStore.OpenSession())
            {
                session.Store(dinner);
                session.SaveChanges();
            }
        }
    }
}