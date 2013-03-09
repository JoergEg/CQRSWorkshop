using NerdDinner.Cqrs.Commands;
using NerdDinner.Models;

namespace NerdDinner.Cqrs.CommandHandlers
{
    public class HostDinnerCommandHandler
    {
        public void Handle(HostDinner command, Dinner dinner, NerdDinnerContext db)
        {
            Aggregates.Dinner.HostDinner(command, dinner, db);
        }
    }
}