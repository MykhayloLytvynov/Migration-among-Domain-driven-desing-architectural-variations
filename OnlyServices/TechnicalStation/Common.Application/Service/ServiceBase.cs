using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Events.Integration;
using Common.Application.Contract.Service;
using Common.Application.Events.Integration;
using Common.Domain;
using Common.Domain.Events;

namespace Common.Application.Service
{
    public class ServiceBase<T> : IApplicationService<T> where T : Identifiable
    {
        protected IRepository<T> repository;
        private readonly IDictionary<Type, ConcurrentQueue<IIntegrationEvent>> events = 
            new ConcurrentDictionary<Type, ConcurrentQueue<IIntegrationEvent>>();


        public ServiceBase(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<T> GetAsync(int entityId)
        {
            return await repository.GetByIdAsync(entityId);
        }

        public virtual async Task<List<T>> GetCollectionAsync()
        {
            return await repository.GetCollectionAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await repository.AddAsync(entity);
            T result = await repository.GetByIdAsync(entity.Id);

            return result;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            await repository.UpdateAsync(entity);
            T result = await repository.GetByIdAsync(entity.Id);

            return result;
        }

        public virtual async Task RemoveAsync(int entityId)
        {
            await repository.DeleteAsync(entityId);
        }

        public IEnumerable<IIntegrationEvent> Events
        {
            get
            {
                foreach (var kvp in events)
                {
                    var queue = kvp.Value;

                    while (!queue.IsEmpty)
                    {
                        IIntegrationEvent element;
                        bool isOk = queue.TryPeek(out element);
                        if (isOk)
                        {
                            yield return element;
                            queue.TryDequeue(out element);
                        }
                        else
                        {
                            Thread.Sleep(20);
                        }
                    }
                }
            }
            set { }
        }

        [Conditional("DEBUG")]
        protected void Trace(string message)
        {
            Console.WriteLine(message);
        }

        //protected void AddEvent(IIntegrationEvent integrationEvent)
        //{
        //    Type type = integrationEvent.GetType();

        //    if (!events.ContainsKey(type))
        //    {
        //        events.Add(new KeyValuePair<Type, ConcurrentQueue<IIntegrationEvent>>(type, new ConcurrentQueue<IIntegrationEvent>()));
        //    }

        //    events[type].Enqueue(integrationEvent);
        //    Trace($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. {type.Name}.\r\n{integrationEvent.GetTrace()}");
        //}

        protected async Task PublishEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var integrationEvent in events)
            {
                await DomainEventDispatcher.Instance.DispatchAsync(integrationEvent);
            }
        }

        protected async Task PublishEvent(IDomainEvent integrationEvent)
        {
            await DomainEventDispatcher.Instance.DispatchAsync(integrationEvent);
        }
    }
}
