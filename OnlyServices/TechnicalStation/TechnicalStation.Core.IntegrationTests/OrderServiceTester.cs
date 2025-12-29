using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.IntegrationTests.Base;

namespace TechnicalStation.Core.IntegrationTests
{
    [TestFixture]
    public class OrderServiceTester : TesterBase<IOrderService, Order>
    {
        private CarServiceTester carServiceTester;

        public OrderServiceTester()
        {
            this.carServiceTester = new CarServiceTester();
        }

        public override async Task<Order> AddBasic(Order order)
        {
            Car car = await this.carServiceTester.AddBasic();

            order.CustomerId = car.CustomerId;
            order.CarId = car.Id;

            return await base.AddBasic(order);
        }

        [TearDown]
        public override async Task TearDown()
        {
            await carServiceTester.TearDown();
            await base.TearDown();
        }

        protected override void ModifyProperties(Order order)
        {
            order.FinishDate = DateTime.Now;
            order.ModifyTime = DateTime.Now;
        }

        public override Order BuildObject()
        {
            var order = new Order
            {
                StartDate = DateTime.Now.AddDays(-7),
                //FinishDate = DateTime.Now.AddDays(7),
                ModifyTime = DateTime.Now
            };

            return order;
        }
    }
}
