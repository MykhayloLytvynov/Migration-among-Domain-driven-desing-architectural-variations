using System;

namespace Common.Application.Configuration.Commands
{
    public abstract class InternalCommandBase : CommandBase
    {
        protected InternalCommandBase(ConnectionInfo connectionInfo) : base(connectionInfo)
        {
        }
    }

    //public abstract class InternalCommandBase<TResult> : ICommand<TResult>
    //{
    //    protected InternalCommandBase()
    //    {
    //        Id = Guid.NewGuid();
    //    }

    //    protected InternalCommandBase(Guid id)
    //    {
    //        Id = id;
    //    }

    //    public Guid Id { get; }
    //}
}