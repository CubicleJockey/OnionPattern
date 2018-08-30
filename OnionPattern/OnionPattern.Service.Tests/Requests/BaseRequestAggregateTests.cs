using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Service.Tests.Requests.Mocks;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Service.Tests.Requests
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
                Action ctor = () => new MockBaseRequest(null, FakeRepositoryAggregate);
                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionMessages.ArgumentNull("repository"));
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                Action ctor = () => new MockBaseRequest(FakeRepository, null);
                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionMessages.ArgumentNull("repositoryAggregate"));
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = new MockBaseRequest(FakeRepository, FakeRepositoryAggregate);

                baseRequest.Should().NotBeNull();
                baseRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity>>();
                baseRequest.Should().BeOfType<MockBaseRequest>();
            }
        }
    }
}
