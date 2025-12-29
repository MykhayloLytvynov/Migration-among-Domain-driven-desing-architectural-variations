using Common.Domain.Events;

namespace TechnicalStation.Core.Domain.User
{
    public class PasswordChanged : DomainEventBase
    {
        private int userId;

        private string oldPassword;

        private string newPassword;

        public PasswordChanged(int userId, string oldPassword, string newPassword)
        {
            this.userId = userId;
            this.oldPassword = oldPassword;
            this.newPassword = newPassword;
        }

        public string OldPassword => oldPassword;

        public string NewPassword => newPassword;

        public int UserId => userId;
    }
}
