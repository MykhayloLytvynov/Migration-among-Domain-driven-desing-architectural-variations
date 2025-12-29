// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Work.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Work type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Common.Application.Contract.Dal;

namespace TechnicalStation.Core.DAL.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechnicalStation.Core.Domain.Car;
    using TechnicalStation.Core.Domain.Work;

    public interface IWorkRepository : IRepository<Work>
	{
        Task<List<Work>> GetByOrderIdAsync(int orderId);
        Task<List<Work>> GetByWorkerIdAsync(int workerId);
    }	
}