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
            private IDeleteGameByIdRequest fakeDeleteGameByIdRequest;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllGamesRequest = A.Fake<IGetAllGamesRequest>();
                fakeGetGameByIdRequest = A.Fake<IGetGameByIdRequest>();
                fakeDeleteGameByIdRequest = A.Fake<IDeleteGameByIdRequest>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllGamesRequest);
                Fake.ClearConfiguration(fakeGetGameByIdRequest);
                Fake.ClearConfiguration(fakeDeleteGameByIdRequest);
            }

            [TestMethod]
            public void GetAllGamesRequestIsNull()
            {
                Action ctor = () => new GamesController(null, fakeGetGameByIdRequest, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllGamesRequest cannot be null.");
            }

            [TestMethod]
            public void GetGameByNameRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, null, fakeDeleteGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getGameByIdRequest cannot be null.");
            }

            [TestMethod]
            public void DeleteGameByIdRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: deleteGameByIdRequest cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GamesController(fakeAllGamesRequest, fakeGetGameByIdRequest, fakeDeleteGameByIdRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<GamesController>();
            }
        }
    }
}
