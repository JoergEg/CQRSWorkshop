using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using NerdDinner.Models;
using Dapper;

namespace NerdDinner.Cqrs.ReadModels
{
    public class DinnerListView : HandlesEvent<DinnerCreated>
    {
        public void Handle(DinnerCreated @event)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
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

                    con.Execute("INSERT INTO Dinners (DinnerId, Title, EventDate, Description, HostedBy, ContactPhone, Address, Country) VALUES (@DinnerID, @Title, @EventDate, @Description, @HostedBy, @ContactPhone, @Address, @Country)", dinner, transaction);

                    con.Execute("INSERT INTO RSVPs (DinnerId, AttendeeName) VALUES (@Id, @HostedBy)", new {@event.Id.Id, @event.HostedBy}, transaction);

                    transaction.Commit();
                }
            }
        }

        private static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["NerdDinnerContext"].ConnectionString; }
        }
    }
}