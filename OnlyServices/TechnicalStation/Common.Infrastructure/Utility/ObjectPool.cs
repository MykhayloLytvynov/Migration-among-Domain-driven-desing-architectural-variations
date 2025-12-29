using System.Collections.Concurrent;

namespace Common.Infrastructure.Utility
{
    public class ObjectPool<T> : IObjectPool where T : new()
    {
        //https://www.c-sharpcorner.com/article/object-pooling-in-net/

        /// <summary>
        /// The objects which are ready to use.
        /// </summary>
        private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();
        private int counter = 0;
        private int max = 10;

        public ObjectPool(int max)
        {
            this.max = max;
        }

        public void Release(object item)
        {
            if (counter < this.max)
            {
                items.Add((T)item);
                counter++;
            }
        }

        public object Get() 
        {
            T item;

            if (items.TryTake(out item))
            {
                counter--;
                return (T)item;
            }
            else
            {
                T obj = new T();
                //items.Add(obj);
                //counter++;
                return obj;
            }
        }
    }
}
