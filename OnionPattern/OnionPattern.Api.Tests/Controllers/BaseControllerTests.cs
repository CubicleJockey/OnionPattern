using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionPattern.Api.Controllers;

namespace OnionPattern.Api.Tests.Controllers
{
    public class BaseControllerTests
    {
        [TestClass]
        public class ConstructorTests
        {
            [TestMethod]
            public void Inheritence()
            {
                var controller = A.Fake<BaseController>();

                controller.Should().NotBeNull();
                controller.Should().BeAssignableTo<Controller>();
                controller.Should().BeAssignableTo<BaseController>();
            }
        }
    }
}
