using NUnit.Framework;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain.Rules;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.IntegrationTests.Base;

namespace TechnicalStation.Core.IntegrationTests
{
    public class CustomerServiceTester : TesterBase<ICustomerService, Customer>
    {
        [Test]
        public async Task CheckFirstNameRuleTest()
        {
            Customer customer = this.BuildObject();
            customer.FirstName = "E";

            var exception = Assert.ThrowsAsync<RuleValidationException>(async () => await this.AddBasic(customer));
            Assert.NotNull(exception);
        }

        [Test]
        public async Task CheckPhoneNumberRuleTest()
        {
            Customer customer = this.BuildObject();
            customer.PhoneNumber = "345267";

            var exception = Assert.ThrowsAsync<RuleValidationException>(async () => await this.AddBasic(customer));
            Assert.NotNull(exception);
        }

        [Test]
        public async Task CheckUniquenessTest()
        {
            Customer customer1 = this.BuildObject();
            Customer customer2 = this.BuildObject();

            await this.AddBasic(customer1);

            var exception = Assert.ThrowsAsync<DataException>(async () => await this.AddBasic(customer2));
            Assert.NotNull(exception);
        }

        [Test]
        public async Task CustomerCannotBeModifiedAfterModificationTest()
        {
            Customer customer = this.BuildObject();
           
            await this.AddBasic(customer);

            Thread.Sleep(200);

            Customer customerAfter = await this.service.GetAsync(customer.Id);
            await this.service.UpdateAsync(customerAfter);
            this.CheckNotifications(1);

            Assert.That(customerAfter.ModifyTime != customer.ModifyTime);

            var exception = Assert.ThrowsAsync<Exception>(async () => await this.service.UpdateAsync(customer));
            Assert.NotNull(exception);
        }

        protected override void ModifyProperties(Customer customer)
        {
            customer.FirstName = "TrialCustomerFirstName35";
            customer.LastName = "TrialCustomerLastName";
            customer.Address = "TrialCustomerAddress";
            customer.PhoneNumber = "0959993432";
            customer.ModifyTime = DateTime.Now;
        }

        public override Customer BuildObject()
        {
            var customer = new Customer
            {
                FirstName = "TrialCustomerFirstName35",
                LastName = "TrialCustomerLastName",
                Address = "TrialCustomerAddress",
                PhoneNumber = "0951231231",
                ModifyTime = DateTime.Now
            };

            return customer;
        }
    }
}
