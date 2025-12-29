using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Worker
{
    public class WorkerAddedThenNotifyWorkerEventHandler : NotifyDomainEventHandler<WorkerAddedDomainEvent>
    {
        public WorkerAddedThenNotifyWorkerEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.WorkerAdded)
        {
        }
    }
}
