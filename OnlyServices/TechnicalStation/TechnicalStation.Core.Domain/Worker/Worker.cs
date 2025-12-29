// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Worker.cs" company="DNU">
//  DNU
// </copyright>
// <summary>
//   Defines the Worker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Domain;

namespace TechnicalStation.Core.Domain.Worker
{
    using Common.Domain.Entity;
    using System;
    using TechnicalStation.Core.Domain.Work;


    /// <summary>
    /// The Worker
    /// </summary>
    public class Worker : EntityBase, Identifiable
    {
        #region Fields

        /// <summary>
        /// Gets or sets the  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the  first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the  last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the  address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the  phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the  notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        #endregion

        public Worker() { }

        #region Methods
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherWorker = (Worker)obj;
            return this.Id == otherWorker.Id &&
            this.FirstName == otherWorker.FirstName &&
            this.LastName == otherWorker.LastName &&
            this.Address == otherWorker.Address &&
            this.PhoneNumber == otherWorker.PhoneNumber &&
            this.Notes == otherWorker.Notes;
        }

        #endregion
    }
}