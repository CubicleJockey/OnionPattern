using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;
using OnionPattern.Domain.Services.Requests.Game.Async;
using System;

namespace OnionPattern.Api.Tests.Controllers
{
    public class GamesAsyncControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            private IGameRequestAggregateAsync fakeGameRequestAggregateAsync;

            [TestInitialize]
            public void TestInitialize()
            {
                fakeGameRequestAggregateAsync = A.Fake<IGameRequestAggregateAsync>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeGameRequestAggregateAsync);
            }

            [TestMethod]
            public void GetAllGamesRequestAsyncIsNull()
            {
                Action ctor = () => new GamesAsyncController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: gameRequestAggregateAsync cannot be null.");
            }

            [TestMethod]
            public void Inheritence()
            {
                var controller = new GamesAsyncController(fakeGameRequestAggregateAsync);

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeAssignableTo<BaseAsyncController>();
                controller.Should().BeOfType<GamesAsyncController>();
            }
        }
    }
}
