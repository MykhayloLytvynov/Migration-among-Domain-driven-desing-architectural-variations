using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Common.Application.Contract.Notification;
using TechnicalStation.Core.Application.Extensions;
using TechnicalStation.Core.IntegrationTests.Extensions;

namespace TechnicalStation.Core.IntegrationTests
{
    public class NotificationService : INotificationService
    {
        public ConcurrentQueue<string> NotificationCollection = new ConcurrentQueue<string>();

        public async Task Notify(NotificationInfo notificationInfo)
        {
            await Task.Run(() =>
            {
                    this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. All users will be notified " + notificationInfo.ToText());
                });

        }

        public async Task NotifyUser(int userId, NotificationInfo notificationInfo)
        {
            await Task.Run(() =>
                {
                    this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. UserId: {userId} will be notified " + notificationInfo.ToText());
                });
        }

        public async Task JoinNotificationGroup(string groupName, int userId, string connectionId)
        {
            await Task.Run(() =>
                {
                    this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. Connection:{connectionId} joins the group: {userId.ToGroupId(groupName)}");
                });
        }

        public async Task LeaveNotificationGroup(string groupName, int id, string connectionId)
        {
            await Task.Run(() =>
                {
                    this.NotificationCollection.Enqueue($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. Connection:{connectionId} leaves the group: {id.ToGroupId(groupName)}");
                });
        }
    }
}
