using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Services.Requests.Game;
using System;

namespace OnionPattern.Api.Tests.Controllers
{
    public class GamesControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGetAllGamesRequest fakeAllGamesRequest;
            private IGetGameByIdRequest fakeGetGameByIdRequest;
            private ICreateGameRequest fakeCreateGameRequest;
            private IUpdateGameRequest fakeUpdateGameRequest;
            private IDeleteGameByIdRequest fakeDeleteGameByIdRequest;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllGamesRequest = A.Fake<IGetAllGamesRequest>();
                fakeGetGameByIdRequest = A.Fake<IGetGameByIdRequest>();
                fakeCreateGameRequest = A.Fake<ICreateGameRequest>();
                fakeUpdateGameRequest = A.Fake<IUpdateGameRequest>();
                fakeDeleteGameByIdRequest = A.Fake<IDeleteGameByIdRequest>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllGamesRequest);
                Fake.ClearConfiguration(fakeGetGameByIdRequest);
                Fake.ClearConfiguration(fakeCreateGameRequest);
                Fake.ClearConfiguration(fakeUpdateGameRequest);
                Fake.ClearConfiguration(fakeDeleteGameByIdRequest);
            }

            [TestMethod]
            public void GetAllGamesRequestIsNull()
            {
                Action ctor = () => new GamesController(null, fakeGetGameByIdRequest, fakeCreateGameRequest, fakeUpdateGameRequest, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllGamesRequest cannot be null.");
            }

            [TestMethod]
            public void GetGameByNameRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, null, fakeCreateGameRequest, fakeUpdateGameRequest, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getGameByIdRequest cannot be null.");
            }

            [TestMethod]
            public void CreateGameRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, null, fakeUpdateGameRequest, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: createGameRequest cannot be null.");
            }

            [TestMethod]
            public void UpdateGameRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, fakeCreateGameRequest, null, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: updateGameTitleRequest  cannot be null.");
            }

            [TestMethod]
            public void DeleteGameByIdRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, fakeCreateGameRequest, fakeUpdateGameRequest, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: deleteGameByIdRequest cannot be null.");
            }
            
            [TestMethod]
            public void Inheritence()
            {
                var controller = new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, fakeCreateGameRequest, fakeUpdateGameRequest, fakeDeleteGameByIdRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeAssignableTo<BaseController>();
                controller.Should().BeOfType<GamesController>();
            }
        }
    }
}
