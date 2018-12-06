using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Repository;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public class RepositoryAsyncAggregateTests
    {
        [TestClass]
        public class ConstructorTests : BaseRepositoryTest
        {
            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void DbContextIsNull()
            {
                Action ctor = () => new RepositoryAsyncAggregate(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.NullArgument("dbContext"));
            }

            [TestMethod]
            public void InheritsFromIRepositoryAggregate()
            {
                var repositoryAggregate = new RepositoryAsyncAggregate(FakeDbContext);

                repositoryAggregate.Should().BeAssignableTo<IRepositoryAsyncAggregate>();
            }
        }

        [TestClass]
        public class PropertiesTests : BaseRepositoryTest
        {
            private RepositoryAsyncAggregate repositoryAsyncAggregate;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                repositoryAsyncAggregate = new RepositoryAsyncAggregate(FakeDbContext);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                repositoryAsyncAggregate = null;
            }

            [TestMethod]
            public void GamesIsNotNull()
            {
                repositoryAsyncAggregate.Games.Should().NotBeNull();
            }

            [TestMethod]
            public void PlatformsIsNotNull()
            {
                repositoryAsyncAggregate.Platforms.Should().NotBeNull();
            }

            [TestMethod]
            public void GamePlatformsIsNotNull()
            {
                repositoryAsyncAggregate.GamePlatforms.Should().NotBeNull();
            }

        }
    }
}
