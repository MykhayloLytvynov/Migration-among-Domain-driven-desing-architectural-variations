using System;

namespace Common.Domain.Events
{
    // https://devblogs.microsoft.com/cesardelatorre/using-domain-events-within-a-net-core-microservice/
    // http://www.kamilgrzybek.com/design/how-to-publish-and-handle-domain-events/
    // https://stackoverflow.com/questions/30625363/implementing-domain-event-handler-pattern-in-c-sharp-with-simple-injector
    public interface IDomainEvent : ITraceable
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
