using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.DataAccess.EF.Repository;
using OnionPattern.Domain.Repository;

namespace OnionPattern.DataAccess.EF.Tests.Repository
{
    public class RespositoryAsyncTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private DbContext fakeDbContext;
            private RepositoryAsync<DummyEntity> repository;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeDbContext = A.Fake<DbContext>();
                repository = new RepositoryAsync<DummyEntity>(fakeDbContext);
            }

            [TestMethod]
            public void ContextIsNull()
            {
                Action ctor = () => new Repository<DummyEntity>(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: context");
            }

            [TestMethod]
            public void ShouldInheritFromIRepository()
            {
                repository.Should().BeAssignableTo<IRepositoryAsync<DummyEntity>>();
            }

            [TestMethod]
            public void ShouldBeOfTypeRepository()
            {
                repository.Should().BeOfType<RepositoryAsync<DummyEntity>>();
            }
        }
    }
}
