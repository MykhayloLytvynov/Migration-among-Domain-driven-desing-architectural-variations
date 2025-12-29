using System.Threading.Tasks;

namespace Common.Application.Contract.Notification
{
    /// <summary>
    /// Responsible for clients notification.
    /// </summary>
    public interface INotificationService
    {
        Task Notify(NotificationInfo notificationInfo);

        Task NotifyUser(int userId, NotificationInfo notificationInfo);

        Task JoinNotificationGroup(string groupName, int userId, string connectionId);

        Task LeaveNotificationGroup(string groupName, int id, string connectionId);
    }
}
