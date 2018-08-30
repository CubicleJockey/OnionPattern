using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform.Async;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class GetPlatformByIdRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Platform.Entities.Platform>
        {
            private GetPlatformByIdRequestAsync request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new GetPlatformByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIGetPlatformByIdRequestAsync()
            {
                request.Should().BeAssignableTo<IGetPlatformByIdRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Platform.Entities.Platform>>();
            }
        }
    }
}
