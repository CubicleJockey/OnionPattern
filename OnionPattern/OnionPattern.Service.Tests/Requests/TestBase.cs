using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain;
using OnionPattern.Domain.Repository;
using System;
using System.Linq;

namespace OnionPattern.Service.Tests.Requests
{
    public abstract class TestBase<TEntity> where TEntity : VideoGameEntity
    {
        protected IRepository<TEntity> FakeRepository;
        protected IRepositoryAggregate FakeRepositoryAggregate;

        protected void InitializeFakes()
        {
            FakeRepository = A.Fake<IRepository<TEntity>>();
            FakeRepositoryAggregate = A.Fake<IRepositoryAggregate>();
        }

        protected void ClearFakes()
        {
            Fake.ClearConfiguration(FakeRepository);
            Fake.ClearConfiguration(FakeRepositoryAggregate);
        }

        protected void TestConstructor<T>(IRepository<FakeEntity> repository, IRepositoryAggregate repositoryAggregate)
        {
            var propertyName = repository == null ? nameof(repository) : nameof(repositoryAggregate);

            try
            {
                void Ctor() => A.Fake<T>(c => c.WithArgumentsForConstructor(new object[] { repository, repositoryAggregate }));

                //Trigger Construction
                Ctor();
            }
            catch (FakeCreationException fce)
            {
                var messageParts = TestUtils.ExceptionMessages.ArgumentNull(propertyName).Split(Environment.NewLine);

                var foundPart1 = fce.Message.Contains(messageParts.First());
                foundPart1.Should().BeTrue();


                var foundPart2 = fce.Message.Contains(messageParts.Last());
                foundPart2.Should().BeTrue();

                return;
            }
            Assert.Fail($"Should have thrown exception with message containing: [{TestUtils.ExceptionMessages.ArgumentNull(propertyName)}]");
        }
    }
}
