using System.Threading.Tasks;
using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Worker
{
    public class WorkerUpdatedThenNotifyWorkerEventHandler : 
        NotifyDomainEventHandler<WorkerUpdatedDomainEvent>
    {
        public WorkerUpdatedThenNotifyWorkerEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.WorkerUpdated)
        {
        }
    }
}
