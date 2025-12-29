using System.Threading.Tasks;
using Common.Application.Contract.Events.Integration;

namespace Common.Application.Events.Integration
{
    public abstract class IntegrationEventHandlerBase<TEvent> :
        IIntegrationEventHandler<TEvent> where TEvent : class, IIntegrationEvent
    {
        public Task HandleAsync(IIntegrationEvent @event)
        {
            return HandleAsync(@event as TEvent);
        }

        public abstract Task HandleAsync(TEvent @event);
    }
}
