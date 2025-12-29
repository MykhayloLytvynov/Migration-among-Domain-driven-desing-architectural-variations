using System;
using Common.Application.Dal.Extensions;

namespace Common.Application.Dal
{
    using System.Collections.Concurrent;

    public class IdentityMap
    {
        private ConcurrentDictionary<Type, ConcurrentDictionary<int, object>> typePool = 
            new ConcurrentDictionary<Type, ConcurrentDictionary<int, object>>();

        private static readonly Lazy<IdentityMap> lazy = new Lazy<IdentityMap>(() => new IdentityMap());

        public static IdentityMap Instance  => lazy.Value;

        public void AddOrUpdateItem<T>(Int32 pID, T value) where T : class
        {
            Type type = typeof(T);
            ConcurrentDictionary<Int32, Object> collection;

            collection = this.typePool.GetOrAdd(type, new ConcurrentDictionary<int, object>());
            collection.AddOrUpdate(pID, value);
            return;
        }

        public bool RemoveItem<T>(Int32 pID) where T : class
        {
            Type type = typeof(T);

            if (!this.typePool.ContainsKey(type))
                return false;

            if (!this.typePool[type].ContainsKey(pID))
                return false;

            return this.typePool[type].TryRemove(pID);
        }

        public T GetItem<T>(Int32 pID) where T : class
        {
            try
            {
                return (T)this.typePool[typeof(T)][pID];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
