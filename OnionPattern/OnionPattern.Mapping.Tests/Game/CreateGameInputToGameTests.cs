using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.Game.Requests;
using System;

namespace OnionPattern.Mapping.Tests.Game
{
    [TestClass]
    public class CreateGameInputToGameTests : TestBase
    {
        [TestMethod]
        public void Valid()
        {
            var createGameInput = new CreateGameInput
            {
                Genre = "Some Genre",
                Name = "Da Name",
                Price = 69.69,
                ReleaseDate = DateTime.Now.AddDays(-17)
            };

            var game = Mapper.Map<Domain.Game.Entities.Game>(createGameInput);

            game.Should().NotBeNull();

            game.Genre.Should().Be(createGameInput.Genre);
            game.Name.Should().Be(createGameInput.Name);
            game.Price.Should().Be((decimal)createGameInput.Price);
            game.ReleaseDate.Should().Be(createGameInput.ReleaseDate);
        }
    }
}
