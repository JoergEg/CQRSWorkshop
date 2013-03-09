using CommonDomain.Core;

namespace NerdDinner.Cqrs.Aggregates
{
    public class Dinner : AggregateBase
    {
        private Dinner(HostDinner command)
        {
            RaiseEvent(new DinnerCreated(command.Id, command.HostedBy, command.Title, command.EventDate,
                                         command.Description, command.ContactPhone, command.Address, command.Country));
        }

        public static Dinner HostDinner(HostDinner command)
        {
            return new Dinner(command);
        }
    }
}