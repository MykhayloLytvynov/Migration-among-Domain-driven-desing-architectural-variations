using System;

namespace Common.Application.Configuration.Commands
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }
        public ConnectionInfo ConnectionInfo { get; }

        public CommandBase(ConnectionInfo connectionInfo) 
        {            
            Id = Guid.NewGuid();
            ConnectionInfo = connectionInfo;
        }
    }

    //public abstract class CommandBase<TResult> : ICommand<TResult>
    //{
    //    public ConnectionInfo ConnectionInfo { get; }

    //    protected CommandBase(ConnectionInfo connectionInfo) : this(Guid.NewGuid(), connectionInfo)
    //    {
    //    }

    //    protected CommandBase(Guid id, ConnectionInfo connectionInfo)
    //    {
    //        Id = id;
    //        ConnectionInfo = connectionInfo;
    //    }

    //    public Guid Id { get; }
    //}
}