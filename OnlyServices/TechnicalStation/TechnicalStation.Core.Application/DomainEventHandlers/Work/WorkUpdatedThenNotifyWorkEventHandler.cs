using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Work;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Work
{
    public class WorkUpdatedThenNotifyWorkEventHandler : NotifyDomainEventHandler<WorkUpdatedDomainEvent>
    {
        public WorkUpdatedThenNotifyWorkEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.WorkUpdated)
        {
        }
    }
}
