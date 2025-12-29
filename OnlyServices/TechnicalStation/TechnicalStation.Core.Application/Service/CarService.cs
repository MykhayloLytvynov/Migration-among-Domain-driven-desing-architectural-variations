using System.Threading.Tasks;
using Common.Application.Contract.Service;
using Common.Application.Service;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service.Activity;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.Application.Service
{
    public class CarService : ServiceBase<Car>, ICarService
    {
        private ICarRepository carRepository;
        private ICheckIfExistsActivity<Customer> checkIfCustomerExistsActivity;

        public CarService(ICarRepository carRepository,
            ICustomerRepository customerRepository) : base(carRepository)
        {
            this.carRepository = carRepository;
            this.checkIfCustomerExistsActivity = new CheckIfCustomerExistsActivity(customerRepository);
        }

        public override async Task<Car> AddAsync(Car car)
        {
            await this.CheckReferences(car);

            Car result = await base.AddAsync(car);
            var domainEvent = new CarAddedDomainEvent(car.Id, car.CustomerId, car.Producer, car.Model, car.Color, car.Number, car.Year);
            
            await PublishEvent(domainEvent);

            return result;
        }

        public override async Task<Car> UpdateAsync(Car car)
        {
            await this.CheckReferences(car);

            Car oldValuesCar = await carRepository.GetByIdAsync(car.Id);

            await carRepository.UpdateAsync(car);
            Car newValuesCar = await carRepository.GetByIdAsync(car.Id);

            var domainEvent = 
                new CarUpdatedDomainEvent(newValuesCar.Id, newValuesCar.CustomerId, 
                    oldValuesCar.Producer, newValuesCar.Producer, 
                    oldValuesCar.Model, newValuesCar.Model, 
                    oldValuesCar.Color, newValuesCar.Color,
                oldValuesCar.Number, newValuesCar.Number, 
                    oldValuesCar.Year, newValuesCar.Year);
            
            

            await PublishEvent(domainEvent);


            return car;
        }

        public override async Task RemoveAsync(int carId)
        {
            Car carToRemove = await carRepository.GetByIdAsync(carId);
            await carRepository.DeleteAsync(carId);            
            
            var domainEvent = new CarDeletedDomainEvent(carToRemove.Id, carToRemove.CustomerId);
            
            await PublishEvent(domainEvent);
        }

        protected async Task CheckReferences(Car car)
        {
            await checkIfCustomerExistsActivity.Execute(car.CustomerId);
        }

    }
}
