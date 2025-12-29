namespace Common.Application.Contract.Dal
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
