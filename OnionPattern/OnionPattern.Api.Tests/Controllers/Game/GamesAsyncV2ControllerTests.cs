using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Api.Controllers.Game;
using OnionPattern.Domain.Services.Requests.Game.Async;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Api.Tests.Controllers.Game
{
    public class GamesAsyncV2ControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGameRequestAggregateAsync fakeGameRequestAggregateAsync;
            private GamesAsyncV2Controller controller;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeGameRequestAggregateAsync = A.Fake<IGameRequestAggregateAsync>();
                controller = new GamesAsyncV2Controller(fakeGameRequestAggregateAsync);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeGameRequestAggregateAsync);
            }

            [TestMethod]
            public void IGameRequestAggregateAsyncIsNull()
            {
                Action ctor = () => new GamesAsyncController(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.NullArgument("gameRequestAggregateAsync"));
            }

            [TestMethod]
            public void ShouldInheritFromController()
            {
                controller.Should().BeAssignableTo<Controller>();
            }

            [TestMethod]
            public void ShouldInheritFromBaseAsyncController()
            {
                controller.Should().BeAssignableTo<BaseAsyncController>();
            }


            [TestMethod]
            public void ShouldBeTypeOfGamesAsyncController()
            {
                controller.Should().BeOfType<GamesAsyncV2Controller>();
            }

        }
    }
}
