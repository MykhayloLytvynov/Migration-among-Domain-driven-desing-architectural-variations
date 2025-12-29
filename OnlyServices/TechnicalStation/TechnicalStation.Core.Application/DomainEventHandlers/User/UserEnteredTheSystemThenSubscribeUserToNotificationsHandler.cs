using System.Threading.Tasks;
using Common.Application.Contract.Notification;
using Common.Domain.Events;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.Application.DomainEventHandlers.User
{
    public class UserEnteredTheSystemThenSubscribeUserToNotificationsHandler : DomainEventHandlerBase<UserEnteredTheSystem>
    {
        private INotificationService notificationService;

        public UserEnteredTheSystemThenSubscribeUserToNotificationsHandler(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public override async Task HandleAsync(UserEnteredTheSystem domainEvent)
        {
            int userId = domainEvent.UserId;
            
            await this.notificationService.JoinNotificationGroup("u", userId, domainEvent.ConnectionId);
        }
    }
}
