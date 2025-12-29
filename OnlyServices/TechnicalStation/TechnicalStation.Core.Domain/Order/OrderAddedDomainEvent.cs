using System;
using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Order
{
    public class OrderAddedDomainEvent : DomainEventBase
    {
        public OrderAddedDomainEvent(int orderId, int customerId, int carId, DateTime startDate, DateTime finishDate, DateTime ModifyTime)
        {
            OrderId = orderId;
            CustomerId = customerId;
            CarId = carId;
            StartDate = startDate;
            FinishDate = finishDate;
            this.ModifyTime = ModifyTime;
        }

        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public int CarId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public DateTime ModifyTime { get; private set; }
    }
}
