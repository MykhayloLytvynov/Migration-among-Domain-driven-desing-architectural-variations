using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Dal;
using Common.Application.Dal.Extensions;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.Infrastructure.Dal.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public async Task<User> GetUserByLoginAsync(string login)
        {
            try
            {
                string queryCommand = "GetUserByLogin";
                List<User> collection =
                    await DoQueryAsync<User>(queryCommand, new Dictionary<string, object>() { { "Login", login } });

                if (collection.Count > 0)
                {
                    return collection[0];
                }
                else
                {
                    string message = $"The user with login: {login} is not found.";
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void AddInputParameterCollection(IDbCommand dbCommand, User user)
        {
            dbCommand.AddParameter("@Login", user.Login);
            dbCommand.AddParameter("@Password", user.Password);
            dbCommand.AddParameter("@MemberId", user.MemberId);
        }

        public UserRepository() : base()
        {
        }

        public UserRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
