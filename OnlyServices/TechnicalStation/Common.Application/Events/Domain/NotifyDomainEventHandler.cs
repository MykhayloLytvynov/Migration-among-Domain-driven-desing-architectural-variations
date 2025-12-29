using Common.Application.Contract.Notification;
using Common.Domain.Events;
using System.Threading.Tasks;

namespace Common.Application.Events.Domain
{
    public class NotifyDomainEventHandlerBase<TEvent> : 
                                    DomainEventHandlerBase<TEvent> where TEvent : class, IDomainEvent
    {
        protected INotificationService notificationService;
        protected int notificationType;

        public NotifyDomainEventHandlerBase(INotificationService notificationService, int notificationType)
        {
            this.notificationService = notificationService;
            this.notificationType = notificationType;
        }

        public override async Task HandleAsync(TEvent domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = notificationType,
                AttachedObject = domainEvent
            };

            await this.notificationService.Notify(notificationInfo);
        }
    }
}
