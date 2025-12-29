using System.Threading.Tasks;
using Common.Application.Contract.Notification;
using Common.Domain.Events;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.Application.DomainEventHandlers.User
{
    public class PasswordChangedThenNotifyUserEventHandler : DomainEventHandlerBase<PasswordChanged>
    {
        private INotificationService notificationService;

        public PasswordChangedThenNotifyUserEventHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(PasswordChanged domainEvent)
        {
            NotificationInfo notificationInfo = new NotificationInfo()
            {
                NotificationType = (int)NotificationType.PasswordChanged,
                AttachedObject = domainEvent
            };

            await this.notificationService.NotifyUser(domainEvent.UserId, notificationInfo);
        }
    }
}
