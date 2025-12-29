using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Car
{
    public class CarAddedDomainEvent : DomainEventBase
    {
        public CarAddedDomainEvent(int carId, int customerId, string producer, string model, string color, string number, int year)
        {
            CarId = carId;
            CustomerId = customerId;
            Producer = producer;
            Model = model;
            Color = color;
            Number = number;
            Year = year;
        }

        public int CarId { get; }
        public int CustomerId { get; }
        public string Producer { get; }
        public string Model { get; }
        public string Color { get; }
        public string Number { get; }
        public int Year { get; }
    }

}
