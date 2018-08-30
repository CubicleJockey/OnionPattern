using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Platform.Requests;
using OnionPattern.Domain.Services.Requests.Platform.Async;
using OnionPattern.Service.Requests.Platform.Async;
using OnionPattern.TestUtils;
using System.Threading.Tasks;

namespace OnionPattern.Service.Tests.Requests.Platform.Async
{
    public class UpdatePlatformNameRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Domain.Platform.Entities.Platform>
        {
            private UpdatePlatformNameRequestAsync request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new UpdatePlatformNameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIUpdatePlatformNameRequestAsync()
            {
                request.Should().BeAssignableTo<IUpdatePlatformNameRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Domain.Platform.Entities.Platform>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBaseAsync<Domain.Platform.Entities.Platform>
        {
            private IUpdatePlatformNameRequestAsync request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new UpdatePlatformNameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public async Task InputIsNull()
            {
                var response = await request.ExecuteAsync(null);

                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo(ExceptionMessages.ArgumentNull("input"));
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public async Task InvalidInputIdNotValid(int Id)
            {
                var invalidInput = new UpdatePlatformNameInput { Id = Id, NewName = "Something" };
                var response = await request.ExecuteAsync(invalidInput);

                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(Id)} must be 1 or greater.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }

            [DataTestMethod]
            [DataRow(default(string))]
            [DataRow("")]
            [DataRow("      ")]
            public async Task InvalidInputNameIsEmpty(string name)
            {
                var invalidInput = new UpdatePlatformNameInput { Id = 666, NewName = name };
                var response = await request.ExecuteAsync(invalidInput);

                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo("Input NewName cannot be empty.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }
        }
    }
}
