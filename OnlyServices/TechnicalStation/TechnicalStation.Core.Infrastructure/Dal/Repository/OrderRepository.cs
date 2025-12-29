using System.Data;
using Common.Application.Contract.Dal;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository() : base()
        {
        }

        public OrderRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, Order order)
        {
            dbCommand.AddParameter("@CustomerId", order.CustomerId);
            dbCommand.AddParameter("@CarId", order.CarId);
            dbCommand.AddParameter("@StartDate", order.StartDate);
            dbCommand.AddParameter("@FinishDate", order.FinishDate);
            dbCommand.AddParameter("@ModifyTime", order.ModifyTime);

        }

    }
}