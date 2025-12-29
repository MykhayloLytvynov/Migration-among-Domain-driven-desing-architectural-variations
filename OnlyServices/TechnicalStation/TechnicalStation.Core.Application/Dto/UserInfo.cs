namespace RemoteNotes.Core.Dto.Data
{
    public class UserInfo
    {
        private string login;

        public string Login
        {
            get { return this.login; }

            set { this.login = value; }
        }

        public int Id { get; set; }

        public UserInfo(int id, string login)
        {
            this.Id = id;
            this.login = login;
        }
    }
}
