using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;
using TechnicalStation.Core.IntegrationTests.Base;

namespace TechnicalStation.Core.IntegrationTests
{
    [TestFixture]
    public class WorkServiceTester : TesterBase<IWorkService, Work>
    {
        private OrderServiceTester orderServiceTester;
        private WorkerServiceTester workerServiceTester;

        public WorkServiceTester()
        {
            this.orderServiceTester = new OrderServiceTester();
            this.workerServiceTester = new WorkerServiceTester();
        }

        public override async Task<Work> AddBasic(Work work)
        {
            Order order = await this.orderServiceTester.AddBasic();
            Worker worker = await this.workerServiceTester.AddBasic();

            work.OrderId = order.Id;
            work.WorkerId = worker.Id;

            return await base.AddBasic(work);
        }


        [TearDown]
        public override async Task TearDown()
        {
            await orderServiceTester.TearDown();
            await workerServiceTester.TearDown();
            await base.TearDown();
        }

        protected override void ModifyProperties(Work work)
        {
            work.StartDate = DateTime.Now.AddDays(-4);
            work.FinishDate = DateTime.Now;
            work.Cost = 2000;
            work.SupplyExpenses = 1305;
            work.WorkExpenses = 70;
            work.Description = "trialDescription";
            work.Notes = "any notes";
            work.ModifyTime = DateTime.Now;
        }

        public override Work BuildObject()
        {
            var work = new Work
            {
                StartDate = DateTime.Now,
                FinishDate = DateTime.Now.AddDays(7),
                Cost = 200,
                SupplyExpenses = 130,
                WorkExpenses = 70,
                Description = "trialDescription",
                Notes = "any notes",
                ModifyTime = DateTime.Now
            };

            return work;
        }
    }
}
