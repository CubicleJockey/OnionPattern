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
            [TestMethod]
            public void ContextIsNull()
            {
                Action ctor = () => new RepositoryAsync<DummyEntity>(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: context");
            }

            [TestMethod]
            public void Inheritence()
            {
                var fakeDbContext = A.Fake<DbContext>();
                var repository = new RepositoryAsync<DummyEntity>(fakeDbContext);

                repository.Should().NotBeNull();
                repository.Should().BeAssignableTo<IRepositoryAsync<DummyEntity>>();
                repository.Should().BeOfType<RepositoryAsync<DummyEntity>>();
            }
        }
    }
}
