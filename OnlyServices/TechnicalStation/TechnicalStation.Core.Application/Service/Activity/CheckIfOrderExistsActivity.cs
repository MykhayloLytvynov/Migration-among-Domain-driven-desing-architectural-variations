using Common.Application.Contract.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Application.Service.Activity
{
    public class CheckIfOrderExistsActivity : ICheckIfExistsActivity<Order>
    {
        private IOrderRepository orderRepository;

        public CheckIfOrderExistsActivity(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> Execute(int id, bool throwIfDoesNotExist = true)
        {
            Order existedEntity = await this.orderRepository.GetByIdAsync(id);

            if (existedEntity == null && throwIfDoesNotExist)
            {
                string message = $"Order with Id: {id} does not exist.";

                throw new DataException(message);
            }

            return existedEntity;
        }

        public Task<Order> Execute(Order entity, bool throwIfExists = true)
        {
            throw new NotImplementedException();
        }
    }
}
