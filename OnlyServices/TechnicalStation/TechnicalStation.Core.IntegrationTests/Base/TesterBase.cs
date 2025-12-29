using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Application.Contract.Service;
using Common.Domain;
using Common.Domain.Entity;
using Common.Testing.Utility.Extension;
using NUnit.Framework;
using TechnicalStation.Core.Application.Contract.Service;
using TechnicalStation.Core.Application.Service;
using TechnicalStation.Core.IntegrationTests.Context;

namespace TechnicalStation.Core.IntegrationTests.Base
{
    [TestFixture]
    public abstract class TesterBase<T, E> where T:IApplicationService<E>
                                           where E : IEntity
    {
        public readonly T service;

        public TesterBase()
        {
            service = TestingContext.GetService<T>();
        }

        [Test]
        public async Task GetCollectionBasicTest()
        {
            // Arrange
           // E entity = await this.AddBasic();

            // Act
            var result = await service.GetCollectionAsync();
            foreach (var _entity in result)
            {
                Console.WriteLine(_entity.Id.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 0);
        }

        [Test]
        public virtual async Task AddBasicTest()
        {
            E entity = await this.AddBasic();
        }

        public virtual async Task<E> AddBasic()
        {
            // Arrange
            E entity = this.BuildObject();

            return await this.AddBasic(entity);
        }

        public virtual async Task<E> AddBasic(E entity)
        {
                // Act
                entity = await this.service.AddAsync(entity);

                // Assert
                Assert.That(entity.Id > 0);

                this.CheckNotifications(1);

                return entity;
        }

        [Test]
        public virtual async Task GetBasicTest()
        {
            E entity = await this.AddBasic();

            E entityAfter = await this.service.GetAsync(entity.Id);

            Assert.That(entityAfter.Id > 0);

            entity.FieldValuesAreEqual(entityAfter, new List<string>() { "id" });
        }

        [Test]
        public virtual async Task UpdateBasicTest()
        {
            // Arrange
            E entity = await this.AddBasic();

            this.ModifyProperties(entity);
            // Act
            E entityAfter = await this.service.UpdateAsync(entity);

            entity.FieldValuesAreEqual(entityAfter);

            this.CheckNotifications(1); // Because dequeue removes notification
        }

        [Test]
        public virtual async Task DeleteBasicTest()
        {
            // Arrange
            E entity = await this.AddBasic();

            // Act
            await this.service.RemoveAsync(entity.Id);

            var exception = Assert.ThrowsAsync<Exception>(async () => await this.service.GetAsync(entity.Id));
            Assert.NotNull(exception);
        }

        [TearDown]
        public virtual async Task TearDown()
        {
            var result = await service.GetCollectionAsync();
            foreach (var entity in result)
            {
                this.service.RemoveAsync(entity.Id);
            }

            Thread.Sleep(50);
            TestingContext.ClearNotifications();
        }
        
        /// <summary>
        /// The modify properties.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected abstract void ModifyProperties(E entity);

        /// <summary>
        /// The build object.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public abstract E BuildObject();

        protected virtual void CheckNotifications(int number)
        {
            Thread.Sleep(50);

            var notificationCollection = TestingContext.GetNotifications();

            foreach (var notification in notificationCollection)
            {
                Console.WriteLine(notification);
            }

            Assert.That(notificationCollection.Count, Is.EqualTo(number));

        }
    }
}
