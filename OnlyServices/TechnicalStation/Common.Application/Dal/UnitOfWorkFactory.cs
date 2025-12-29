using System;
using System.Collections.Generic;
using Common.Application.Contract.Dal;

namespace Common.Application.Dal
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private IDatabaseContextFactory databaseContextFactory;

        private IRepositoryFactory repositoryFactory;

        public UnitOfWorkFactory(IDatabaseContextFactory databaseContextFactory, IRepositoryFactory repositoryFactory)
        {
            this.databaseContextFactory = databaseContextFactory;
            this.repositoryFactory = repositoryFactory;
        }

        public IUnitOfWork Create()
        {
            IDatabaseContext databaseContext = this.databaseContextFactory.Create();
            Dictionary<Type, object> repositoryCollection = this.repositoryFactory.CreateCollection(databaseContext);

            return new UnitOfWork(databaseContext, repositoryCollection);
        }
    }
}
