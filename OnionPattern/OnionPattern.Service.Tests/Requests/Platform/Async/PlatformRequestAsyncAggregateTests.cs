using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests;
using OnionPattern.Service.Requests.Platform.Async;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class PlatformRequestAsyncAggregateTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Platform.Entities.Platform>
        {
            private PlatformRequestAsyncAggregate requestAggregate;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                requestAggregate = new PlatformRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                requestAggregate = null;
            }

            [TestMethod]
            public void InheritsFromIPlatformRequestAsyncAggregate()
            {
                requestAggregate.Should().BeAssignableTo<IPlatformRequestAsyncAggregate>();
            }

            [TestMethod]
            public void InheritsFromBaseRequestAsyncAggregate()
            {
                requestAggregate.Should().BeAssignableTo<BaseRequestAsyncAggregate<Domain.Platform.Entities.Platform>>();
            }
        }
    }
}
