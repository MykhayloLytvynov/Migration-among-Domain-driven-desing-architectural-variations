using System.Threading.Tasks;

namespace Common.Domain.Events
{
    public interface IDomainEventDispatcher
    {  
        void Subscribe<T>(IDomainEventHandler<T> eventHandler) where T : IDomainEvent;

        Task DispatchAsync<T>(T domainEvent) where T : IDomainEvent;
    }


}
