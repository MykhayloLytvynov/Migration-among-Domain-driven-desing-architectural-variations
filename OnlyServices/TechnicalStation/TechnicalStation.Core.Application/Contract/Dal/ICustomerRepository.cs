// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Customer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Application.Contract.Dal;
using System.Threading.Tasks;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.Application.Contract.Dal
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByFirstNameAndLastName(string firstName, string lastName);

    }	
}