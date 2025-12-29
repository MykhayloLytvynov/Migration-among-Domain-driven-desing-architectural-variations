using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalStation.Core.Domain.User
{
    public class User : Identifiable
    {
        private int id;
        private string login;
        private string password;
        private int memberId;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
    }
}
