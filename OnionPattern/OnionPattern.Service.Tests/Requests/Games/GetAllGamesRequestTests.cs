using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Service.Requests.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class GetAllGamesRequestTests
    {

        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private GetAllGamesRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new GetAllGamesRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void InheritsFromIGetAllGameRequest()
            {
                request.Should().BeAssignableTo<IGetAllGamesRequest>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequests()
            {
                request.Should().BeAssignableTo<BaseServiceRequest<Game>>();
            }
        }

        [TestClass]
        public class MethodTests : TestBase<Game>
        {
            private GetAllGamesRequest request;
            private Expression<Func<IEnumerable<Game>>> getAll;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new GetAllGamesRequest(FakeRepository, FakeRepositoryAggregate);
                getAll = () => FakeRepository.GetAll();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
                getAll = null;
            }

            [TestMethod]
            public void Execute()
            {
                var games = MockData.Mocks.GenerateGames().ToArray();

                A.CallTo(getAll).Returns(games);

                request.Should().NotBeNull();

                var response = request.Execute();
                response.Should().NotBeNull();
                response.Should().BeOfType<GameListResponse>();

                response.Games.Should().NotBeNullOrEmpty();
                response.ErrorResponse.Should().BeNull();

                response.Games.Count().Should().Be(games.Length);

                A.CallTo(getAll).MustHaveHappenedOnceExactly();
            }

            [TestMethod]
            public void ExecuteErrorThrown()
            {
                const string EXPECTEDMESSAGE = "Oh noes n' stuff.";
                var exception = new Exception(EXPECTEDMESSAGE);

                A.CallTo(getAll).Throws(exception);

                var response = request.Execute();

                response.Should().NotBeNull();
                response.Games.Should().BeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().NotBeNullOrWhiteSpace();
                response.ErrorResponse.ErrorSummary.Should().Be(EXPECTEDMESSAGE);

                A.CallTo(getAll).MustHaveHappenedOnceExactly();
            }
        }
    }
}
