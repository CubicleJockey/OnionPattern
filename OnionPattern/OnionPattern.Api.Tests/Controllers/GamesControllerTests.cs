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
            private IGameRequestAggregate fakeGameRequestAggregate;

            [TestInitialize]
            public void TestInitalize()
            {
                fakeGameRequestAggregate = A.Fake<IGameRequestAggregate>();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                Fake.ClearConfiguration(fakeGameRequestAggregate);
            }

            [TestMethod]
            public void GameRequestAggregateIsNull()
            {
                Action ctor = () => new GamesController(null);

                ctor.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: gameRequestAggregate cannot be null.");
            }
        }
    }
}
