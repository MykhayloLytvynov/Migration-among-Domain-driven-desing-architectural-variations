using Common.Application.Contract.Events.Integration;
using Common.Domain.Extensions;
using System;

namespace Common.Application.Events.Integration
{
    public class IntegrationEventBase : IIntegrationEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        public IntegrationEventBase()
        {
            this.Id = Guid.NewGuid();
            this.OccurredOn = DateTime.Now;
        }

        public string GetTrace(int tabs = 0)
        {
            return this.GetFieldValueCollection(tabs);
        }
    }
}
