using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Events
{
    public sealed class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly Dictionary<Type, List<object>> handlers = new Dictionary<Type, List<object>>();

        private static readonly Lazy<DomainEventDispatcher> lazy = new Lazy<DomainEventDispatcher>(() => new DomainEventDispatcher());

        public static DomainEventDispatcher Instance => lazy.Value;

        public DomainEventDispatcher()
        {
        }

        public void Subscribe<T>(IDomainEventHandler<T> eventHandler) where T : IDomainEvent
        {
            Type type = typeof(T);

            if (!this.handlers.ContainsKey(type))
            {
                this.handlers.Add(type, new List<object>());
            }

            this.handlers[type].Add(eventHandler);
        }

        public async Task DispatchAsync<T>(T domainEvent) where T: IDomainEvent
        {
            if (domainEvent == null) throw new ArgumentNullException("domainEvent");

            Type eventType = domainEvent.GetType();
            
            foreach (object handler in this.handlers[eventType])
            {
                await ((IDomainEventHandler)handler).HandleAsync(domainEvent);
            }

        }
    }
}
