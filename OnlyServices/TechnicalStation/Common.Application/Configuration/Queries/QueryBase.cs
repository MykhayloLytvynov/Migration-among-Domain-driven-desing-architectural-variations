using System;

namespace Common.Application.Configuration.Queries
{
    public abstract class QueryBase<TResult> : IQuery<TResult>
    {
        public Guid Id { get; }

        public ConnectionInfo ConnectionInfo { get; }

        protected QueryBase(ConnectionInfo connectionInfo) : this(Guid.NewGuid(), connectionInfo)
        {
        }

        protected QueryBase(Guid id, ConnectionInfo connectionInfo)
        {
            Id = id;
            this.ConnectionInfo = connectionInfo;
        }
    }
}