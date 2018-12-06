using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Platform;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class PlatFormRequestAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private PlatformRequestAggregate requestAggregate;

            [TestInitialize]
            public void TestInitailize()
            {
                InitializeFakes();
                requestAggregate = new PlatformRequestAggregate(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                requestAggregate = null;
            }

            [TestMethod]
            public void InheritsFromIPlatformRequestAggregate()
            {
                requestAggregate.Should().BeAssignableTo<IPlatformRequestAggregate>();
            }

            [TestMethod]
            public void InheritsFromBaseRequestAggregate()
            {
                requestAggregate.Should().BeAssignableTo<BaseRequestAggregate<Domain.Platform.Entities.Platform>>();
            }
        }
    }
}
