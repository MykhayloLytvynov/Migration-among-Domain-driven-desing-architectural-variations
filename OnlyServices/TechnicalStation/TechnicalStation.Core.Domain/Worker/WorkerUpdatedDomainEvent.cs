using System;
using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Worker
{
    public class WorkerUpdatedDomainEvent : DomainEventBase
    {
        public WorkerUpdatedDomainEvent(int workerId, string firstName, string lastName, string address, string phoneNumber, string notes, DateTime modifyTime)
        {
            WorkerId = workerId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
            Notes = notes;
            ModifyTime = modifyTime;
        }

        public int WorkerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Notes { get; private set; }
        public DateTime ModifyTime { get; private set; }
    }
}
