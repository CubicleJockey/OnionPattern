using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Tests.Requests;
using OnionPattern.Service.Tests.Requests.Mocks;

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
                TestConstructor<BaseRequestAggregate<FakeEntity>>(null, FakeRepositoryAggregate);
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                TestConstructor<BaseRequestAggregate<FakeEntity>>(FakeRepository, null);
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
