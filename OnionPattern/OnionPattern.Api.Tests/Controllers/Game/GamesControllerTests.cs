using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Api.Controllers.Game;
using OnionPattern.Domain.Services.Requests.Game;
using OnionPattern.TestUtils;
using System;

namespace OnionPattern.Api.Tests.Controllers.Game
{
    public class GamesControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGameRequestAggregate fakeGameRequestAggregate;
            private GamesController controller;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeGameRequestAggregate = A.Fake<IGameRequestAggregate>();
                controller = new GamesController(fakeGameRequestAggregate);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeGameRequestAggregate);
            }

            [TestMethod]
            public void IGameRequestAggregateIsNull()
            {
                Action ctor = () => new GamesController(null);

                ctor.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage(ExceptionsUtility.ArgumentNull("gameRequestAggregate"));
            }

            [TestMethod]
            public void ShouldInheritFromController()
            {
                controller.Should().BeAssignableTo<Controller>();
            }

            [TestMethod]
            public void ShouldInheritFromBaseAsyncController()
            {
                controller.Should().BeAssignableTo<BaseController>();
            }


            [TestMethod]
            public void ShouldBeTypeOfGamesController()
            {
                controller.Should().BeOfType<GamesController>();
            }
        }
    }
}
