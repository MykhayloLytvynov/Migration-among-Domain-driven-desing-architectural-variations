using Common.Application.Contract.Notification;
using Newtonsoft.Json;

namespace TechnicalStation.Core.IntegrationTests.Extensions
{
    public static class Extensions
    {
        public static string ToText(this NotificationInfo notificationInfo)
        {
            string s = JsonConvert.SerializeObject(notificationInfo.AttachedObject);
            return $"Type: {notificationInfo.NotificationType} AttachedMessage: {notificationInfo.AttachedMessage} AttachedObject: {s}";
        }
    }
}
