using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Car
{
    public class CarUpdatedThenNotifyCarEventHandler : NotifyDomainEventHandler<CarUpdatedDomainEvent>
    {
        public CarUpdatedThenNotifyCarEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.CarUpdated)
        {
        }
    }
}
