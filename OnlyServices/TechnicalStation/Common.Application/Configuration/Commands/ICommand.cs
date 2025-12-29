using System;

namespace Common.Application.Configuration.Commands
{
    public interface ICommand<out TResult>
    {
        Guid Id { get; }

        ConnectionInfo ConnectionInfo { get; }
    }

    public interface ICommand
    {
        Guid Id { get; }

        ConnectionInfo ConnectionInfo { get; }
    }
}