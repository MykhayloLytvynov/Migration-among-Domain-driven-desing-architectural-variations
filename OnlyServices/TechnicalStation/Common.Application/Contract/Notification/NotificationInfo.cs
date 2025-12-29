using System;

namespace Common.Application.Contract.Notification
{
    [Serializable]
    public class NotificationInfo
    {
        public int NotificationType { get; set; }

        public string AttachedMessage { get; set; }

        public object AttachedObject { get; set; }

        //public string GetTrace()
        //{
        //    //string s = new JavaScriptSerializer().SerializeObject(AttachedObject);
        //    return $"Type: {NotificationType} AttachedMessage: {AttachedMessage} AttachedObject: {AttachedObject.ToString()}";
        //}
    }
}
