using System;
using System.Collections.Generic;
using Common.Application.Contract.Dal;
using Common.Infrastructure.Utility;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Infrastructure.Dal.Repository;

namespace TechnicalStation.Core.Infrastructure.Dal
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IDatabaseContextFactory databaseContextFactory;

        private Dictionary<Type, object> repositoryCollection = new Dictionary<Type, object>();

        public RepositoryFactory(IDatabaseContextFactory databaseContextFactory)
        {
            this.databaseContextFactory = databaseContextFactory;

            this.ConfigureRepositoryCollection();
        }

        protected void ConfigureRepositoryCollection()
        {
            this.repositoryCollection.Add(typeof(IUserRepository), new UserRepository(databaseContextFactory.Create()));
            this.repositoryCollection.Add(typeof(ICustomerRepository), new CustomerRepository(databaseContextFactory.Create()));
            this.repositoryCollection.Add(typeof(ICarRepository), new CarRepository(databaseContextFactory.Create()));
            this.repositoryCollection.Add(typeof(IWorkRepository), new WorkRepository(databaseContextFactory.Create()));
            this.repositoryCollection.Add(typeof(IWorkerRepository), new WorkerRepository(databaseContextFactory.Create()));
            this.repositoryCollection.Add(typeof(IOrderRepository), new OrderRepository(databaseContextFactory.Create()));
        }

        public T Create<T>() where T : IRepositoryBase
        {
            Type type = typeof(T);
            T repository = (T)((IRepositoryBase)this.repositoryCollection[type]).Clone();
            repository.DatabaseContext = this.databaseContextFactory.Create();
            return repository;
        }

        public Dictionary<Type, object> CreateCollection(IDatabaseContext databaseContext)
        {
            Dictionary<Type, object> result = new Dictionary<Type, object>();

            foreach (var kvp in this.repositoryCollection)
            {
                Type type = kvp.Key;
                object repository = ((IRepositoryBase)kvp.Value).Clone();
                ((IRepositoryBase)repository).DatabaseContext = databaseContext;
                this.repositoryCollection.Add(type, repository);
            }

            return this.repositoryCollection;
        }
    }


    public class PoolOrientedRepositoryFactory : IRepositoryFactory
    {
        private IDatabaseContextFactory databaseContextFactory;

        private Dictionary<Type, IObjectPool> poolCollection = new Dictionary<Type, IObjectPool>();

        private IRepositoryFactory repositoryFactoryImplementation;

        public PoolOrientedRepositoryFactory(IDatabaseContextFactory databaseContextFactory)
        {
            this.databaseContextFactory = databaseContextFactory;

            this.ConfigureRepositoryCollection();
        }

        protected void ConfigureRepositoryCollection()
        {
            // Extension point
            // this.repositoryCollection.Add(typeof(IUserRepository), new UserRepository(this.databaseContextFactory.Create()));
            this.poolCollection.Add(typeof(IUserRepository), new ObjectPool<UserRepository>(100));
        }

        /// <summary>
        /// Used by UoW logic
        /// </summary>
        /// <returns></returns>
        public Dictionary<Type, object> CreateCollection(IDatabaseContext databaseContext)
        {
            Dictionary<Type, object> repositoryCollection = new Dictionary<Type, object>();

            foreach (var kvp in this.poolCollection)
            {
                Type type = kvp.Key;
                object repository = kvp.Value;
                ((IRepositoryBase)repository).DatabaseContext = databaseContext;
                repositoryCollection.Add(type, repository);
            }

            return repositoryCollection;
        }

        public T Create<T>() where T : IRepositoryBase
        {
            Type type = typeof(T);
            T repository = (T)this.poolCollection[type].Get();
            repository.DatabaseContext = this.databaseContextFactory.Create();
            return repository;
        }

        public void Return<T>(T repository) where T : IRepositoryBase
        {
            Type type = typeof(T);
            repository.DatabaseContext = null;
            this.poolCollection[type].Release(repository);
            repository.DatabaseContext = this.databaseContextFactory.Create();
        }

    }
}
