using System;
using System.Threading.Tasks;
using Common.Application.Service;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service.Activity;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Domain.Work;

namespace TechnicalStation.Core.Application.Service
{
    public class WorkService : ServiceBase<Work>, IWorkService
    {
        private readonly IWorkRepository workRepository;
        private readonly CheckIfOrderExistsActivity checkIfOrderExistsActivity;
        private readonly CheckIfWorkerExistsActivity checkIfWorkerExistsActivity;

        public WorkService(IWorkRepository workRepository, 
            IOrderRepository orderRepository, 
            IWorkerRepository workerRepository) : base(workRepository)
        {
            this.workRepository = workRepository;
            this.checkIfOrderExistsActivity = new CheckIfOrderExistsActivity(orderRepository);
            this.checkIfWorkerExistsActivity = new CheckIfWorkerExistsActivity(workerRepository);
        }

        public override async Task<Work> AddAsync(Work work)
        {
            await this.CheckReferences(work);

            Work result = await base.AddAsync(work);

            var domainEvent = new WorkAddedDomainEvent(work.Id, work.OrderId, work.WorkerId,
            work.StartDate, work.FinishDate, work.Cost, work.SupplyExpenses,
            work.WorkExpenses, work.Description, work.Notes, work.ModifyTime);

            await PublishEvent(domainEvent);
           
            return result;
        }

        public override async Task<Work> UpdateAsync(Work work)
        {
            await this.CheckReferences(work);

            Work newValuesWork = await base.UpdateAsync(work);
            
            var domainEvent = new WorkUpdatedDomainEvent(work.Id, work.OrderId, work.WorkerId);
            
            await PublishEvent(domainEvent);

            return newValuesWork;
        }

        public override async Task RemoveAsync(int workId)
        {
            Work workToRemove = await workRepository.GetByIdAsync(workId);

            var domainEvent = new WorkDeletedDomainEvent(workToRemove.Id, workToRemove.OrderId, workToRemove.WorkerId);
           
            await workRepository.DeleteAsync(workId);

            await PublishEvent(domainEvent);
        }

        protected async Task CheckReferences(Work work)
        {
            var order = await this.checkIfOrderExistsActivity.Execute(work.OrderId);
            var worker = await this.checkIfWorkerExistsActivity.Execute(work.WorkerId);
        }
    }
}
