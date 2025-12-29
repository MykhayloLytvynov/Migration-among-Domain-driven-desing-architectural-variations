using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Customer
{
    public class CustomerUpdatedDomainEvent : DomainEventBase
    {
        public CustomerUpdatedDomainEvent(int customerId, string oldFirstName, string firstName, string oldLastName, string lastName, string oldAddress, string address, string oldPhoneNumber, string phoneNumber)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            OldFirstName = oldFirstName;
            OldLastName = oldLastName;
            OldAddress = oldAddress;
            OldPhoneNumber = oldPhoneNumber;

        }

        public int CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string OldFirstName { get; private set; }
        public string OldLastName { get; private set; }
        public string OldAddress { get; private set; }
        public string OldPhoneNumber { get; private set; }
    }
}
