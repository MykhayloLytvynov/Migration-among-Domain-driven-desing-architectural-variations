using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Car
{
    public class CarDeletedDomainEvent : DomainEventBase
    {
        public CarDeletedDomainEvent(int carId, int customerId)
        {
            CarId = carId;
            CustomerId = customerId;
        }

        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
    }
}
