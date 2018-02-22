using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Configuration.Startup.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnionPattern.Api.Tests.Configuration.Startup.Swagger
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
