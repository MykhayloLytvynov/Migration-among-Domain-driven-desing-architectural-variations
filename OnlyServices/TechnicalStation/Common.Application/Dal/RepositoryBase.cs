using Common.Application.Dal.Extensions;
using Common.Application.Extensions;

namespace Common.Application.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Threading.Tasks;
    using Common.Application.Contract.Dal;
    using Common.Application.Contract.Dal.Query;
    using Common.Domain;

    /// <summary>
    /// The dal manager base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, Identifiable
    {
        protected IDatabaseContext databaseContext;

        /// <summary>
        /// The concept name.
        /// </summary>
        protected string conceptName;

        public RepositoryBase()
        {
            this.conceptName = typeof(T).Name;
        }

        public RepositoryBase(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            this.conceptName = typeof(T).Name ;
        }

        public IDatabaseContext DatabaseContext
        {
            get => this.databaseContext;
            set => this.databaseContext = value;
        }

        protected virtual async Task<T> GetAsync(int id)
        {
            string query = string.Format("Get{0}ById", this.conceptName);

            IDbCommand command = this.databaseContext.GetCommand(query);
            command.CommandType = CommandType.StoredProcedure;
            command.AddParameter("Id", id);

            List<T> collection = await this.databaseContext.ExecuteReaderAsync<T>(command);

            if (collection.Count == 0)
            {
                string nameOfType = typeof(T).Name;
                string message = string.Format($"Element {id} of type {nameOfType} is not found");
                throw new Exception(message);
            }
            else
            {
                return collection[0];
            }
        }
        
        public virtual async Task<T> GetByIdAsync(int id)
        {
            T element = IdentityMap.Instance.GetItem<T>(id);

            if (element == null)
            {
                element = await this.GetAsync(id);
                IdentityMap.Instance.AddOrUpdateItem(id, element);
            }

            return element;
        }

        public virtual async Task AddAsync(T element)
        {
            // Define the procedure.
            string procedureName = string.Format("Add{0}", this.conceptName);
            IDbCommand sqlCommand = this.databaseContext.GetCommand(procedureName);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Set the parameters.
            this.AddInputParameterCollection(sqlCommand, element);

            sqlCommand.AddParameter( @"Id", 4, ParameterDirection.Output);

            // Execute procedure.
            await this.databaseContext.ExecuteCommandAsync(sqlCommand);

            // The result is id of the object just added.
            int id = Convert.ToInt32(this.databaseContext.GetValue(sqlCommand, "@Id"));

            // Set the object's unique identifier.
            element.Id = id;
        }

        protected abstract void AddInputParameterCollection(IDbCommand sqlCommand, T element);

        public async Task DeleteAsync(int id)
        {
            IdentityMap.Instance.RemoveItem<T>(id);

            // Define the procedure.
            string commandText = string.Format("Delete{0}", this.conceptName);
            IDbCommand sqlCommand = this.databaseContext.GetCommand(commandText);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Define the parameters.
            sqlCommand.AddParameter(@"Id", id);

            // Execute the procedure.
            await this.databaseContext.ExecuteCommandAsync(sqlCommand);
        }

        /// <summary>
        /// The get collection.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public async Task<List<T>> GetCollectionAsync()
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName);
            
            string queryCommand = this.databaseContext.Translate(query);
            //Console.WriteLine(queryCommand);

            IDbCommand command = this.databaseContext.GetCommand(queryCommand);
            return await this.databaseContext.ExecuteReaderAsync<T>(command); //this.DoQuery(queryCommand);
        }

        public async Task ClearAsync()
        {
            DbDeleteQuery dbDeleteQuery = new DbDeleteQuery(this.conceptName);
            string commandText = this.databaseContext.Translate(dbDeleteQuery);
            IDbCommand sqlCommand = this.databaseContext.GetCommand(commandText);
            
            await this.databaseContext.ExecuteCommandAsync(sqlCommand);
        }

        /// <summary>The get collection.</summary>
        /// <param name="topNumber">The top number.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public async Task<List<T>> GetCollectionAsync(int topNumber)
        {
            DbSelectQuery query = new DbSelectQuery(this.conceptName, topNumber);
            string queryCommand = this.databaseContext.Translate(query);
            IDbCommand command = this.databaseContext.GetCommand(queryCommand);
            return await this.databaseContext.ExecuteReaderAsync<T>(command);
        }
        
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        public virtual async Task UpdateAsync(T element)
        {
            // Define the procedure.
            string queryCommand = string.Format("Update{0}", this.conceptName);
            IDbCommand sqlCommand = this.databaseContext.GetCommand(queryCommand);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            // Set the parameters.
            sqlCommand.AddParameter(@"Id", element.Id);
            this.AddInputParameterCollection(sqlCommand, element);

            // Execute the procedure.
            await this.databaseContext.ExecuteCommandAsync(sqlCommand);
        }

        protected async Task<List<T>> DoQueryAsync<T>(string query, Dictionary<string, object> parameterCollection)
        {
            try
            {
                List<T> collection = new List<T>();

                IDbCommand command = this.databaseContext.GetCommand(query);
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> kvp in parameterCollection)
                {
                    command.AddParameter(kvp.Key, kvp.Value);
                }

                return await this.databaseContext.ExecuteReaderAsync<T>(command);
            }
            catch (Exception ex)
            {
                string message = $"Do query failed. Query:{query}";
                throw new Exception(message, ex);
            }
        }

        public object Clone()
        {
            return this.CopyObject();
        }
    }
}
