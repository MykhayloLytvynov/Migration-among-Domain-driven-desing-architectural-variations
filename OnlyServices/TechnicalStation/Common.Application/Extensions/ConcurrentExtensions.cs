using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Common.Application.Extensions
{
    public static class ConcurrentExtensions
    {
        public static List<T> GetItems<T>(this ConcurrentQueue<T> queue) 
        {
            List<T> result = new List<T>();

            while (!queue.IsEmpty)
            {
                T element;
                bool isOk = queue.TryDequeue(out element);
                if (isOk)
                {
                    result.Add(element);
                }
                else
                {
                    Thread.Sleep(20);
                }
            }

            return result;
        }

        public static T GetItem<T>(this ConcurrentBag<T> bag) where T: class
        {
            bool isOk = false;
            T element = null;
            while (!isOk && !bag.IsEmpty)
            {
                isOk = bag.TryTake(out element);
                if (!isOk)
                {
                    Thread.Sleep(20);                   
                }
            }

            return element;
        }
    }
}
