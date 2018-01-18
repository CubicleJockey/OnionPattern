using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Services.Requests.Platform;
using OnionPattern.Service.Requests.Platform;

namespace OnionPattern.Service.Tests.Requests.Platform
{
    public class DeletePlatformByIdRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Domain.Entities.Platform>
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
                var request = new DeletePlatformByIdRequest(FakeRepository, FakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequest<Domain.Entities.Platform>>();
                request.Should().BeAssignableTo<IDeletePlatformByIdRequest>();
                request.Should().BeOfType<DeletePlatformByIdRequest>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Domain.Entities.Platform>
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
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"{nameof(id)} must be 1 or greater.");
                response.StatusCode.HasValue.Should().BeTrue();
                response.StatusCode.ShouldBeEquivalentTo(500);
            }
        }
    }
}
