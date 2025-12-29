namespace Common.Application.Configuration
{
    public class ConnectionInfo
    {
        private string ip;

        private string connectionId;

        public ConnectionInfo(string ip, string connectionId)
        {
            this.ip = ip;
            this.connectionId = connectionId;
        }

        public string Ip => ip;

        public string ConnectionId => connectionId;

        public string GetTrace()
        {
            return $"{Ip}> [Connection:{ConnectionId}]";
        }
    }
}
