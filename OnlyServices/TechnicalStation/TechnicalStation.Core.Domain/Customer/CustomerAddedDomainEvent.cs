using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Customer
{
    public class CustomerAddedDomainEvent : DomainEventBase
    {
        public CustomerAddedDomainEvent(int customerId, string firstName, string lastName, string address, string phoneNumber)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
