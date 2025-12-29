using System.Threading.Tasks;

namespace Common.Application.Contract.Events.Integration
{
    public interface IIntegrationEventDispatcher
    {
        void Register<T>(IIntegrationEventHandler<T> eventHandler) where T : IIntegrationEvent;

        Task DispatchAsync<T>(T integrationEvent) where T : IIntegrationEvent;
    }
}
