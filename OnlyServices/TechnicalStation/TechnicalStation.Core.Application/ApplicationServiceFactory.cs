using System;
using System.Collections.Generic;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Notification;
using Common.Application.Contract.Service;
using TechnicalStation.Core.Application.Contract.Dal;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.DomainEventHandlers;
using TechnicalStation.Core.Application.Service;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.Core.Application
{
    public class ApplicationServiceFactory : IApplicationServiceFactory
    {
        readonly Dictionary<Type, Func<object>> collection = new Dictionary<Type, Func<object>>();
        private readonly IRepositoryFactory repositoryFactory;

        private EventHandlersSubscriptionConfigurator eventHandlersConfigurator;

        private object locker = new object();

        public ApplicationServiceFactory(IRepositoryFactory repositoryFactory, INotificationService notificationService)
        {
            this.repositoryFactory = repositoryFactory;

            //https://github.com/m20was/Vehicle-Service-Station-JAVA
            //IUnitOfWork unitOfWork = unitOfWorkFactory.Create();
            // Extension point of the factory

            this.collection.Add(typeof(ICarService), () => new CarService(repositoryFactory.Create<ICarRepository>(), 
                repositoryFactory.Create<ICustomerRepository>()));

            this.collection.Add(typeof(ICustomerService), () => new CustomerService(repositoryFactory.Create<ICustomerRepository>()));
            
            this.collection.Add(typeof(IOrderService), () => new OrderService(repositoryFactory.Create<IOrderRepository>(),
                repositoryFactory.Create<ICarRepository>()));
            
            this.collection.Add(typeof(IWorkService), () => new WorkService(repositoryFactory.Create<IWorkRepository>(), 
                repositoryFactory.Create<IOrderRepository>(), 
                repositoryFactory.Create<IWorkerRepository>()));
            
            
            this.collection.Add(typeof(IWorkerService), () => new WorkerService(repositoryFactory.Create<IWorkerRepository>()));

            this.ConfigureHandlers(notificationService);
        }

        public void ConfigureHandlers(INotificationService notificationService)
        {
            if (this.eventHandlersConfigurator == null)
            {
                lock (locker)
                {
                    eventHandlersConfigurator = new EventHandlersSubscriptionConfigurator();
                    eventHandlersConfigurator.Configure(notificationService);
                }
            }
        }

        public T Create<T>() 
        {
            Type type = typeof(T);

            if (!this.collection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing.");
            }

            return (T)this.collection[type]();
        }


    }
}
