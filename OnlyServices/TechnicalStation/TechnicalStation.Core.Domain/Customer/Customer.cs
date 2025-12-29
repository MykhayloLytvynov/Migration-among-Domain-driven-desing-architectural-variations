// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="DNU">
//  DNU
// </copyright>
// <summary>
//   Defines the Customer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Domain;

namespace TechnicalStation.Core.Domain.Customer
{
    using Common.Domain.Entity;
    using System;
    using TechnicalStation.Core.Domain.Car;


    /// <summary>
    /// The Customer
    /// </summary>
    public class Customer : EntityBase, Identifiable
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
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;


        #endregion

        public Customer() { }

        public Customer(string firstName, string lastName, string address, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        #region Methods
        //public void AddCustomer(int customerId, string firstName, string lastName, string address, string phoneNumber)
        //{
        //    var customerAddedEvent = new CustomerAdded(customerId, firstName, lastName, address, phoneNumber);
        //    this.AddEvent(customerAddedEvent);
        //}

        //public void DeleteCustomer()
        //{
        //    var customerDeletedEvent = new CustomerDeleted(this.Id, this.FirstName, this.LastName);
        //    this.AddEvent(customerDeletedEvent);
        //}

        //public void UpdateCustomer(int customerId, string oldFirstName, string firstName, string oldLastName, string lastName, string oldAddress, string address, string oldPhoneNumber, string phoneNumber)
        //{
        //    var customerUpdatedEvent = new CustomerUpdated(this.Id, oldFirstName, firstName, oldLastName, lastName, oldAddress, address, oldPhoneNumber, phoneNumber);
        //    this.AddEvent(customerUpdatedEvent);
        //}

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherCustomer = (Customer)obj;
            return this.Id == otherCustomer.Id && this.FirstName == otherCustomer.FirstName
                && this.LastName == otherCustomer.LastName && this.Address == otherCustomer.Address
                && this.PhoneNumber == otherCustomer.PhoneNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Address, PhoneNumber, ModifyTime);
        }

        #endregion
    }
}