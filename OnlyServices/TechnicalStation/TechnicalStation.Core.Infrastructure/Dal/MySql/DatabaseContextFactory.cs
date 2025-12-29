using System.Collections.Generic;
using Common.Application.Contract.Dal;
using RemoteNotes.DAL.MySql;

namespace TechnicalStation.Core.Infrastructure.Dal.MySql
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private string connectionString;

        public DatabaseContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDatabaseContext Create()
        {
            var databaseContext = new DatabaseContext(this.connectionString);
            databaseContext.SetExceptionsToTranslate(new List<string>(){"car", "customer", "order", "work", "worker"});
            return databaseContext;
        }
    }
}
