using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using TechnicalStation.Core.Domain.User;

namespace TechnicalStation.Core.Application.Contract.Dal
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByLoginAsync(string login);
    }
}
