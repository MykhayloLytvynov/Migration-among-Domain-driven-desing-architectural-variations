using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Application.Contract.Events.Integration;
using Common.Domain.Events;

namespace Common.Application.Events.Integration
{
    public class IntegrationEventDispatcher : IIntegrationEventDispatcher
    {
        private readonly Dictionary<Type, List<object>> handlers = new Dictionary<Type, List<object>>();

        private static readonly Lazy<IntegrationEventDispatcher> lazy = 
            new Lazy<IntegrationEventDispatcher>(() => new IntegrationEventDispatcher());

        public static IntegrationEventDispatcher Instance => lazy.Value;

        public IntegrationEventDispatcher()
        {
        }

        public async Task DispatchAsync<T>(T integrationEvent) where T : IIntegrationEvent
        {
            if (integrationEvent == null) throw new ArgumentNullException("integrationEvent");

            Type eventType = integrationEvent.GetType();

            foreach (object handler in handlers[eventType])
            {
                await ((IIntegrationEventHandler)handler).HandleAsync(integrationEvent);
            }
        }

        public void Register<T>(IIntegrationEventHandler<T> eventHandler) where T : IIntegrationEvent
        {
            Type type = typeof(T);

            if (!handlers.ContainsKey(type))
            {
                handlers.Add(type, new List<object>());
            }

            handlers[type].Add(eventHandler);
        }
    }
}
