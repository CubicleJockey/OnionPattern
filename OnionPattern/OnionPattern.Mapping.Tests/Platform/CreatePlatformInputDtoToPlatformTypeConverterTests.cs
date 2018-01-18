using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Domain.DataTransferObjects.Platform.Input;
using OnionPattern.Mapping.Platform;

namespace OnionPattern.Mapping.Tests.Platform
{
    public class CreatePlatformInputDtoToPlatformTypeConverterTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var converter = new CreatePlatformInputDtoToPlatformTypeConverter();

                converter.Should().NotBeNull();
                converter.Should().BeAssignableTo<BaseTypeConverter<CreatePlatformInputDto, Domain.Entities.Platform>>();
                converter.Should().BeAssignableTo<ITypeConverter<CreatePlatformInputDto, Domain.Entities.Platform>>();
                converter.Should().BeOfType<CreatePlatformInputDtoToPlatformTypeConverter>();
            }
        }
    }
}
