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
            public void Inheritence()
            {
                var requestAsyncAggregate = new PlatformRequestAsyncAggregate(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                requestAsyncAggregate.Should().NotBeNull();
                requestAsyncAggregate.Should().BeAssignableTo<BaseRequestAsyncAggregate<Domain.Platform.Entities.Platform>>();
                requestAsyncAggregate.Should().BeAssignableTo<IPlatformRequestAsyncAggregate>();
                requestAsyncAggregate.Should().BeOfType<PlatformRequestAsyncAggregate>();
            }
        }
    }
}
