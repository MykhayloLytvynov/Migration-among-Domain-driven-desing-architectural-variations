using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.DomainEventHandlers.Base;
using TechnicalStation.Core.Application.Notification;
using TechnicalStation.Core.Domain.Car;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Car
{
    public class CarAddedThenNotifyCarEventHandler : NotifyDomainEventHandler<CarAddedDomainEvent>
    {
        public CarAddedThenNotifyCarEventHandler(INotificationService notificationService) :
            base(notificationService, NotificationType.CarAdded)
        {
        }
    }
}
