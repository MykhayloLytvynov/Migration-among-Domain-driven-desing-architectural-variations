using Common.Application.Contract.Service;
using System;
using System.Data;
using System.Threading.Tasks;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.Application.Service.Activity
{
    public class CheckIfCustomerExistsActivity : ICheckIfExistsActivity<Customer>
    {
        private ICustomerRepository customerRepository;

        public CheckIfCustomerExistsActivity(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Execute(int id, bool throwIfDoesNotExist = true)
        {
            Customer existedEntity = await this.customerRepository.GetByIdAsync(id);

            if (existedEntity == null && throwIfDoesNotExist)
            {
                string message = $"Customer with Id: {id} does not exist.";

                throw new DataException(message);
            }

            return existedEntity;
        }

        public async Task<Customer> Execute(Customer entity, bool throwIfExists = true)
        {
            Customer existedEntity = await this.customerRepository.GetByFirstNameAndLastName(entity.FirstName, entity.LastName);

            if (existedEntity != null && throwIfExists)
            {
                string message = $"Customer with the Name: {existedEntity.FirstName} {existedEntity.LastName} already exists. [Id] = {existedEntity.Id}";

                throw new DataException(message);
            }

            //existedEntity = this.GetCustomerByName(entity.Name);

            //if (existedEntity != null && throwIfExists)
            //{
            //    string message = $"Customer with the name: {existedEntity.Name} already exists. [Id] = {existedEntity.Id}";

            //    throw new DataException(message);
            //}

            return existedEntity;
        }


        private Customer GetCustomerByName(string name)
        {
            try
            {
                //Customer Customer = this.customerRepository.GetCustomerByName(name);
                //return Customer;
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private Customer GetCustomerByShortName(string shortName)
        {
            try
            {
                //Customer Customer = this.customerRepository.GetCustomerByShortName(shortName);
                //return Customer;
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
