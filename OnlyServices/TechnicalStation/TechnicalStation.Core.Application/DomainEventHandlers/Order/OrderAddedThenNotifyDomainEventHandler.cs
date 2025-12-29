using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Order;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Order
{
    public class OrderAddedThenNotifyDomainEventHandler : NotifyDomainEventHandler<OrderAddedDomainEvent>
    {
        public OrderAddedThenNotifyDomainEventHandler(INotificationService notificationService) : 
            base(notificationService, NotificationType.OrderAdded)
        {
        }
    }
}
