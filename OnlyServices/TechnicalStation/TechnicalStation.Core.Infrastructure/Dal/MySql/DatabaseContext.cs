using System;
using System.Data;
using System.Linq;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Dal.Query;
using Common.Application.Dal.Extensions;
using MySql.Data.MySqlClient;

namespace RemoteNotes.DAL.MySql
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    // https://codereview.stackexchange.com/questions/144784/unit-of-work-uow-pattern-with-ado-net
    public class DatabaseContext : IDatabaseContext
    {
        private IDbConnection connection;
        private IDbTransaction transaction;

        private string connectionString;
        private List<string> exceptionsToTranslate = new List<string>() ;

        public void SetExceptionsToTranslate(List<string> exceptionsToTranslate)
        {
            this.exceptionsToTranslate = exceptionsToTranslate;
        }

        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbCommand CreateCommand()
        {
            this.CheckConnection();
            this.CheckTransaction();

            var command = connection.CreateCommand();
            command.Transaction = transaction;
            return command;
        }

        public void AddCommand(IDbCommand command)
        {
            this.CheckConnection();
            this.CheckTransaction();

            command.Connection = connection;
            command.Transaction = transaction;
        }

        private void CheckConnection()
        {
            if (this.connection == null)
            {
                this.OpenConnection();
            }
        }

        private void CheckTransaction()
        {
            if (this.transaction == null)
            {
                this.StartTransaction();
            }
        }

        private void OpenConnection()
        {
           
            connection = new MySqlConnection(this.connectionString);
            connection.Open();
        }

        private void StartTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void SaveChanges()
        {
            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction have already been already been commited. Check your transaction handling.");
            }

            transaction.Commit();
            transaction = null;
        }

        public void RejectChanges()
        {
            transaction.Rollback();
            transaction = null;
        }

        public IDbTransaction BeginTransaction()
        {
            if (this.transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }

            this.transaction = this.connection.BeginTransaction();

            return this.transaction;
        }

        public IDbCommand GetCommand(string commandText)
        {
            return new MySqlCommand(commandText);
        }

        public async Task ExecuteCommandAsync(IDbCommand command)
        {
            try
            {
                if (this.transaction == null)
                {
                    using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                    {
                        connection.Open();
                        command.Connection = connection;
                        int numberOfRows = await((MySqlCommand)command).ExecuteNonQueryAsync();
                    }
                }
                else
                {
                    this.AddCommand(command);
                    await((MySqlCommand)command).ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(IDbCommand command)
        {
            //Console.WriteLine(this.connectionString);
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                command.Connection = connection;
                using (var reader = await((MySqlCommand)command).ExecuteReaderAsync())
                {
                    return reader.Select(r => this.Process<T>(r)).ToList();
                }
            }
        }

        protected virtual List<T> ProcessRead<T>(IDataReader reader)
        {
            List<T> collection = new List<T>();

            while (reader.Read())
            {
                T element = this.Process<T>(reader);
                collection.Add((T)element);
            }

            return collection;
        }

        protected virtual T Process<T>(IDataReader reader)
        {
            Type type = typeof(T);
            PropertyInfo[] p = type.GetProperties();
            T element = (T)Activator.CreateInstance(type);

            foreach (PropertyInfo pi in p)
            {
                try
                {
                    if (reader[pi.Name.ToLower()] != System.DBNull.Value)
                    {
                        pi.SetValue(element, reader[pi.Name], null);
                    }
                }
                catch (System.IndexOutOfRangeException) { }
            }

            return element;
        }

        public object GetValue(IDbCommand dbCommand, string parameterName)
        {
            return ((MySqlCommand)dbCommand).Parameters[parameterName].Value;
        }

        public string Translate(DbSelectQuery query)
        {
            string conceptName = query.FromCollection[0].ToLower();

            string queryCommand = string.Format("select * from `{0}s`", query.FromCollection[0]);
            if (exceptionsToTranslate.Contains(conceptName))
            {
                queryCommand = string.Format("select * from `{0}`", query.FromCollection[0]);
            }

            if (query.ConditionCollection.Count > 0)
            {
                queryCommand += " where ";
                int i = 1;
                foreach (var dbQueryCondition in query.ConditionCollection)
                {
                    string condition = $" `{dbQueryCondition.TableName}`.`{dbQueryCondition.FieldName}` {dbQueryCondition.Relation} {dbQueryCondition.Value} ";
                    
                    if (i != query.ConditionCollection.Count) // means not last
                    {
                        string conjunction = dbQueryCondition.And ? "AND" : "OR";
                        condition = $"({condition}) {conjunction} ";
                        
                    }

                    queryCommand += condition;

                    i++;
                }
            }

            return queryCommand;
        }

        public string Translate(DbDeleteQuery query)
        {
            string queryCommand = string.Format("delete from `{0}s`", query.From);
            return queryCommand;
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction = null;
            }

            if (this.connection != null)
            {
                this.connection.Close();
                this.connection = null;
            }
        }
    }
}
