using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Application.Contract.Dal
{
    using System;
    using Common.Domain;

    public interface IRepository<T> : IRepositoryBase where T : Identifiable
    {


        Task<T> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task AddAsync(T element);

        Task UpdateAsync(T element);

        Task ClearAsync();

        Task<List<T>> GetCollectionAsync();

        Task<List<T>> GetCollectionAsync(int topNumber);

        //Task<List<T>> DoQueryAsync<T>(string query, Dictionary<string, object> parameterCollection);

    }
}
