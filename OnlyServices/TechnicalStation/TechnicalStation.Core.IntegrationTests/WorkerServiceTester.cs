using System;
using System.Data;
using System.Threading.Tasks;
using Common.Domain.Entity;
using NUnit.Framework;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Domain.Worker;
using TechnicalStation.Core.IntegrationTests.Base;

namespace TechnicalStation.Core.IntegrationTests
{
    [TestFixture]
    public class WorkerServiceTester : TesterBase<IWorkerService, Worker>
    {
        [Test]
        public async Task CheckUniquenessTest()
        {
            Worker worker1 = this.BuildObject();
            Worker worker2 = this.BuildObject();

            await this.AddBasic(worker1);

            var exception = Assert.ThrowsAsync<DataException>(async () => await this.AddBasic(worker2));
            Assert.NotNull(exception);
        }

        protected override void ModifyProperties(Worker worker)
        {
            worker.FirstName = "TempFirstName24";
            worker.LastName = "TempLastName24";
            worker.Address = "TempAddress1";
            worker.PhoneNumber = "380956768746";
            worker.Notes = "test worker service add";
            worker.ModifyTime = DateTime.Now;
        }

        public override Worker BuildObject()
        {
            var worker = new Worker
            {
                FirstName = "TempFirstName24",
                LastName = "TempLastName24",
                Address = "TempAddress1",
                PhoneNumber = "380956768746",
                Notes = "test worker service add",
                ModifyTime = DateTime.Now
            };

            return worker;
        }
    }
}
