using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Work
{
    public class WorkUpdatedDomainEvent : DomainEventBase
    {
        public WorkUpdatedDomainEvent(int workId, int orderId, int workerId)
        {
            this.WorkId = workId;
            this.OrderId = orderId;
            this.WorkerId = workerId;
        }

        public int WorkerId { get; private set; }
        public int WorkId { get; private set; }
        public int OrderId { get; private set; }
    }
}
