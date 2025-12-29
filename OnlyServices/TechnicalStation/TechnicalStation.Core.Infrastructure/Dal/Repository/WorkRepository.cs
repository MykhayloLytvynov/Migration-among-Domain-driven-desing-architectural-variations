using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Dal.Query;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Car;
using TechnicalStation.Core.Domain.Work;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class WorkRepository : RepositoryBase<Work>, IWorkRepository
    {
        public WorkRepository() : base()
        {
        }

        public WorkRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, Work work)
        {
            dbCommand.AddParameter("@OrderId", work.OrderId);
            dbCommand.AddParameter("@WorkerId", work.WorkerId);
            dbCommand.AddParameter("@StartDate", work.StartDate);
            dbCommand.AddParameter("@FinishDate", work.FinishDate);
            dbCommand.AddParameter("@Cost", work.Cost);
            dbCommand.AddParameter("@SupplyExpenses", work.SupplyExpenses);
            dbCommand.AddParameter("@WorkExpenses", work.WorkExpenses);
            dbCommand.AddParameter("@Description", work.Description);
            dbCommand.AddParameter("@Notes", work.Notes);
            dbCommand.AddParameter("@ModifyTime", work.ModifyTime);

        }

        public async Task<List<Work>> GetByOrderIdAsync(int orderId) 
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "OrderId", "=", $"{orderId}", false));

            string queryCommand = this.databaseContext.Translate(query);

            Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);

            List<Work> collection = await this.databaseContext.ExecuteReaderAsync<Work>(command);

            return collection;
        }

        public async Task<List<Work>> GetByWorkerIdAsync(int workerId)
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            query.ConditionCollection.Add(new DbQueryCondition(this.conceptName, "WorkerId", "=", $"{workerId}", false));

            string queryCommand = this.databaseContext.Translate(query);

            Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);

            List<Work> collection = await this.databaseContext.ExecuteReaderAsync<Work>(command);

            return collection;
        }

    }
}