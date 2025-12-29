namespace Common.Infrastructure.Utility
{
    public interface IObjectPool
    {
        object Get();

        void Release(object element);
    }
}
