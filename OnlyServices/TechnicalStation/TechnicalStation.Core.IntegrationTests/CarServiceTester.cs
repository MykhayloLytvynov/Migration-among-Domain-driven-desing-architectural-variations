using NUnit.Framework;
using System.Threading.Tasks;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.IntegrationTests.Base;

namespace TechnicalStation.Core.IntegrationTests
{
    [TestFixture]
    public class CarServiceTester : TesterBase<ICarService, Car>
    {
        private CustomerServiceTester customerServiceTester;

        public CarServiceTester(): base()
        {
            this.customerServiceTester = new CustomerServiceTester();
        }

        public override async Task<Car> AddBasic(Car car)
        {
            Customer customer = await this.customerServiceTester.AddBasic();

            car.CustomerId = customer.Id;

            return await base.AddBasic(car);
        }

        [TearDown]
        public override async Task TearDown()
        {
            await customerServiceTester.TearDown();
            await base.TearDown();
        }

        protected override void ModifyProperties(Car car)
        {
            car.Producer = "Mazda";
            car.Model = "CamryC";
            car.Color = "White";
            car.Number = "ABC123";
            car.Year = 2022;
        }

        public override Car BuildObject()
        {
            var car = new Car
            {
                Producer = "Toyota",
                Model = "Camry",
                Color = "Black",
                Number = "ABC123",
                Year = 2024
            };

            return car;
        }

    }
}
