using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Customer
{
    public class CustomerDeletedDomainEvent : DomainEventBase
    {
        public CustomerDeletedDomainEvent(int customerId, string firstName, string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
