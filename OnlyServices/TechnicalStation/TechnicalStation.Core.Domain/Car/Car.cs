using System;
using Common.Domain;
using Common.Domain.Entity;

namespace TechnicalStation.Core.Domain.Car
{
    public class Car : EntityBase, Identifiable
    {
        /// <summary>
        /// Gets or sets the  id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the  customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the  producer
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Gets or sets the  model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the  color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the  number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the  year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the  modify time
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;

        public Car() { }

        #region Methods
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherCar = (Car)obj;
            return this.Id == otherCar.Id && this.CustomerId == otherCar.CustomerId
                && this.Producer == otherCar.Producer && this.Model == otherCar.Model
                && this.Color == otherCar.Color && this.Number == otherCar.Number
                && this.Year == otherCar.Year;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CustomerId, Producer, Model, Color, Number, Year);
        }
        #endregion
    }
}