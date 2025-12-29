using System;
using Common.Domain.Extensions;

namespace Common.Domain.Events
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurredOn { get; }

        public DomainEventBase()
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
