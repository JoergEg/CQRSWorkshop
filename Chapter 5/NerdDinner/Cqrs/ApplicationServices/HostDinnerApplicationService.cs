using System;
using CommonDomain.Persistence;

namespace NerdDinner.Cqrs.ApplicationServices
{
    public class HostDinnerApplicationService : IDinnerApplicationService
    {
        private readonly IRepository _repository;

        public HostDinnerApplicationService(IRepository repository)
        {
            _repository = repository;
        }

        public void When(HostDinner command)
        {
            var dinner = Aggregates.Dinner.HostDinner(command);
            _repository.Save(dinner, Guid.NewGuid());
        }
    }
}