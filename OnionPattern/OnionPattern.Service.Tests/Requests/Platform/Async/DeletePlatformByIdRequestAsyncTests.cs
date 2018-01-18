using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform.Async;
using System.Threading.Tasks;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class DeletePlatformByIdRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Entities.Platform>
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
                var request = new DeletePlatformByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Entities.Platform>>();
                request.Should().BeAssignableTo<IDeletePlatformByIdRequestAsync>();
                request.Should().BeOfType<DeletePlatformByIdRequestAsync>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBaseAsync<Domain.Entities.Platform>
        {
            private IDeletePlatformByIdRequestAsync request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new DeletePlatformByIdRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public async Task IdIsInvalid(int id)
            {
                var response = await request.ExecuteAsync(id);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"{nameof(id)} must be 1 or greater.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.ShouldBeEquivalentTo(500);
            }
        }
    }
}
