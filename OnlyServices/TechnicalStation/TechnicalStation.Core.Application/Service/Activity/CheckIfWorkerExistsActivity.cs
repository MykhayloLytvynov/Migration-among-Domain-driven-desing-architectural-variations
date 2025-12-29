using System;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Service;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Application.Service.Activity
{
    public class CheckIfWorkerExistsActivity : ICheckIfExistsActivity<Worker>
    {
        private IWorkerRepository workerRepository;

        public CheckIfWorkerExistsActivity(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        public async Task<Worker> Execute(int id, bool throwIfDoesNotExist = true)
        {
            Worker existedEntity = await this.workerRepository.GetByIdAsync(id);

            if (existedEntity == null && throwIfDoesNotExist)
            {
                string message = $"Worker with Id: {id} does not exist.";

                throw new DataException(message);
            }

            return existedEntity;
        }

        public async Task<Worker> Execute(Worker worker, bool throwIfExists = true)
        {
            try
            {
                Worker existedEntity = await this.workerRepository.GetByPhoneNumber(worker.PhoneNumber);

                if (existedEntity != null && throwIfExists)
                {
                    string message = $"Worker with the same phone: {existedEntity.PhoneNumber} already exists. [Id] = {existedEntity.Id}";

                    throw new DataException(message);
                }

                return existedEntity;
            }
            catch (Exception ex)
            {
                if (ex is MissingMemberException && !throwIfExists)
                {
                    throw ex;
                }
                else
                {
                    throw ex;
                }

            }
        }
    }
}
