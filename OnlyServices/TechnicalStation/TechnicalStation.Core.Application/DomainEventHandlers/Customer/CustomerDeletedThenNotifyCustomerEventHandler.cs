using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Customer;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Customer
{
    public class CustomerDeletedThenNotifyCustomerEventHandler : NotifyDomainEventHandler<CustomerDeletedDomainEvent>
    {
        public CustomerDeletedThenNotifyCustomerEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.CustomerRemoved)
        {
        }
    }
}
