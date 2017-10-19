using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Tests.Requests;
using OnionPattern.Service.Tests.Requests.Mocks;
using System;

namespace OnionPattern.Service.Tests
{
    public class BaseRequestAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<FakeEntity>
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
            public void RepositoryIsNull()
            {
                Action ctor = () => new MockBaseRequestAggregate(null, FakeRepositoryAggregate);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repository cannot be null.");
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequestAggregate(FakeRepository, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: repositoryAggregate cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var requestAggregate = new MockBaseRequestAggregate(FakeRepository, FakeRepositoryAggregate);

                requestAggregate.Should().NotBeNull();
                requestAggregate.Should().BeAssignableTo<BaseRequestAggregate<FakeEntity>>();
                requestAggregate.Should().BeOfType<MockBaseRequestAggregate>();
            }
        }
    }
}
