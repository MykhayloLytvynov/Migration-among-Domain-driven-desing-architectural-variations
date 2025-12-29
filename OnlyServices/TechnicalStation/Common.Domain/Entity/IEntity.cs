using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Events;

namespace Common.Domain.Entity
{
    public interface IEntity : Identifiable
    {
        IEnumerable<IDomainEvent> Events { get; }
    }
}
