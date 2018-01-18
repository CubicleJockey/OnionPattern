using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform.Async;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class GetPlatformByIdRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Entities.Platform>
        {
            [TestInitialize]
            public void TestInitalize()
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
                var request = new GetPlatformByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Entities.Platform>>();
                request.Should().BeAssignableTo<IGetPlatformByIdRequestAsync>();
                request.Should().BeOfType<GetPlatformByIdRequestAsync>();
            }
        }
    }
}
