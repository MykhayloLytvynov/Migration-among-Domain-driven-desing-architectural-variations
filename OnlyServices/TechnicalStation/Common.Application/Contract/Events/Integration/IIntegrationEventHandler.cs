using System.Threading.Tasks;

namespace Common.Application.Contract.Events.Integration
{
    public interface IIntegrationEventHandler
    {
        Task HandleAsync(IIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler<in T> : IIntegrationEventHandler where T : IIntegrationEvent
    {
        Task HandleAsync(T integrationEvent);
    }
}
