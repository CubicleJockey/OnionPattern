using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Entities;
using OnionPattern.Domain.Game.Requests;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.Mapping;
using OnionPattern.Service.Requests.Game;
using OnionPattern.TestUtils;
using System;
using System.Linq.Expressions;

namespace OnionPattern.Service.Tests.Requests.Games
{
    public class CreateGameRequestTests
    {
        [TestClass]
        public class ConstructorTests : TestBase<Game>
        {
            private CreateGameRequest request;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                request = new CreateGameRequest(FakeRepository, FakeRepositoryAggregate);
            }

            [TestCleanup]
            public void Cleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void InheritsFromICreateGameRequest()
            {
                request.Should().BeAssignableTo<ICreateGameRequest>();
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
            private CreateGameRequest request;
            private Expression<Func<Game>> createGame;

            [TestInitialize]
            public void TestInitialize()
            {
                InitializeFakes();
                MappingProfileInitilizer.ConfigureMappings();
                request = new CreateGameRequest(FakeRepository, FakeRepositoryAggregate);
                createGame = () => FakeRepository.Create(A<Game>.Ignored);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                ClearFakes();
                request = null;
            }

            [TestMethod]
            public void ExecuteAsync()
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

                var response = request.Execute(A.Dummy<CreateGameInput>());

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(200);
                response.Game.Should().Be(expectedGame);
                response.ErrorResponse.Should().BeNull();

                A.CallTo(createGame).MustHaveHappenedOnceExactly();
            }

            [TestMethod]
            public void ExecuteAsyncExeptionIsThrown()
            {
                A.CallTo(createGame).Throws(ExceptionsUtility.BasicException);

                var response = request.Execute(A.Dummy<CreateGameInput>());

                response.Should().NotBeNull();
                response.StatusCode.Should().Be(500);
                response.Game.Should().BeNull();
                response.ErrorResponse.Should().NotBeNull();
                response.ErrorResponse.ErrorSummary.Should().Be(ExceptionsUtility.GenericMessage);
                response.ErrorResponse.InnerException.Should().BeNull();

                A.CallTo(createGame).MustHaveHappenedOnceExactly();
            }
        }
    }
}
