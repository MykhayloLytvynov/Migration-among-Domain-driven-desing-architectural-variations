using System;
using System.Collections.Generic;
using Common.Domain.Events;
using Common.Domain.Rules;

namespace Common.Domain.Entity
{
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;

    public abstract class EntityBase : IEntity
    {
        private readonly IDictionary<Type, ConcurrentQueue<IDomainEvent>> events = new ConcurrentDictionary<Type, ConcurrentQueue<IDomainEvent>>();

        protected object locker = new object();

        public int Id { get; set; }

        public IEnumerable<IDomainEvent> Events
        {
            get
            {
                List<IDomainEvent> result = new List<IDomainEvent>();

                foreach (var kvp in this.events)
                {
                    var queue = kvp.Value;

                    while (!queue.IsEmpty)
                    {
                        IDomainEvent element;
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
                }

                return result;
            }
        }

        [Conditional("DEBUG")]
        protected void Trace(string message)
        {
            Console.WriteLine(message);
        }

        protected void AddEvent(IDomainEvent domainEvent)
        {
            Type type = domainEvent.GetType();

            if (!this.events.ContainsKey(type))
            {
                this.events.Add(new KeyValuePair<Type, ConcurrentQueue<IDomainEvent>>(type, new ConcurrentQueue<IDomainEvent>()));
            }

            this.events[type].Enqueue(domainEvent);
            this.Trace($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}. {type.Name}.\r\n{domainEvent.GetTrace()}");
        }

        public void CheckRule(IRule rule)
        {
            if (rule.IsBroken())
            {
                throw new RuleValidationException(rule);
            }
        }

    }
}
