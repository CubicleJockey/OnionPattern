using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.StartupConfigurations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnionPattern.Api.Tests.StartupConfigurations
{
    public class SwaggerDefaultValuesTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void InheritsFromIOperationFilter()
            {
                var swaggerDefaultValues = new SwaggerDefaultValues();

                swaggerDefaultValues.Should().BeAssignableTo<IOperationFilter>();
            }
        }
    }
}
