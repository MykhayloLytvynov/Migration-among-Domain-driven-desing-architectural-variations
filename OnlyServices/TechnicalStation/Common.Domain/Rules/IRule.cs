namespace Common.Domain.Rules
{
    public interface IRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
