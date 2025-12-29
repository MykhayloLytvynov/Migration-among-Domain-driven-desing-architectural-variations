using System;
using System.Data;

namespace Common.Application.Contract.Dal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Application.Contract.Dal.Query;

    public interface IDatabaseContext : IDisposable
    {
        void SaveChanges();

        void RejectChanges();

        IDbTransaction BeginTransaction();

        IDbCommand GetCommand(string commandText);

        Task ExecuteCommandAsync(IDbCommand command);

        Task<List<T>> ExecuteReaderAsync<T>(IDbCommand command);

        object GetValue(IDbCommand sqlCommand, string parameterName);

        string Translate(DbSelectQuery query);

        string Translate(DbDeleteQuery query);
    }
}
