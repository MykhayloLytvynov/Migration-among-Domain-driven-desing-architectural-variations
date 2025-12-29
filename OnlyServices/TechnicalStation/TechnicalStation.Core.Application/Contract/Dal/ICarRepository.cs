// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Car.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Car type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Application.Contract.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.Application.Contract.Dal
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<List<Car>> GetByCustomerIdAsync(int id);

    }	
}