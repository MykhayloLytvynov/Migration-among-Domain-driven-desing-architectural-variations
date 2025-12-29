using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Common.Application.Contract.Dal
{
    public interface ISqlDataManager
    {
        IDbCommand GetCommand(string commandText);
        
        /// <summary>
        /// The get data table.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        Task<List<T>> GetCollectionAsync<T>(string tableName);

        Task<List<T>> DoQueryAsync<T>(string query);

        Task<List<T>> DoQueryAsync<T>(string query, Dictionary<string, object> parameterCollection);

        void AddParameter(IDbCommand sqlCommand, string parameterName, object value, ParameterDirection direction = ParameterDirection.Input);

        object GetValue(IDbCommand sqlCommand, string parameterName);

        Task<T> GetByIdAsync<T>(string queryCommand, int id);

        Task ExecuteCommandAsync(IDbCommand sqlCommand);
    }
}