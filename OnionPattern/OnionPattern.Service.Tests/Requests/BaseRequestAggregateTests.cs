using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                TestConstructor<BaseServiceRequest<FakeEntity>>(null, FakeRepositoryAggregate);
            }

            [TestMethod]
            public void RepositoryAggregateIsNull()
            {
                TestConstructor<BaseServiceRequest<FakeEntity>>(FakeRepository, null);
            }

            [TestMethod]
            public void IsValid()
            {
                var baseRequest = A.Fake<BaseServiceRequest<FakeEntity>>();

                baseRequest.Should().BeAssignableTo<BaseServiceRequest<FakeEntity>>();
            }
        }
    }
}
