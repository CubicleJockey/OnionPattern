using System;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform;
using OnionPattern.Mapping.Platform;

namespace OnionPattern.Mapping.Tests.Platform
{
    public class PlatformToPlatformResponseDtoTypeConverterTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var converter = new PlatformToPlatformResponseDtoTypeConverter();

                converter.Should().NotBeNull();
                converter.Should().BeAssignableTo<ITypeConverter<Domain.Entities.Platform, PlatformResponseDto>>();
                converter.Should().BeOfType<PlatformToPlatformResponseDtoTypeConverter>();
            }
        }

        [TestClass]
        public class MethodsTests
        {
            private readonly PlatformToPlatformResponseDtoTypeConverter converter;

            public MethodsTests()
            {
                converter = new PlatformToPlatformResponseDtoTypeConverter();
            }

            [TestMethod]
            public void SourceIsNull()
            {
                Action convert = () => converter.Convert(null, default(PlatformResponseDto), default(ResolutionContext));

                convert.ShouldThrow<ArgumentNullException>()
                    .WithMessage($"Value cannot be null.{Environment.NewLine}Parameter name: source cannot be null.");
            }

            [TestMethod]
            public void ValidConversion()
            {
                var expected = new Domain.Entities.Platform
                {
                   Id = 42,
                   Name = "Awesome",
                   ReleaseDate = DateTime.Now,
                };

                var result = converter.Convert(expected, default(PlatformResponseDto), default(ResolutionContext));

                result.Should().NotBeNull();
                result.Id.ShouldBeEquivalentTo(expected.Id);
                result.Name.Should().BeEquivalentTo(expected.Name);
                result.ReleaseDate.ShouldBeEquivalentTo(expected.ReleaseDate);
            }
        }
    }
}
