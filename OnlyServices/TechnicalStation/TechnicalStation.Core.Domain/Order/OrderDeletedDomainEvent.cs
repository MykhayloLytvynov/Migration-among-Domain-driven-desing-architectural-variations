using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderDeletedDomainEvent : DomainEventBase
    {
        public OrderDeletedDomainEvent(int orderId, int customerId, int carId)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CarId = carId;
        }

        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public int CarId { get; private set; }
    }
}
