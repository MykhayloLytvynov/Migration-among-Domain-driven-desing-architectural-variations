using System;
using System.Collections.Generic;
using System.Text;
using Common.Application.Contract.Notification;
using Common.Application.Events.Domain;
using Common.Domain.Events;
using TechnicalStation.Core.Application.Notification;

namespace TechnicalStation.Core.Application.DomainEventHandlers.Base
{
    public class NotifyDomainEventHandler<TEvent> : NotifyDomainEventHandlerBase<TEvent> where TEvent : class, IDomainEvent
    {
        public NotifyDomainEventHandler(INotificationService notificationService, NotificationType notificationType) : base(notificationService, (int)notificationType)
        {
        }
    }
}
