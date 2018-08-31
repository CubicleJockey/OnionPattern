using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.Mapping;
using OnionPattern.Service.Requests.Game.Async;
using OnionPattern.TestUtils;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionPattern.Service.Tests.Requests.Games.Async
{
    public class CreateGameRequestAsyncTests
    {
        [TestClass]
        public class ConstructorTests : TestBaseAsync<Game>
        {
            private CreateGameRequestAsync request;

            [TestInitialize]
            public void TestInitalize()
            {
                InitializeFakes();
                request = new CreateGameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromICreateGameRequestAsync()
            {
                request.Should().BeAssignableTo<ICreateGameRequestAsync>();
            }

            [TestMethod]
            public void InheritsFromBaseServiceRequestAsync()
            {
                request.Should().BeAssignableTo<BaseServiceRequestAsync<Game>>();
            }
        }

        [TestClass]
        public class MethodsTests : TestBaseAsync<Game>
        {
            private CreateGameRequestAsync request;
            private Expression<Func<Task<Game>>> createGame;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                MappingProfileInitilizer.ConfigureMappings();
                request = new CreateGameRequestAsync(FakeRepositoryAsync, FakeRepositoryAsyncAggregate);
                createGame = () => FakeRepositoryAsync.CreateAsync(A<Game>.Ignored);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public async Task ExecuteAsync()
            {
                var expectedGame = new Game
                {
                    Id = 42,
                    Price = 1.99m,
                    ReleaseDate = DateTime.Now,
                    Name = "Blaster Master",
                    Genre = "Platformer"

                };

                A.CallTo(createGame).Returns(expectedGame);

                var response = await request.ExecuteAsync(A.Dummy<CreateGameInput>());

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
                response.Game.Should().Be(expectedGame);
                response.ErrorResponse.Should().BeNull();

                A.CallTo(createGame).MustHaveHappenedOnceExactly();
            }

            [TestMethod]
            public async Task ExecuteAsyncExeptionIsThrown()
            {
                A.CallTo(createGame).Throws(new Exception(ExceptionMessages.GenericMessage));

                var response = await request.ExecuteAsync(A.Dummy<CreateGameInput>());

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(500);
                response.Game.Should().BeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().Be(ExceptionMessages.GenericMessage);
                response.ErrorResponse.InnerException.Should().BeNull();

                A.CallTo(createGame).MustHaveHappenedOnceExactly();
            }
        }
    }
}

