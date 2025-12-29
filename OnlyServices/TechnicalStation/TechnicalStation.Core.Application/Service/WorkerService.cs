using System.Threading.Tasks;
using Common.Application.Service;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service.Activity;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Application.Service
{
    public class WorkerService : ServiceBase<Worker>, IWorkerService
    {
        private IWorkerRepository workerRepository;
        protected readonly CheckIfWorkerExistsActivity checkIfWorkerExistsActivity;

        public WorkerService(IWorkerRepository workerRepository) : base(workerRepository)
        {
            this.workerRepository = workerRepository;
            this.checkIfWorkerExistsActivity = new CheckIfWorkerExistsActivity(workerRepository);
        }

        public override async Task<Worker> AddAsync(Worker worker)
        {
            await this.checkIfWorkerExistsActivity.Execute(worker);

            await workerRepository.AddAsync(worker);
            var domainEvent = new WorkerAddedDomainEvent(worker.Id, worker.FirstName, worker.LastName, worker.Address, worker.PhoneNumber, worker.Notes, worker.ModifyTime);
            
            await PublishEvent(domainEvent);
            Worker result = await workerRepository.GetByIdAsync(worker.Id);

            return result;
        }

        public override async Task<Worker> UpdateAsync(Worker worker)
        {
            await workerRepository.UpdateAsync(worker);
            Worker newValuesWorker = await workerRepository.GetByIdAsync(worker.Id);
            var domainEvent = new WorkerAddedDomainEvent(worker.Id, worker.FirstName, worker.LastName, worker.Address, worker.PhoneNumber, worker.Notes, worker.ModifyTime);
            
            await PublishEvent(domainEvent);
            return newValuesWorker;
        }

        public override async Task RemoveAsync(int workerId)
        {
            Worker workerToRemove = await workerRepository.GetByIdAsync(workerId);
            var domainEvent = new WorkerDeletedDomainEvent(workerToRemove.Id, workerToRemove.FirstName, workerToRemove.LastName);
            
            await workerRepository.DeleteAsync(workerId);
            
            await PublishEvent(domainEvent);
        }

    }
}
