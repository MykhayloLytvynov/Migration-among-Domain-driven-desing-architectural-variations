using System.Threading.Tasks;

namespace Common.Domain.Events
{
    public abstract class DomainEventHandlerBase<TEvent> : IDomainEventHandler<TEvent> where TEvent : class, IDomainEvent
    {
        public Task HandleAsync(IDomainEvent @event)
        {
            return HandleAsync(@event as TEvent);
        }

        public abstract Task HandleAsync(TEvent @event);
    }
}
