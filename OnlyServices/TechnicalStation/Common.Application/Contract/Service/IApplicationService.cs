using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Application.Contract.Service
{
    public interface IApplicationService<T>
    {
        Task<T> GetAsync(int entityId);

        Task<List<T>> GetCollectionAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(int entityId);
    }
}
