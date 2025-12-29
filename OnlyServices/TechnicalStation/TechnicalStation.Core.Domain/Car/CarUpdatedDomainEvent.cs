using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Car
{
    public class CarUpdatedDomainEvent : DomainEventBase
    {
        public CarUpdatedDomainEvent(int carId, int customerId, string oldProducer, string newProducer, string oldModel, string newModel, string oldColor, string newColor, string oldNumber, string newNumber, int oldYear, int newYear)
        {
            CarId = carId;
            CustomerId = customerId;
            OldProducer = oldProducer;
            NewProducer = newProducer;
            OldModel = oldModel;
            NewModel = newModel;
            OldColor = oldColor;
            NewColor = newColor;
            OldNumber = oldNumber;
            NewNumber = newNumber;
            OldYear = oldYear;
            NewYear = newYear;
        }

        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
        public string OldProducer { get; private set; }
        public string NewProducer { get; private set; }
        public string OldModel { get; private set; }
        public string NewModel { get; private set; }
        public string OldColor { get; private set; }
        public string NewColor { get; private set; }
        public string OldNumber { get; private set; }
        public string NewNumber { get; private set; }
        public int OldYear { get; private set; }
        public int NewYear { get; private set; }
    }
}
