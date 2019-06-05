using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain;
using OnionPattern.Domain.Repository;
using Serilog;
using System;
using System.Linq;

namespace OnionPattern.Service.Tests.Requests
{
    public abstract class TestBaseAsync<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepositoryAsync<TEntity> FakeRepositoryAsync;
        protected IRepositoryAsyncAggregate FakeRepositoryAsyncAggregate;
        protected ILogger FakeLogger;

        //TODO: Look into moving the Fake Initialization into a static constructor
        //TODO: so this happens automatically for all the tests.
        protected void InitializeFakes()
        {
            FakeRepositoryAsync = A.Fake<IRepositoryAsync<TEntity>>();
            FakeRepositoryAsyncAggregate = A.Fake<IRepositoryAsyncAggregate>();
            FakeLogger = A.Fake<ILogger>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeRepositoryAsync);
            Fake.ClearConfiguration(FakeRepositoryAsyncAggregate);
            Fake.ClearConfiguration(FakeLogger);
        }

        protected void TestConstructor<T>(IRepositoryAsync<FakeEntity> repositoryAsync, IRepositoryAsyncAggregate repositoryAsyncAggregate) where T : class
        {
            var propertyName = repositoryAsync == null ? nameof(repositoryAsync) : nameof(repositoryAsyncAggregate);

            try
            {
                void Ctor() => A.Fake<T>(c => c.WithArgumentsForConstructor(new object[] { repositoryAsync, repositoryAsyncAggregate }));

                //Trigger Construction
                Ctor();
            }
            catch (FakeCreationException fce)
            {
                var messageParts = TestUtils.ExceptionsUtility.NullArgument(propertyName).Split(Environment.NewLine);

                var foundPart1 = fce.Message.Contains(messageParts.First());
                foundPart1.Should().BeTrue();


                var foundPart2 = fce.Message.Contains(messageParts.Last());
                foundPart2.Should().BeTrue();

                return;
            }
            Assert.Fail($"Should have thrown exception with message containing: [{TestUtils.ExceptionsUtility.NullArgument(propertyName)}]");
        }
    }
}