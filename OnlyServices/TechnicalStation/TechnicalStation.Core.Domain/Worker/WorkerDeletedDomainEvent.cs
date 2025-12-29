using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Worker
{
    public class WorkerDeletedDomainEvent : DomainEventBase
    {
        public WorkerDeletedDomainEvent(int workerId, string firstName, string lastName)
        {
            WorkerId = workerId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int WorkerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}

