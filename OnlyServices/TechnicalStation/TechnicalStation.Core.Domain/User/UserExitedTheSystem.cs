using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.User
{
    public class UserExitedTheSystem : DomainEventBase
    {
        private readonly string ip;

        private readonly string connectionId;

        private readonly int userid;

        public UserExitedTheSystem(string ip, string connectionId, int userid)
        {
            this.ip = ip;
            this.connectionId = connectionId;
            this.userid = userid;
        }

        public string Ip => ip;

        public string ConnectionId => connectionId;

        public int UserId => userid;
    }
}
