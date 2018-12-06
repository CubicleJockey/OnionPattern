using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Repository;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public class RepositoryAggregateTests
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
                Action ctor = () => new RepositoryAggregate(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.NullArgument("dbContext"));
            }

            [TestMethod]
            public void InheritsFromIRepositoryAggregate()
            {
                var repositoryAggregate = new RepositoryAggregate(FakeDbContext);

                repositoryAggregate.Should().BeAssignableTo<IRepositoryAggregate>();
            }
        }

        [TestClass]
        public class PropertiesTests : BaseRepositoryTest
        {
            private RepositoryAggregate repositoryAggregate;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                repositoryAggregate = new RepositoryAggregate(FakeDbContext);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                repositoryAggregate = null;
            }

            [TestMethod]
            public void GamesIsNotNull()
            {
                repositoryAggregate.Games.Should().NotBeNull();
            }

            [TestMethod]
            public void PlatformsIsNotNull()
            {
                repositoryAggregate.Platforms.Should().NotBeNull();
            }

            [TestMethod]
            public void GamePlatformsIsNotNull()
            {
                repositoryAggregate.GamePlatforms.Should().NotBeNull();
            }

        }
    }
}
