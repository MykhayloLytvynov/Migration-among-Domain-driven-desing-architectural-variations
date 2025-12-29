using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Work;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Work
{
    public class WorkDeletedThenNotifyWorkEventHandler : NotifyDomainEventHandler<WorkDeletedDomainEvent>
    {
        public WorkDeletedThenNotifyWorkEventHandler(INotificationService notificationService) : 
            base(notificationService, NotificationType.WorkRemoved)
        {
        }
    }

}
