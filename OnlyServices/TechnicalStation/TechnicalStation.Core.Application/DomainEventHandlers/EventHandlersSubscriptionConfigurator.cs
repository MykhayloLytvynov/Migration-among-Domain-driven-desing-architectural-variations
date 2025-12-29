using Common.Application.Contract.Notification;
using Common.Domain.Events;
using TechnicalStation.Core.Application.DomainEventHandlers.Car;
using TechnicalStation.Core.Application.DomainEventHandlers.Customer;
using TechnicalStation.Core.Application.DomainEventHandlers.Order;
using TechnicalStation.Core.Application.DomainEventHandlers.User;
using TechnicalStation.Core.Application.DomainEventHandlers.Work;
using TechnicalStation.Core.Application.DomainEventHandlers.Worker;

namespace TechnicalStation.Core.Application.DomainEventHandlers
{
    public class EventHandlersSubscriptionConfigurator
    {
        public void Configure(INotificationService notificationService)
        {
            DomainEventDispatcher.Instance.Subscribe(new CarAddedThenNotifyCarEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new CarUpdatedThenNotifyCarEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new CarDeletedThenNotifyCarEventHandler(notificationService));

            DomainEventDispatcher.Instance.Subscribe(new CustomerAddedThenNotifyCustomerEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new CustomerUpdatedThenNotifyCustomerEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new CustomerDeletedThenNotifyCustomerEventHandler(notificationService));

            DomainEventDispatcher.Instance.Subscribe(new OrderAddedThenNotifyDomainEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new OrderUpdatedThenNotifyDomainEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new OrderDeletedThenNotifyDomainEventHandler(notificationService));

            DomainEventDispatcher.Instance.Subscribe(new WorkDeletedThenNotifyWorkEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new WorkUpdatedThenNotifyWorkEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new WorkAddedThenNotifyWorkEventHandler(notificationService));

            DomainEventDispatcher.Instance.Subscribe(new WorkerDeletedThenNotifyWorkerEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new WorkerUpdatedThenNotifyWorkerEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new WorkerAddedThenNotifyWorkerEventHandler(notificationService));

            DomainEventDispatcher.Instance.Subscribe(new PasswordChangedThenNotifyUserEventHandler(notificationService));
            DomainEventDispatcher.Instance.Subscribe(new UserEnteredTheSystemThenSubscribeUserToNotificationsHandler(notificationService));
        }
    }
}
