using System;
using System.Collections.Generic;
using System.Data;
using Common.Application.Contract.Dal;

namespace Common.Application.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext databaseContext;

        private Dictionary<Type, object> repositoryCollection = new Dictionary<Type, object>();

        private IDbTransaction transaction;

        public UnitOfWork(IDatabaseContext databaseContext, Dictionary<Type, object> repositoryCollection)
        {
            this.databaseContext = databaseContext;
            this.repositoryCollection = repositoryCollection;
        }

        //public IDatabaseContext DatabaseContext => this.databaseContext;

        public IDbTransaction BeginTransaction()
        {
            if (this.transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }

            this.transaction = this.databaseContext.BeginTransaction();

            return this.transaction;
        }

        public void Commit()
        {
            this.databaseContext.SaveChanges();
        }

        public void Rollback()
        {
            this.databaseContext.RejectChanges();
        }

        public T GetRepository<T>()
        {
            Type type = typeof(T);
            return (T)this.repositoryCollection[type];
        }

        public void Dispose()
        {
            this.databaseContext.Dispose();
        }
    }
}
