// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="DNU">
//  DNU
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Domain;

namespace TechnicalStation.Core.Domain.Order
{
    using Common.Domain.Entity;
    using System;
    using System.Net;
    using TechnicalStation.Core.Domain.Car;
    using TechnicalStation.Core.Domain.Customer;
    using TechnicalStation.Core.Domain.Extensions;


    /// <summary>
    /// The Order
    /// </summary>
    public class Order : EntityBase, Identifiable
    {
        #region Fields

        /// <summary>
        /// Gets or sets the  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the  customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the  car id
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the  start date
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the  finish date
        /// </summary>
        public DateTime FinishDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        #endregion

        public Order() { }

        public Order(int customerId, int carId, DateTime startDate, DateTime finishDate, DateTime modifyTime)
        {
            CustomerId = customerId;
            CarId = carId;
            StartDate = startDate;
            FinishDate = finishDate;
            ModifyTime = modifyTime;
        }

        #region Methods
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherOrder = (Order)obj;
            return this.Id == otherOrder.Id &&
            this.CustomerId == otherOrder.CustomerId &&
            this.CarId == otherOrder.CarId &&
            this.StartDate.RoundToSeconds() == otherOrder.StartDate.RoundToSeconds() &&
            this.FinishDate.RoundToSeconds() == otherOrder.FinishDate.RoundToSeconds();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CustomerId, CarId, StartDate, FinishDate, ModifyTime);
        }

        #endregion
    }
}