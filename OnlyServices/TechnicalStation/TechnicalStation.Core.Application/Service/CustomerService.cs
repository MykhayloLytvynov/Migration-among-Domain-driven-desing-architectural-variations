using System;
using System.Threading.Tasks;
using Common.Application.Service;
using Common.Domain.Rules.Common;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service.Activity;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Customer.Rules;

namespace TechnicalStation.Core.Application.Service
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private ICustomerRepository customerRepository;
        private CheckIfCustomerExistsActivity checkIfCustomerExistsActivity;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
            this.checkIfCustomerExistsActivity = new CheckIfCustomerExistsActivity(customerRepository);
        }

        public override async Task<Customer> AddAsync(Customer customer)
        {
            this.CheckRules(customer);

            await this.checkIfCustomerExistsActivity.Execute(customer);

            await customerRepository.AddAsync(customer);
            var domainEvent = new CustomerAddedDomainEvent(customer.Id, customer.FirstName, customer.LastName,
                customer.Address, customer.PhoneNumber);
            
            await PublishEvent(domainEvent);
            Customer result = await customerRepository.GetByIdAsync(customer.Id);
            return result;
        }

        public override async Task<Customer> UpdateAsync(Customer customer)
        {
            Customer oldValuesCustomer = await customerRepository.GetByIdAsync(customer.Id);

            if (oldValuesCustomer.ModifyTime > customer.ModifyTime)
            {
                throw new Exception($"Customer {customer.Id} was modified since {customer.ModifyTime}.");
            }

            this.CheckRules(customer);

            customer.ModifyTime = DateTime.Now;
            await customerRepository.UpdateAsync(customer);

            Customer newValuesCustomer = await customerRepository.GetByIdAsync(customer.Id);
            var domainEvent = new CustomerUpdatedDomainEvent(newValuesCustomer.Id, oldValuesCustomer.FirstName, newValuesCustomer.FirstName,
                oldValuesCustomer.LastName, newValuesCustomer.LastName, oldValuesCustomer.Address, newValuesCustomer.Address,
                oldValuesCustomer.PhoneNumber, newValuesCustomer.PhoneNumber);
            
            await PublishEvent(domainEvent);

            return newValuesCustomer;
        }

        protected void CheckRules(Customer customer)
        {
            customer.CheckRule(new FirstNameCannotBeLessThanTwoCharactersRule(customer.FirstName));
            customer.CheckRule(new LastNameShouldNotBeEmptyRule(customer.LastName));
            customer.CheckRule(new ValidPhoneNumberRule(customer.PhoneNumber));
        }

        public override async Task RemoveAsync(int customerId)
        {
            Customer customerToRemove = await customerRepository.GetByIdAsync(customerId);
            var domainEvent = new CustomerDeletedDomainEvent(customerToRemove.Id, customerToRemove.FirstName,
                customerToRemove.LastName);
            
            await customerRepository.DeleteAsync(customerId);
            await PublishEvent(domainEvent);
        }
    }
}
