using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Dal.Query;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class WorkerRepository : RepositoryBase<Worker>, IWorkerRepository
    {
        public WorkerRepository() : base()
        {
        }

        public WorkerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, Worker worker)
        {
            dbCommand.AddParameter("@FirstName", worker.FirstName);
            dbCommand.AddParameter("@LastName", worker.LastName);
            dbCommand.AddParameter("@Address", worker.Address);
            dbCommand.AddParameter("@PhoneNumber", worker.PhoneNumber);
            dbCommand.AddParameter("@Notes", worker.Notes);
            dbCommand.AddParameter("@ModifyTime", worker.ModifyTime);

        }

        public async Task<Worker> GetByPhoneNumber(string workerPhoneNumber)
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "PhoneNumber", "=", $"'{workerPhoneNumber}'", false));
            

            string queryCommand = this.databaseContext.Translate(query);

            Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);
            List<Worker> collection = await this.databaseContext.ExecuteReaderAsync<Worker>(command);

            if (collection.Count == 0)
            {
                return null;
            }

            return collection[0];
        }
    }
}