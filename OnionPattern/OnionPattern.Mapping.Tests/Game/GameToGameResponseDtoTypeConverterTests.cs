using System;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.Interfaces;
using OnionPattern.Mapping.Game;

namespace OnionPattern.Mapping.Tests.Game
{
    public class GameToGameResponseDtoTypeConverterTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var converter = new GameToGameResponseDtoTypeConverter();
                converter.Should().NotBeNull();
                converter.Should().BeAssignableTo<ITypeConverter<Domain.Entities.Game, GameResponseDto>>();
                converter.Should().BeOfType<GameToGameResponseDtoTypeConverter>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly GameToGameResponseDtoTypeConverter converter;

            public MethodsTests()
            {
                converter = new GameToGameResponseDtoTypeConverter();
            }

            [TestMethod]
            public void ValidConversion()
            {
                var source = new Domain.Entities.Game
                {
                    Id = 1,
                    Name = "SomeName",
                    Price = 69.69,
                    Genre = "Awesauce",
                    ReleaseDate = DateTime.Now.AddYears(-12)
                };

                var response = converter.Convert(source, default(GameResponseDto), default(ResolutionContext));
                response.Should().NotBeNull();
                response.Should().BeAssignableTo<IGame>();
                response.Should().BeOfType<GameResponseDto>();

                response.Id.Should().Be(source.Id);
                response.Name.Should().BeEquivalentTo(source.Name);
                response.Genre.Should().BeEquivalentTo(source.Genre);
                response.Price.Should().Be(source.Price);
                response.ReleaseDate.Should().Be(source.ReleaseDate);
            }
        }
    }
}
