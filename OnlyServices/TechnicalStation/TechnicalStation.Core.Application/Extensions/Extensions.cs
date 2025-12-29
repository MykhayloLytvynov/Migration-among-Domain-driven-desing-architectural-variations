namespace TechnicalStation.Core.Application.Extensions
{
    public static class Extensions
    {
        public static string ToGroupId(this int id)
        {
            //return string.Concat(prefix, id.ToString(ServiceContext.GroupNumberOfDigits));
            return id.ToString("00000000");
        }

        public static string ToGroupId(this int id, string groupName)
        {
            return string.Concat(groupName, id.ToGroupId());
        }
    }
}
