using System;
using System.Collections.Generic;
using Common.Application.Contract.Dal;
using Common.Application.Contract.Service;
using Common.Application.Dal;
using Common.Application.Extensions;
using RemoteNotes.DAL.MySql;
using TechnicalStation.Core.Application;
using TechnicalStation.Core.Infrastructure.Dal;
using TechnicalStation.Core.Infrastructure.Dal.MySql;

namespace TechnicalStation.Core.IntegrationTests.Context
{
    public class TestingContext
        {
            /// <summary>
            /// The dal manager factory.
            /// </summary>
            private static IApplicationServiceFactory applicationServiceFactory;

            private static NotificationService notificationService;

            static TestingContext()
            {

                string connectionString =
                    ConnectionStringReader.GetConnectionString(databaseName: "ts", xmlFilePath: "Configuration/connectionStrings.config");
               
               // Console.WriteLine($"ConnectionString:{connectionString}");

                IDatabaseContextFactory databaseContextFactory = new DatabaseContextFactory(connectionString);
                IRepositoryFactory repositoryFactory = new RepositoryFactory(databaseContextFactory);
                notificationService = new NotificationService();
                applicationServiceFactory = new ApplicationServiceFactory(repositoryFactory, notificationService);
                
                //applicationServiceFactory.ConfigureHandlers(notificationService);
               
            }

            /// <summary>
            /// The get dal manager factory.
            /// </summary>
            /// <returns>
            /// The <see cref="IDalManagerFactory"/>.
            /// </returns>
            public static T GetService<T>() //where T: IApplicationService<K>
            {
                return applicationServiceFactory.Create<T>();
            }

            public static List<string> GetNotifications()
            {
                List<string> result = notificationService.NotificationCollection.GetItems();
            
                return result;
            }

            public static void ClearNotifications()
            {
                notificationService.NotificationCollection.Clear();
            }
    }

}
