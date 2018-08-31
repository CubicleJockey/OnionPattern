using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;
using OnionPattern.TestUtils;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class UpdateGameTitleRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private UpdateGameTitleRequest request;

            [TestInitialize]
            public void TestInitailize()
            {
                InitializeFakes();
                request = new UpdateGameTitleRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromIUpdateGameTitleRequest()
            {
                request.Should().BeAssignableTo<IUpdateGameTitleRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequest()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Game>
        {
            private UpdateGameTitleRequest request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new UpdateGameTitleRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void InputIsNull()
            {
                var response = request.Execute(null);
                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo(ExceptionsUtility.ArgumentNull("input"));
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public void InvalidInputIdNotValid(int Id)
            {
                var invalidInput = new UpdateGameTitleInput { Id = Id, NewTitle = "Something" };
                var response = request.Execute(invalidInput);

                response.Should().NotBeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(Id)} must be 1 or greater.");
            }

            [DataTestMethod]
            [DataRow(default(string))]
            [DataRow("")]
            [DataRow("      ")]
            public void InvalidInputNameIsEmpty(string name)
            {
                var invalidInput = new UpdateGameTitleInput { Id = 666, NewTitle = name };
                var response = request.Execute(invalidInput);

                response.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(invalidInput.NewTitle)} cannot be empty.");
            }
        }
    }
}
