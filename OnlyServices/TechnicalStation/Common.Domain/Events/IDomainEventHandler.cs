using System.Threading.Tasks;

namespace Common.Domain.Events
{
    public interface IDomainEventHandler
    {
        Task HandleAsync(IDomainEvent @event);
    }

    public interface IDomainEventHandler<in T> : IDomainEventHandler where T: IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}
