namespace Common.Application.Contract.Dal
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Create();
    }
}
