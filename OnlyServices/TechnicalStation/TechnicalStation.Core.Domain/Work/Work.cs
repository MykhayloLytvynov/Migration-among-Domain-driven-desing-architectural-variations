// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Work.cs" company="DNU">
//  DNU
// </copyright>
// <summary>
//   Defines the Work type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Common.Domain;

namespace TechnicalStation.Core.Domain.Work
{
    using Common.Domain.Entity;
    using System;
    using TechnicalStation.Core.Domain.Car;
    using TechnicalStation.Core.Domain.Customer;
    using TechnicalStation.Core.Domain.Extensions;
    using TechnicalStation.Core.Domain.Order;


    /// <summary>
    /// The Work
    /// </summary>
    public class Work : EntityBase, Identifiable
    {
        #region Fields

        /// <summary>
        /// Gets or sets the  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the  order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the  worker id
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// Gets or sets the  start date
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the  finish date
        /// </summary>
        public DateTime FinishDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the  cost
        /// </summary>
        public double Cost { get; set; } = 0;

        /// <summary>
        /// Gets or sets the  supply expenses
        /// </summary>
        public double SupplyExpenses { get; set; } = 0;

        /// <summary>
        /// Gets or sets the  work expenses
        /// </summary>
        public double WorkExpenses { get; set; } = 0;

        /// <summary>
        /// Gets or sets the  description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the  notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        #endregion

        public Work() { }

        #region Methods
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherWork = (Work)obj;
            return this.Id == otherWork.Id &&
            this.OrderId == otherWork.OrderId &&
            this.WorkerId == otherWork.WorkerId &&
            this.StartDate.RoundToSeconds() == otherWork.StartDate.RoundToSeconds() &&
            this.FinishDate.RoundToSeconds() == otherWork.FinishDate.RoundToSeconds() &&
            this.Cost == otherWork.Cost &&
            this.SupplyExpenses == otherWork.SupplyExpenses &&
            this.Description == otherWork.Description &&
            this.Notes == otherWork.Notes;
        }
        #endregion
    }
}