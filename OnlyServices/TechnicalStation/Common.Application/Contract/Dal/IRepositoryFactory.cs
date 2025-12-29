using System.Collections.Generic;
using System;

namespace Common.Application.Contract.Dal
{
    public interface IRepositoryFactory
    {
        T Create<T>() where T : IRepositoryBase;

        Dictionary<Type, object> CreateCollection(IDatabaseContext databaseContext);
    }
}
