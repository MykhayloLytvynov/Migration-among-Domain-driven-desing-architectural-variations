using System.Collections.Generic;
using System;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Dal.Query;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository() : base()
        {
        }

        public CarRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, Car car)
        {
            dbCommand.AddParameter("@CustomerId", car.CustomerId);
            dbCommand.AddParameter("@Producer", car.Producer);
            dbCommand.AddParameter("@Model", car.Model);
            dbCommand.AddParameter("@Color", car.Color);
            dbCommand.AddParameter("@Number", car.Number);
            dbCommand.AddParameter("@Year", car.Year);
            dbCommand.AddParameter("@ModifyTime", car.ModifyTime);
        }

        public async Task<List<Car>> GetByCustomerIdAsync(int id)
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "CustomerId", "=", $"{id}", false));
            
            string queryCommand = this.databaseContext.Translate(query);

            Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);

            List<Car> collection = await this.databaseContext.ExecuteReaderAsync<Car>(command);

            return collection;
        }
    }
}