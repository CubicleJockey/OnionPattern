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
            private BaseController controller;

            [TestInitialize]
            public void TestInitialize()
            {
                controller = A.Fake<BaseController>();
            }

            [TestMethod]
            public void InheritsFromController()
            {
                controller.Should().BeAssignableTo<Controller>();
            }
        }
    }
}
