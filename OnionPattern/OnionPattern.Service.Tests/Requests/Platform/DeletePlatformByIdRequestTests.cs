using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class DeletePlatformByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private DeletePlatformByIdRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new DeletePlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIDeletePlatformByIdRequest()
            {
                request.Should().BeAssignableTo<IDeletePlatformByIdRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Platform.Entities.Platform>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Domain.Platform.Entities.Platform>
        {
            private IDeletePlatformByIdRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new DeletePlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public void IdIsInvalid(int id)
            {
                var response = request.Execute(id);

                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo($"{nameof(id)} must be 1 or greater.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.Should().Be(500);
            }
        }
    }
}
