using System;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Entities;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;
using SerilogFakeItEasy;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class UpdateGameTitleRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            [TestInitialize]
            public void TestInitailize()
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
                var request = new UpdateGameTitleRequest(FakeRepository, FakeRepositoryAggregate);

                request.Should().NotBeNull();
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
                request.Should().BeAssignableTo<IUpdateGameTitleRequest>();
                request.Should().BeOfType<UpdateGameTitleRequest>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBase<Game>
        {
            private IUpdateGameTitleRequest request;
            private Expression<Action> UpdatingInfoLog;


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
                var response =  request.Execute(null);
                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"Value cannot be null.{Environment.NewLine}Parameter name: input");
            }

            [DataTestMethod]
            [DataRow(-1)]
            [DataRow(0)]
            public void InvalidInputIdNotValid(int Id)
            {
                var invalidInput = new UpdateGameTitleInputDto{ Id = Id, NewTitle = "Something" };
                var response =  request.Execute(invalidInput);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(Id)} must be 1 or greater.");
            }

            [DataTestMethod]
            [DataRow(default(string))]
            [DataRow("")]
            [DataRow("      ")]
            public void InvalidInputNameIsEmpty(string name)
            {
                var invalidInput = new UpdateGameTitleInputDto { Id = 666, NewTitle = name };
                var response = request.Execute(invalidInput);

                response.Should().NotBeNull();
                response.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorSummary.Should().BeEquivalentTo($"Input {nameof(invalidInput.NewTitle)} cannot be empty.");
            }
        }
    }
}
