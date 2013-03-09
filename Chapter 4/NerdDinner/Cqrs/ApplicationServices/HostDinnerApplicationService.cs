using NerdDinner.Models;

namespace NerdDinner.Cqrs.ApplicationServices
{
    public class HostDinnerApplicationService : IDinnerApplicationService
    {
        private readonly NerdDinnerContext _db;

        public HostDinnerApplicationService(NerdDinnerContext db)
        {
            _db = db;
        }

        public void When(HostDinner command)
        {
            Aggregates.Dinner.HostDinner(command, _db);
        }
    }
}