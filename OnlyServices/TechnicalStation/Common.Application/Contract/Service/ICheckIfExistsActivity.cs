using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Contract.Service
{
    using System.Data;

    public interface ICheckIfExistsActivity<T>
    {
        /// <summary>
        /// Checks if the entity already exists and if not throws <see cref="DataException"/> by default
        /// </summary>
        /// <param name="id"></param>
        /// <param name="throwIfDoesNotExist"></param>
        /// <returns></returns>
        Task<T> Execute(int id, bool throwIfDoesNotExist = true);

        /// <summary>
        /// Checks if the entity already exists using the fields which identifies the entity, and if so, by default, throws <see cref="DataException"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="throwIfExists"></param>
        /// <returns></returns>
        Task<T> Execute(T entity, bool throwIfExists = true);
    }
}
