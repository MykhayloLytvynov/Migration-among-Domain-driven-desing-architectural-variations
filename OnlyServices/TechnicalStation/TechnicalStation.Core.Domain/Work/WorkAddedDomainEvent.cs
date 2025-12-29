using System;
using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.Work
{
    public class WorkAddedDomainEvent : DomainEventBase
    {
        public WorkAddedDomainEvent(int workId, int orderId, int workerId, DateTime startDate, DateTime finishDate, double cost, double supplyExpenses,
            double workExpenses, string description, string notes, DateTime ModifyTime)
        {
            this.WorkId = workId;
            this.OrderId = orderId;
            this.WorkerId = workerId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;
            this.Cost = cost;
            this.SupplyExpenses = supplyExpenses;
            this.WorkExpenses = workExpenses;
            this.Notes = notes;
            this.Description = description;
            this.ModifyTime = ModifyTime;
        }

        public int WorkerId { get; private set; }
        public double Cost { get; private set; }
        public double SupplyExpenses { get; private set; }
        public double WorkExpenses { get; private set; }
        public string Notes { get; private set; }
        public string Description { get; private set; }
        public int WorkId { get; private set; }
        public int OrderId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public DateTime ModifyTime { get; private set; }
    }
}
