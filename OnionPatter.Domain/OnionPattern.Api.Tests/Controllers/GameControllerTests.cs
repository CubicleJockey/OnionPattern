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

            [TestInitialize]
            public void TestInitalize()
            {
                fakeAllGamesRequest = A.Fake<IGetAllGamesRequest>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeAllGamesRequest);
            }

            [TestMethod]
            public void GetAllGamesRequestIsNull()
            {
                Action ctor = () => new GamesController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: getAllGamesRequest cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                 var controller = new GamesController(fakeAllGamesRequest);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeOfType<GamesController>();
            }
        }
    }
}
