using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Repository;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public class RepositoryTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private DbContext fakeDbContext;
            private Repository<DummyEntity> repository;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeDbContext = A.Fake<DbContext>();
                repository = new Repository<DummyEntity>(fakeDbContext);
            }

            [TestMethod]
            public void ContextIsNull()
            {
                Action ctor = () => new Repository<DummyEntity>(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.NullArgument("context"));
            }

            [TestMethod]
            public void ShouldInheritFromIRepository()
            {
                repository.Should().BeAssignableTo<IRepository<DummyEntity>>();
            }

            [TestMethod]
            public void ShouldBeOfTypeRepository()
            {
                repository.Should().BeOfType<Repository<DummyEntity>>();
            }
        }
    }
}
