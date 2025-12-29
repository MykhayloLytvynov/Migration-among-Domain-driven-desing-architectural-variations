using System;
using System.Threading.Tasks;
using Common.Application.Service;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service.Activity;
using TechnicalStation.Core.Domain.Customer;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Application.Service
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        private IOrderRepository orderRepository;
        private CheckIfCarExistsActivity checkIfCarExistsActivity;

        public OrderService(IOrderRepository orderRepository, ICarRepository carRepository) : base(orderRepository)
        {
            this.orderRepository = orderRepository;
            this.checkIfCarExistsActivity = new CheckIfCarExistsActivity(carRepository);
        }

        public override async Task<Order> AddAsync(Order order)
        {
            await this.CheckReferences(order);

            order = await base.AddAsync(order);

            var domainEvent = new OrderAddedDomainEvent(order.Id, order.CustomerId, order.CarId, order.StartDate,
                order.FinishDate, order.ModifyTime);
            
            await PublishEvent(domainEvent);
            Order result = await orderRepository.GetByIdAsync(order.Id);

            return result;
        }

        public override async Task<Order> UpdateAsync(Order order)
        {
            await this.CheckReferences(order);

            Order oldValuesOrder = await orderRepository.GetByIdAsync(order.Id);

            Order newValuesOrder = await base.UpdateAsync(order);

            var domainEvent = new OrderUpdatedDomainEvent(order.Id, order.CustomerId, oldValuesOrder.CustomerId, newValuesOrder.CarId,
                oldValuesOrder.CarId, newValuesOrder.StartDate, oldValuesOrder.StartDate,
                newValuesOrder.FinishDate, oldValuesOrder.FinishDate, newValuesOrder.ModifyTime);
            
            await PublishEvent(domainEvent);

            return newValuesOrder;
        }

        public override async Task RemoveAsync(int orderId)
        {
            Order orderToRemove = await orderRepository.GetByIdAsync(orderId);
            var domainEvent = new OrderDeletedDomainEvent(orderToRemove.Id, orderToRemove.CustomerId, orderToRemove.CarId);

            await orderRepository.DeleteAsync(orderId);

            await PublishEvent(domainEvent);
        }

        protected async Task CheckReferences(Order order)
        {
            var car = await this.checkIfCarExistsActivity.Execute(order.CarId);

            if (order.CustomerId != car.CustomerId)
            {
                throw new Exception($"Car Id: {car.Id} does not belong to Customer: {order.CustomerId} but to Customer: {car.CustomerId}");
            }
        }
    }
}
