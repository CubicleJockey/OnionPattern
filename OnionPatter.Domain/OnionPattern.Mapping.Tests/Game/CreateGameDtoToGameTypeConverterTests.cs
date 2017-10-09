﻿using System;
using System.Linq.Expressions;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Game;
using OnionPattern.Mapping.Game;

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
                converter.Should().BeAssignableTo<ITypeConverter<CreateGameDto, Domain.Entities.Game>>();
                converter.Should().BeOfType<CreateGameDtoToGameTypeConverter>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            [TestMethod]
            public void ValidConversion()
            {
                var source = new CreateGameDto
                {
                    Name = "Thingy",
                    Genre = "Some Kind of Genre",
                    Price = 13.13,
                    ReleaseDate = DateTime.Now.AddDays(-15)
                };

                var converter = new CreateGameDtoToGameTypeConverter();
                converter.Should().NotBeNull();

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