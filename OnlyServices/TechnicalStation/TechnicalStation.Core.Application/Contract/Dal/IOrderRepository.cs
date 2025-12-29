// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Application.Contract.Dal;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Application.Contract.Dal
{
    public interface IOrderRepository : IRepository<Order>
	{
	}	
}