using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform.Async;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class GetAllPlatformsRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Platform.Entities.Platform>
        {
            private GetAllPlatformsRequestAsync request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new GetAllPlatformsRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIGetAllPlatformsRequestAsync()
            {
                request.Should().BeAssignableTo<IGetAllPlatformsRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Platform.Entities.Platform>>();
            }
        }
    }
}
