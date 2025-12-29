using Common.Application.Contract.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.Application.Service.Activity
{
    public class CheckIfCarExistsActivity : ICheckIfExistsActivity<Car>
    {
        private ICarRepository carRepository;

        public CheckIfCarExistsActivity(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<Car> Execute(int id, bool throwIfDoesNotExist = true)
        {
            Car existedEntity = await this.carRepository.GetByIdAsync(id);

            if (existedEntity == null && throwIfDoesNotExist)
            {
                string message = $"Car with Id: {id} does not exist.";

                throw new DataException(message);
            }

            return existedEntity;
        }

        public Task<Car> Execute(Car entity, bool throwIfExists = true)
        {
            throw new NotImplementedException();
        }
    }
}
