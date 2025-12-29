using System.Threading;
using System.Threading.Tasks;

namespace Common.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand request);
    }

    public interface ICommandHandler<in TCommand, TResult> 
    {
        Task<TResult> Handle(TCommand request);
    }
}