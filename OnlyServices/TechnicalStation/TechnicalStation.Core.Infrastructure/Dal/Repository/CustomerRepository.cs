using System.Collections.Generic;
using System;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Dal.Query;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base()
        {
        }

        public CustomerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, Customer customer)
        {
            dbCommand.AddParameter("@FirstName", customer.FirstName);
            dbCommand.AddParameter("@LastName", customer.LastName);
            dbCommand.AddParameter("@Address", customer.Address);
            dbCommand.AddParameter("@PhoneNumber", customer.PhoneNumber);
            dbCommand.AddParameter("@ModifyTime", customer.ModifyTime);

        }

        public async Task<Customer> GetByFirstNameAndLastName(string firstName, string lastName)
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "LastName", "=", $"'{lastName}'", true));
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "FirstName", "=", $"'{firstName}'", false));

            string queryCommand = this.databaseContext.Translate(query);

            Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);
            
            List<Customer> collection = await this.databaseContext.ExecuteReaderAsync<Customer>(command);

            if (collection.Count == 0)
            {
                return null;
            }

            return collection[0];
        }

    }
}