using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Responses;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Service.Requests.Game.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionPattern.Service.Tests.Requests.Games.Async
{
    public class GetAllGamesRequestAsyncTests
    {

        [TestClass]
        public class ConstructorTests : TestBaseAsync<Game>
        {
            private GetAllGamesRequestAsync request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new GetAllGamesRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
            }

            [TestMethod]
            public void InheritsFromIGetAllGamesRequestAsync()
            {
                request.Should().BeAssignableTo<IGetAllGamesRequestAsync>();
            }

            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Game>>();
            }
        }

        [TestClass]
        public class MethodTests : TestBaseAsync<Game>
        {
            private GetAllGamesRequestAsync request;
            private Expression<Func<Task<IEnumerable<Game>>>> getAll;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new GetAllGamesRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
                getAll = () => FakeRepositoryAsync.GetAllAsync();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
                getAll = null;
            }

            [TestMethod]
            public async Task Execute()
            {
                var games = MockData.Mocks.GenerateGames().ToArray();

                A.CallTo(getAll).Returns(games);

                var response = await request.ExecuteAsync();

                response.Should().NotBeNull();
                response.Should().BeOfType<GameListResponse>();

                response.Games.Should().NotBeNullOrEmpty();
                response.ErrorResponse.Should().BeNull();

                response.Games.Count().Should().Be(games.Length);

                A.CallTo(getAll).MustHaveHappenedOnceExactly();
            }

            [TestMethod]
            public async Task ExecuteErrorThrown()
            {
                const string EXPECTEDMESSAGE = "Oh noes n' stuff.";
                var exception = new Exception(EXPECTEDMESSAGE);

                A.CallTo(getAll).Throws(exception);

                var response = await request.ExecuteAsync();

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
