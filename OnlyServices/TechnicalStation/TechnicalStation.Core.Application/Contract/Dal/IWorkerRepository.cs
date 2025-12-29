// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Worker.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Worker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Common.Application.Contract.Dal;

namespace TechnicalStation.Core.DAL.Contract
{
    using TechnicalStation.Core.Domain.Worker;

    public interface IWorkerRepository : IRepository<Worker>
	{
        Task<Worker> GetByPhoneNumber(string workerPhoneNumber);
    }	
}