using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public class RepositoryTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var fakeDbContext = A.Fake<IDbContext>();
                var repository = new Repository<DummyEntity>(fakeDbContext);

                repository.Should().NotBeNull();
                repository.Should().BeAssignableTo<IRepository<DummyEntity>>();
                repository.Should().BeOfType<Repository<DummyEntity>>();
            }

            internal class DummyEntity : GameEntity { }
        }
    }
}
