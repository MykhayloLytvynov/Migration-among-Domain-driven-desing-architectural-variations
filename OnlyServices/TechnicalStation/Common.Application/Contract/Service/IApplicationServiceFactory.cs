using Common.Application.Contract.Notification;

namespace Common.Application.Contract.Service
{
    public interface IApplicationServiceFactory
    {
        void ConfigureHandlers(INotificationService notificationService);

        T Create<T>();
    }
}
