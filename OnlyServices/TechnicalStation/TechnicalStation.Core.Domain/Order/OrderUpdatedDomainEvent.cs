using System;
using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderUpdatedDomainEvent : DomainEventBase
    {
        public OrderUpdatedDomainEvent(int orderId, int customerId, int oldCustomerId, int carId, int oldCarId, DateTime startDate, DateTime oldStartDate, DateTime finishDate, DateTime oldFinishDate, DateTime ModifyTime)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CarId = carId;
            StartDate = startDate;
            FinishDate = finishDate;
            this.ModifyTime = ModifyTime;
            OldCustomerId = oldCustomerId;
            OldCarId = oldCarId;
            OldStartDate = oldStartDate;
            OldFinishDate = oldFinishDate;

        }

        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public int CarId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public int OldCustomerId { get; private set; }
        public int OldCarId { get; private set; }
        public DateTime OldStartDate { get; private set; }
        public DateTime OldFinishDate { get; private set; }
        public DateTime OldModifyTime { get; private set; }
    }
}
