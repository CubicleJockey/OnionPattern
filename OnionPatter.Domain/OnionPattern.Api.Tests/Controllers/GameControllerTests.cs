using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Services.Requests.Game;
using System;

namespace OnionPattern.Api.Tests.Controllers
{
    public class GameControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGetAllGamesRequest fakeAllGamesRequest;
            private IGetGameByIdRequest _fakeGetGameByIdRequest;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllGamesRequest = A.Fake<IGetAllGamesRequest>();
                _fakeGetGameByIdRequest = A.Fake<IGetGameByIdRequest>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllGamesRequest);
                Fake.ClearConfiguration(_fakeGetGameByIdRequest);
            }

            [TestMethod]
            public void GetAllGamesRequestIsNull()
            {
                Action ctor = () => new GamesController(null, _fakeGetGameByIdRequest);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllGamesRequest cannot be null.");
            }

            [TestMethod]
            public void GetGameByNameRequestIsNull()
            {
                Action ctor = () => new GamesController(fakeAllGamesRequest, null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getGameByIdRequest cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GamesController(fakeAllGamesRequest, _fakeGetGameByIdRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<GamesController>();
            }
        }
    }
}
