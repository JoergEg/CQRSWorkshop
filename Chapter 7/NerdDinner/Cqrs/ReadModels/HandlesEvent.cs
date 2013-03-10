// ReSharper disable InconsistentNaming

namespace NerdDinner.Cqrs.ReadModels
{
    public interface HandlesEvent<in T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}