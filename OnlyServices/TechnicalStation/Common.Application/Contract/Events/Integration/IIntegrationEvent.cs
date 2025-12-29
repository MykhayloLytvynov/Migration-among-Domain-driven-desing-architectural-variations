using Common.Domain;
using System;

namespace Common.Application.Contract.Events.Integration
{
    public interface IIntegrationEvent : ITraceable
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
