using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Domain.DataTransferObjects.Game.Input;
using OnionPattern.Domain.Interfaces;
using OnionPattern.Mapping.Game;
using System;

namespace OnionPattern.Mapping.Tests.Game
{
    public class CreateGameDtoToGameTypeConverterTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var converter = new CreateGameDtoToGameTypeConverter();
                converter.Should().NotBeNull();
                converter.Should().BeAssignableTo<ITypeConverter<CreateGameInputDto, Domain.Entities.Game>>();
                converter.Should().BeOfType<CreateGameDtoToGameTypeConverter>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly CreateGameDtoToGameTypeConverter converter;

            public MethodsTests()
            {
                converter = new CreateGameDtoToGameTypeConverter();
            }

            [TestMethod]
            public void SourceIsNull()
            {
                Action convert = () => converter.Convert(null, null, null);

                convert.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: source cannot be null.");
            }

            [TestMethod]
            public void ValidConversion()
            {
                var source = new CreateGameInputDto
                {
                    Name = "Thingy",
                    Genre = "Some Kind of Genre",
                    Price = 13.13,
                    ReleaseDate = DateTime.Now.AddDays(-15)
                };

                var response = converter.Convert(source, default(Domain.Entities.Game), default(ResolutionContext));
                response.Should().NotBeNull();
                response.Should().BeAssignableTo<IGame>();
                response.Should().BeOfType<Domain.Entities.Game>();

                response.Name.Should().BeEquivalentTo(source.Name);
                response.Genre.Should().BeEquivalentTo(source.Genre);
                response.Price.ShouldBeEquivalentTo(source.Price);
                response.ReleaseDate.ShouldBeEquivalentTo(source.ReleaseDate);
            }
        }
    }
}
