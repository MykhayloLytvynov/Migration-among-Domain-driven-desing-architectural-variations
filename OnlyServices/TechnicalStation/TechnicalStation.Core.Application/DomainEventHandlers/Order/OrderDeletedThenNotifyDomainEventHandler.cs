using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Order
{
    public class OrderDeletedThenNotifyDomainEventHandler : NotifyDomainEventHandler<OrderDeletedDomainEvent> //DomainEventHandlerBase<OrderDeleted>
    {
        public OrderDeletedThenNotifyDomainEventHandler(INotificationService notificationService) : 
            base(notificationService, NotificationType.OrderRemoved)
        {
        }
    }
}
